using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ProceduralGeneration.SimpleVisualizer;

namespace ProceduralGeneration
{
    public class Visualizer : MonoBehaviour
    {
        public LSystemGenerator lsystem;

        public RoadHelper roadHelper;
        public StructureHelper structureHelper;
        public int roadLength = 8;
        private int length = 8;
        private float angle = 90;

        public int Length
        {
            get
            {
                if (length > 0)
                {
                    return length;
                }
                else
                {
                    return 1;
                }
            }
            set => length = value;
        }

        private void Start()
        {
            CreateTown();
        }

        public void CreateTown()
        {
            length = roadLength;
            roadHelper.Reset();
            structureHelper.Reset();
            var sequence = lsystem.GenerateSentence();
            VisualizeSequence(sequence);
        }

        private void VisualizeSequence(string sequence)
        {
            Stack<AgentParameters> savePoints = new Stack<AgentParameters>();
            var currentPosition = Vector3.zero;

            Vector3 direction = Vector3.forward;
            Vector3 tempPosition = Vector3.zero;

            foreach (var letter in sequence)
            {
                EncodingLetters encoding = (EncodingLetters)letter;
                switch (encoding)
                {
                    case EncodingLetters.save:
                        savePoints.Push(new AgentParameters
                        {
                            position = currentPosition,
                            direction = direction,
                            length = Length
                        });
                        break;
                    case EncodingLetters.load:
                        if (savePoints.Count > 0)
                        {
                            var agentParameter = savePoints.Pop();
                            currentPosition = agentParameter.position;
                            direction = agentParameter.direction;
                            Length = agentParameter.length;
                        }
                        else
                        {
                            throw new System.Exception("There is no saved point in the stack");
                        }
                        break;
                    case EncodingLetters.draw:
                        tempPosition = currentPosition;
                        currentPosition += direction * Length;
                        roadHelper.PlaceStreetPositions(tempPosition, Vector3Int.RoundToInt(direction), length);
                        Length -= 2;
                        break;
                    case EncodingLetters.turnRight:
                        direction = Quaternion.AngleAxis(angle, Vector3.up) * direction;
                        break;
                    case EncodingLetters.turnLeft:
                        direction = Quaternion.AngleAxis(-angle, Vector3.up) * direction;
                        break;
                    default:
                        break;
                }
            }
            roadHelper.FixRoad();
            structureHelper.PlaceStructuresAroundRoad(roadHelper.GetRoadPositions());
        }
    }
}

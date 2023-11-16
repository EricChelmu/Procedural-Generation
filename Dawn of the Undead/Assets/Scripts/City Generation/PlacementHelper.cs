using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProceduralGeneration
{
    public static class PlacementHelper
    {
        //check for neighbouring nodes
        public static List<Direction> FindNeighbour(Vector3Int position, ICollection<Vector3Int> collection)
        {
            List<Direction> neighbourDirections = new List<Direction>();

            if (collection.Contains(position + Vector3Int.right))
            {
                neighbourDirections.Add(Direction.Right);
            }
            if (collection.Contains(position + Vector3Int.left))
            {
                neighbourDirections.Add(Direction.Left);
            }
            if (collection.Contains(position + Vector3Int.forward))
            {
                neighbourDirections.Add(Direction.Up);
            }
            if (collection.Contains(position + Vector3Int.back))
            {
                neighbourDirections.Add(Direction.Down);
            }
            return neighbourDirections;
        }

        internal static Vector3Int GetOffsetFromDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return Vector3Int.forward;
                case Direction.Down:
                    return Vector3Int.back;
                case Direction.Left:
                    return Vector3Int.left;
                case Direction.Right:
                    return Vector3Int.right;
                default:
                    break;
            }
            throw new System.Exception("No direction such as " + direction);
        }

        public static Direction GetReverseDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return Direction.Down;
                case Direction.Down:
                    return Direction.Up;
                case Direction.Left:
                    return Direction.Right;
                case Direction.Right:
                    return Direction.Left;
                default:
                    break;
            }
            throw new System.Exception("No direction such as " + direction);
        }
    }
}

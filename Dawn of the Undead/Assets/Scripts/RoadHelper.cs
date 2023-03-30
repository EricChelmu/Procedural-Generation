using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadHelper : MonoBehaviour
{
    public GameObject roadStraight, roadCorner, road3Way, road4Way, roadEnd;
    Dictionary<Vector3Int, GameObject> roadDictionary = new Dictionary<Vector3Int, GameObject>();
    HashSet<Vector3Int> fixRoadCandidates = new HashSet<Vector3Int>();

    public void PlaceStreetPositions(Vector3 startPosition, Vector3Int direction, int length)
    {
        var rotation = Quaternion.Euler(-90, 0, 0);
        if (direction.x == 0)
        {
            rotation = Quaternion.Euler(-90, 90, 0);
        }
        for (int i = 0; i < length; i++)
        {
            var position = Vector3Int.RoundToInt(startPosition + direction * i);
            if (roadDictionary.ContainsKey(position))
            {
                continue;
            }
            var road = Instantiate(roadStraight, position, rotation, transform);
            roadDictionary.Add(position, road);
            if (i == 0 || i == length-1)
            {
                fixRoadCandidates.Add(position);
            }
        }
    }
}

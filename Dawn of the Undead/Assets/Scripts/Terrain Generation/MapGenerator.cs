using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProceduralGeneration
{
    public class MapGenerator : MonoBehaviour
    {
        public int mapWidth;
        public int mapHeight;
        public int noiseScale;

        public void GenerateMap()
        {
            float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHeight, noiseScale);
        }

    }
}

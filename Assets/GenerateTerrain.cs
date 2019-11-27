using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GenerateTerrain : MonoBehaviour
{
    public int width = 256;
    public int height = 256;
    public int depth = 16;
    public float scale = 12f;
    public float offsetX = 100f;
    public float offsetY = 100f;
    public bool isMeshGenerated = false;
    void Start()
    {
        offsetX = Random.Range(0, 9999f);
        offsetY = Random.Range(0, 9999f);

    }
    void Update()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrains(terrain.terrainData);

        if(!isMeshGenerated)
        {
            NavMeshSurface nm = GameObject.FindObjectOfType<NavMeshSurface>();
            nm.UpdateNavMesh(nm.navMeshData);

            isMeshGenerated = true;
        }

        
    }
    TerrainData GenerateTerrains(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, depth, height);
        terrainData.SetHeights(0, 0, GenerateHeights());
        return terrainData;
    }
    float[,] GenerateHeights()
    {
        float[,] heights = new float[width, height];
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++) 
            {
                heights[x, y] = CalculateHeights(x,y);
            }
        }
        return heights;
    }
    float CalculateHeights(int x, int y)
    {
        float xCoord = (float)x /width * scale + offsetX;
        float yCoord = (float)y /height * scale + offsetY;
        return Mathf.PerlinNoise(xCoord, yCoord);
    }

}

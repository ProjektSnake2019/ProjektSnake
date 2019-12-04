using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTerrain : MonoBehaviour
{
    private int width = 256;
    private int height = 256;
    private int depth = 16;
    private float scale = 12f;
    private float offsetX = 100f;
    private float offsetY = 100f;
    public int treesCount = 500;
    public int roksCount = 500;
    public GameObject tree;
    public GameObject[] roks;
    private Vector3 actualPos;
    void Start()
    {
        offsetX = Random.Range(0, 9999f);
        offsetY = Random.Range(0, 9999f);
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrains(terrain.terrainData);
        GenerateObstacles(terrain);
    }

 

    void Update()
    {




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
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                heights[x, y] = CalculateHeights(x, y);
            }
        }
        return heights;
    }
    float CalculateHeights(int x, int y)
    {
        float xCoord = (float)x / width * scale + offsetX;
        float yCoord = (float)y / height * scale + offsetY;
        return Mathf.PerlinNoise(xCoord, yCoord);
    }
    private void GenerateObstacles(Terrain terrain)
    {
        int x, y;
        float actualHight;
        for (int i = 0; i < treesCount; i++)
        {
            x = Random.Range(0, width);
            y = Random.Range(0, height);
            actualHight = terrain.terrainData.GetHeight(x, y);
            if (actualHight > 7.57f)
            {
                actualPos = new Vector3(x, actualHight, y);
                Instantiate(tree, actualPos, Quaternion.identity);
            }
            else i--;
        }
        for (int i = 0; i < roksCount; i++)
        {
            x = Random.Range(0, width);
            y = Random.Range(0, height);
            actualHight = terrain.terrainData.GetHeight(x,y);
            if (actualHight <= 7.57f)
            {
                actualPos = new Vector3(x, 7.57f, y);
                switch (Random.Range(0, 6))
                {
                    case 0:
                        Instantiate(roks[0], actualPos, Quaternion.identity);
                        break;
                    case 1:
                        Instantiate(roks[1], actualPos, Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(roks[2], actualPos, Quaternion.identity);
                        break;
                    case 3:
                        Instantiate(roks[3], actualPos, Quaternion.identity);
                        break;
                    case 4:
                        Instantiate(roks[4], actualPos, Quaternion.identity);
                        break;
                    case 5:
                        Instantiate(roks[5], actualPos, Quaternion.identity);
                        break;
                }
            }
            else i--;
        }
        
    }
}
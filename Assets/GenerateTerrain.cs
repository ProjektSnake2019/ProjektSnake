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
    private bool isMeshGenerated = false;
    public GameObject tree;
    private Vector3 treePos;
    void Start()
    {
        offsetX = Random.Range(0, 9999f);
        offsetY = Random.Range(0, 9999f);
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrains(terrain.terrainData);
        float x, y ,treeHeight;
        for (int i = 0; i < 1000; i++)
        {
            x = Random.Range(0, width);
            y = Random.Range(0, height);
            treeHeight = terrain.terrainData.GetHeight((int)x, (int)y);
            if (treeHeight > 7.57f)
            {
                treePos = new Vector3(x, treeHeight, y);
                Instantiate(tree, treePos, Quaternion.identity);
            }
        }
    }
    void Update()
    {

        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrains(terrain.terrainData);

      

        if(!isMeshGenerated)
        {
            //NavMeshSurface nm = GameObject.FindObjectOfType<NavMeshSurface>();
            //nm.UpdateNavMesh(nm.navMeshData);

            //isMeshGenerated = true;
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

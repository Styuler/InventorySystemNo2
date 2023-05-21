using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class ProceduralGeneration : MonoBehaviour
{
    [SerializeField] private int width = 100;
    [SerializeField] private int minStoneHeight, maxStoneHeight, minOreHeight, maxOreHeight, minOreWidth, maxOreWidth;
    //[SerializeField] private GameObject dirt, dirt_grass, stone, iron_ore;
    [SerializeField] private Tilemap dirtTilemap, grassTilemap, stoneTilemap, ironTilemap;
    [SerializeField] private Tile dirt, grass, stone, iron;
    [Range(0,100)]
    [SerializeField] private float heightValue, smoothness;
    [SerializeField] float seed;

    private void Start()
    {
        seed = Random.Range(-10000, 10000);
        Generation();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            seed = Random.Range(-10000, 10000);
            Generation();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            stoneTilemap.ClearAllTiles();
            dirtTilemap.ClearAllTiles();
            grassTilemap.ClearAllTiles();
            ironTilemap.ClearAllTiles();
        }
    }

    void Generation()
    {
        int minOreSpawnWidth = width - minOreWidth;
        int maxOreSpawnWidth = width - maxOreWidth;
        int totalOreSpawnWidth = Random.Range(minOreSpawnWidth, maxOreSpawnWidth);
        
        for (int x = 0; x < width; x++)
        {
            if (x == totalOreSpawnWidth)
            {
                //SpawnObj(iron_ore,x,0);
            }
            
            // int minHeight = height - 1;
            // int maxHeight = height + 2;
            // height = Random.Range(minHeight, maxHeight);
            //--> Replacement with PerlinNoise
            int height = Mathf.RoundToInt(heightValue * Mathf.PerlinNoise(x / smoothness, seed)); 
            
            int minStoneSpawnDistance = height - minStoneHeight;
            int maxStoneSpawnDistance = height - maxStoneHeight;
            int totalStoneSpawnDistance = Random.Range(minStoneSpawnDistance, maxStoneSpawnDistance);

            int minOreSpawnDistance = height - minOreHeight;
            int maxOreSpawnDistance = height - maxOreHeight;
            int totalOreSpawnDistance = Random.Range(minOreSpawnDistance, maxOreSpawnDistance);
            
            for (int y = 0; y < height; y++) 
            {
                if (y > totalStoneSpawnDistance)
                {
                    //SpawnObj(dirt,x,y);
                    dirtTilemap.SetTile(new Vector3Int(x,y,0),dirt);
                }
                // else
                // {
                //     SpawnObj(dirt,x,y);
                // }

                if (y == totalOreSpawnDistance)
                {
                    //SpawnObj(iron_ore,x,y);
                    ironTilemap.SetTile(new Vector3Int(x,y,0),iron);
                }
                else
                {
                    //SpawnObj(stone,x,y);
                    stoneTilemap.SetTile(new Vector3Int(x,y,0),stone);
                }
            }

            if (totalStoneSpawnDistance == height)
            {
                //SpawnObj(stone,x,height);
                stoneTilemap.SetTile(new Vector3Int(x,height,0),stone);
            }
            else
            { 
                //SpawnObj(dirt_grass,x,height);
                grassTilemap.SetTile(new Vector3Int(x,height,0),grass);
            }
            
        }
    }

    // void SpawnObj(GameObject obj,int x,int y)
    // {
    //     obj = Instantiate(obj, new Vector2(x, y), quaternion.identity);
    //     obj.transform.parent = this.transform;
    // }
}

using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class ProceduralGeneration : MonoBehaviour
{
    [SerializeField] private int width = 100, height = 20;
    [SerializeField] private int minStoneHeight, maxStoneHeight, minOreHeight, maxOreHeight, minOreWidth, maxOreWidth;
    [SerializeField] private GameObject dirt, dirt_grass, stone, iron_ore;

    private void Start()
    {
        Generation();
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
                SpawnObj(iron_ore,x,0);
            }
            
            int minHeight = height - 1;
            int maxHeight = height + 2;

            height = Random.Range(minHeight, maxHeight);
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
                    //SpawnObj(stone,x,y);
                    SpawnObj(dirt,x,y);
                }
                // else
                // {
                //     SpawnObj(dirt,x,y);
                // }

                if (y == totalOreSpawnDistance)
                {
                    SpawnObj(iron_ore,x,y);
                }
                else
                {
                    SpawnObj(stone,x,y);
                }
            }

            if (totalStoneSpawnDistance == height)
            {
                SpawnObj(stone,x,height);
            }
            else
            {
                SpawnObj(dirt_grass,x,height);
            }
            
        }
    }

    void SpawnObj(GameObject obj,int x,int y)
    {
        obj = Instantiate(obj, new Vector2(x, y), quaternion.identity);
        obj.transform.parent = this.transform;
    }
}

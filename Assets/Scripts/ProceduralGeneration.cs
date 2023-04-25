using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class ProceduralGeneration : MonoBehaviour
{
    [SerializeField] private int width = 100, height = 20;
    [SerializeField] private int minStoneHeight, maxStoneHeight;
    [SerializeField] private GameObject dirt, dirt_grass, stone;

    private void Start()
    {
        Generation();
    }

    void Generation()
    {
        for (int x = 0; x < width; x++)
        {
            int minHeight = height - 1;
            int maxHeight = height + 2;

            height = Random.Range(minHeight, maxHeight);
            int minStoneSpawnDistance = height - minStoneHeight;
            int maxStoneSpawnDistance = height - maxStoneHeight;
            int totalStoneSpawnDistance = Random.Range(minStoneSpawnDistance, maxStoneSpawnDistance);
            
            for (int y = 0; y < height; y++)
            {
                if (y < totalStoneSpawnDistance)
                {
                    SpawnObj(stone,x,y);
                }
                else
                {
                    SpawnObj(dirt,x,y);
                }
                
            }

            if (totalStoneSpawnDistance == height)
            {
                SpawnObj(stone,x,height);
            }
            else
            {
                SpawnObj(dirt_grass,x,height);
                //SpawnObj(grass, x, height + 1);
            }
            
        }
    }

    void SpawnObj(GameObject obj,int x,int y)
    {
        obj = Instantiate(obj, new Vector2(x, y), quaternion.identity);
        obj.transform.parent = this.transform;
    }
}

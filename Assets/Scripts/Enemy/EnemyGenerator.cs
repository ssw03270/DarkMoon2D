using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public Transform playerPosition;

    public float minDistance = 5f;
    public float maxDistance = 10f;
    public float noiseDistance = 3f;

    public int minSpawnCount = 1;
    public int maxSpawnCount = 5;

    public float spawnCool = 0f;
    public float spawnSpeed = 5f;

    public List<GameObject> enemyList = new List<GameObject>();
    public string playerPrefabName = "Character (96)";
    // Start is called before the first frame update
    void Start()
    {
        Object[] subListObjects = Resources.LoadAll("Prefabs/Enemy", typeof(GameObject));
        foreach (GameObject subListObject in subListObjects)
        {
            GameObject lo = (GameObject)subListObject;
            if (lo.transform.name != playerPrefabName)
                enemyList.Add(lo);
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Spawn();
    }

    private void Spawn()
    {
        spawnCool += Time.fixedDeltaTime;
        if (spawnCool > spawnSpeed)
        {
            spawnCool = 0f;

            int enemyCount = enemyList.Count;
            int enemyIndex = Random.Range(0, enemyCount);

            int spawnCount = Random.Range(minSpawnCount, maxSpawnCount);
            int spawnDirectionIndex = Random.Range(0, 4);

            List<int> spawnDirectionX = new List<int>(new int[] { 1, 1, -1, -1});
            List<int> spawnDirectionY = new List<int>(new int[] { 1, -1, -1, 1 });
            for (int i = 0; i < spawnCount; i++)
            {
                float spawnX = spawnDirectionX[spawnDirectionIndex] * (Random.Range(minDistance, maxDistance) + Random.Range(0, noiseDistance));
                float spawnY = spawnDirectionY[spawnDirectionIndex] * (Random.Range(minDistance, maxDistance) + Random.Range(0, noiseDistance));

                Instantiate(enemyList[enemyIndex], playerPosition.position + new Vector3(spawnX, spawnY, 0), Quaternion.identity);
            }
        }
    }
}

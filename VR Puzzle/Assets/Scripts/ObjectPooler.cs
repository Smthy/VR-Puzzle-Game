using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public static ObjectPooler Instance;

    public int enemyMax = 20, currentAmount;

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;    //Setting the queue to be a dictionary

    private void Awake()
    {
        Instance = this; //Only allows one of these in the game
    }

    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)        //Uses each pool in the pool dictionary
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);

                obj.SetActive(false);
                objectPool.Enqueue(obj);       //Adds them to the queue
            }

            poolDictionary.Add(pool.tag, objectPool);
        }

        currentAmount = 0;
        StartCoroutine("Spawner");
    }

    public GameObject SpawnFromPool(string tag, Vector3 pos, Quaternion rotatation)
    {
        if(!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("No tag");
            return null;
        }

        GameObject objToSpawn = poolDictionary[tag].Dequeue();
                       
        objToSpawn.SetActive(true);                         //Uses the location and rotation of the objectpool to spawn in the AI
        objToSpawn.transform.position = pos;
        objToSpawn.transform.rotation = rotatation;

        poolDictionary[tag].Enqueue(objToSpawn);

        return objToSpawn;
    }
    
    IEnumerator Spawner()
    {
        if(currentAmount < enemyMax)
        {
            currentAmount++;
            Instance.SpawnFromPool("Enemy", transform.position, Quaternion.identity);   //Sets the active in the scene
        }

        yield return new WaitForSeconds(10f);
        StartCoroutine("Spawner");
    }
}

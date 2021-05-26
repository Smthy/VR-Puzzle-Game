using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveYard : MonoBehaviour
{
    public GameObject dagger;

    public GameObject[] spawnArea;
    private GameObject currentSpawnArea;

    public GameObject enemy;

    private int index, enemyIndex;

    private int enemyAmount;


    // Start is called before the first frame update
    void Start()
    {
        dagger.SetActive(false);
        enemyAmount = 5;
        StartCoroutine("DaggerSpawn");

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            SpawnAI();
        }
    }

    void SpawnAI()
    {       
        for (int i = 0; i < enemyAmount; i++)
        {
            index = Random.Range(0, spawnArea.Length);
            currentSpawnArea = spawnArea[index];
            Vector3 spawnPoint = new Vector3(currentSpawnArea.transform.position.x, currentSpawnArea.transform.position.y, currentSpawnArea.transform.position.z);                  //Sets random spawn points, which are on the graveyards

            Instantiate(enemy, spawnPoint, Quaternion.identity);            //Instantiates due to small amount of AI that will be spawned into the world.
        }

    }

    IEnumerator DaggerSpawn()
    {
        yield return new WaitForSeconds(5f);
        dagger.SetActive(true);         //Once the player has started to walk into the graveyard the dagger is spawned in.
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlySpawner : MonoBehaviour
{
    public GameObject flyPrefab;

   


    IEnumerator SpawnFly()
    {
        while(true)
        {
            // spawn fly randomly

            // random pos on screen

            Vector3 worldSpawnPoint = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(33, Screen.width-33), Random.Range(33, Screen.height-33), 0));
            worldSpawnPoint.z = 1;


            Instantiate(flyPrefab, worldSpawnPoint, Quaternion.identity);
            yield return new WaitForSeconds(5);
        }


    }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFly());
    }


    

}

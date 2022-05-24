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

            int flyCount = Random.Range(1, 3);

            for(int i = 0; i < flyCount; i++)
            {
                Vector3 worldSpawnPoint = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(33, Screen.width - 33), Random.Range(33, Screen.height - 33), 0));
                worldSpawnPoint.z = 1;
                Instantiate(flyPrefab, worldSpawnPoint, Quaternion.identity);
                yield return new WaitForSeconds(Random.Range(0,.5f));
            }

            yield return new WaitForSeconds(2.5f);
        }


    }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFly());
    }


    

}

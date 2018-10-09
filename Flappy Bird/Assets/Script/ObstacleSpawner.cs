using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

    public GameObject obstacle;
    public float timeToSpawn = 2;
    public float minY = -6 ;
    public float maxY = -7 ;
    float timer = 0;
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= timeToSpawn)
        {
            //spawn obstacle
            float randomY = Random.Range(minY , maxY);
            Vector3 spawnPosition = new Vector3(8, randomY, 0);
            Instantiate(obstacle, spawnPosition, Quaternion.identity);
            timer= 0;
        }
    }
}
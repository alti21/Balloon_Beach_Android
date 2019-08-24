using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject[] trianglePrefabs;
    private Vector3 spawnObstaclePosition;
    public int val = 0;
    public int val2 = 2;

    // Update is called once per frame
    void Update()
    {
        float distanceToHorizon = Vector3.Distance(player.gameObject.transform.position, spawnObstaclePosition);
        if(distanceToHorizon < 120)
        {
            SpawnTriangles();
        }
    }

    void SpawnTriangles()
    {//0 1 2 1 2 0 2 1 0 2
        spawnObstaclePosition = new Vector3(0, 0, spawnObstaclePosition.z + 30);
        Instantiate(trianglePrefabs[(val)], spawnObstaclePosition, Quaternion.identity);
        val++;
        if(val==9)
        {
            val = 0;
         
        }
       
        
      //  Instantiate(trianglePrefabs[(0)], spawnObstaclePosition, Quaternion.identity);
    }
}

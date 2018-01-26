using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {

    public float timeBetweenSpawns;
    public GameObject genericRoad;
    public Transform movementContiner;
    public List<GameObject> obstacles = new List<GameObject>();

    private bool started = false;

    private void Start()
    {
        StartCoroutine(SpawnGenericRoad());
    }

    private void Update()
    {
        
    }

    private IEnumerator SpawnGenericRoad()
    {
        yield return new WaitForSeconds(timeBetweenSpawns);

        GameObject newRoad = Instantiate(genericRoad, this.transform.localPosition, this.transform.localRotation);
        newRoad.transform.parent = movementContiner;

        if (started)
        {
            List<Transform> roadPoints = newRoad.GetComponent<MySpawnPoints>().mySpawnPoints;
            SpawnObstacles(roadPoints);
        }
        StartCoroutine(SpawnGenericRoad());
    }

    private void SpawnObstacles(List<Transform> points)
    {
        int pointsToFill = Random.Range(2, 4);
        
        while(pointsToFill > 0)
        {
            pointsToFill--;
            //int remainingPoints = points.Count;
            int pointToFill = Random.Range(0, points.Count);
            int objectToSpawn = Random.Range(0, obstacles.Count);

            GameObject obstacle = Instantiate(obstacles[objectToSpawn], points[pointToFill].transform.position, points[pointToFill].transform.rotation);
            obstacle.transform.parent = points[pointToFill].transform;

            points.RemoveAt(pointToFill);
        }
    }
}

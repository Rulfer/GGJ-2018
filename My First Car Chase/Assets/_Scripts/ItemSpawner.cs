using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {

    //public float timeBetweenSpawns;

    public GameObject genericRoad;
    public Transform movementContiner;
    public List<GameObject> obstacles = new List<GameObject>();
    public GameObject policeCar;
    private float timePlayed = 0f;
    public CarGearing gear;

    private void Update()
    {
        timePlayed += Time.deltaTime;
    }

    public void SpawnGenericRoad()
    {
        GameObject newRoad = Instantiate(genericRoad, this.transform.localPosition, this.transform.localRotation);
        newRoad.transform.parent = movementContiner;

        List<Transform> roadPoints = newRoad.GetComponent<MySpawnPoints>().mySpawnPoints;
        SpawnObstacles(roadPoints);
    }

    private void SpawnObstacles(List<Transform> points)
    {
        int difficulty = GenerateDifficulty();
        Debug.Log("Difficulty: " + difficulty);
        if(difficulty == 5)
        {
            Debug.Log("Spawn police cars");
            int openPoint = Random.Range(0, 5);

            for(int i = 0; i < points.Count; i++)
            {
                if(i != openPoint)
                {
                    GameObject obstacle = Instantiate(policeCar, points[i].transform.position, points[i].transform.rotation);
                    obstacle.transform.parent = points[i].transform;
                }
            }
        }
        else
        {
            //pointsToFill = Random.Range(0, difficulty);

            while (difficulty > 0)
            {
                difficulty--;
                int pointToFill = Random.Range(0, points.Count);
                int objectToSpawn = Random.Range(0, obstacles.Count);

                GameObject obstacle = Instantiate(obstacles[objectToSpawn], points[pointToFill].transform.position, points[pointToFill].transform.rotation);
                obstacle.transform.parent = points[pointToFill].transform;

                points.RemoveAt(pointToFill);
            }
        }
    }

    private int GenerateDifficulty()
    {
        if(timePlayed < 20)
        {
            //Always returns 1
            return Random.Range(1, 2);
        }
        else if(timePlayed < 40)
        {
            //Returns 1 or 2
            return Random.Range(1, 3);
        }
        else if(timePlayed < 60)
        {
            //Returns 1, 2 or 3
            return Random.Range(1, 4);
        }
        else if(timePlayed < 80)
        {
            //Returns 2, 3 or 4
            return Random.Range(2, 5);
        }
        else
        {
            //Returns 3, 4 or 5+
            return Random.Range(3, 6);
        }
    }
   
    private void ChangeSpeedLimit()
    {

    }
}

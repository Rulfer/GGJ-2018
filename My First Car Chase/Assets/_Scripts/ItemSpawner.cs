using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {

    public float timeBetweenSpawns;
    public GameObject genericRoad;
    public Transform movementContiner;

    private void Start()
    {
        InvokeRepeating("SpawnGenericRoad", 0, timeBetweenSpawns);
    }

    private void SpawnGenericRoad()
    {
        GameObject newRoad = Instantiate(genericRoad, this.transform.localPosition, this.transform.localRotation);
        newRoad.transform.parent = movementContiner;
    }

    // Update is called once per frame
    void Update () {
		
	}
}

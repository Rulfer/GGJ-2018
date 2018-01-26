using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {

    public float timeBetweenSpawns;
    public GameObject genericRoad;
    public Transform movementContiner;

    private void Start()
    {
        //InvokeRepeating("SpawnGenericRoad", 0, timeBetweenSpawns);

        StartCoroutine(SpawnGenericRoad());
    }

    private IEnumerator SpawnGenericRoad()
    {
        yield return new WaitForSeconds(timeBetweenSpawns);

        GameObject newRoad = Instantiate(genericRoad, this.transform.localPosition, this.transform.localRotation);
        newRoad.transform.parent = movementContiner;

        StartCoroutine(SpawnGenericRoad());
    }

    // Update is called once per frame
    void Update () {
		
	}
}

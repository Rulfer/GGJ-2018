using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenSpawner : MonoBehaviour {

    public GameObject genericRoad;
    public Transform movementContiner;

    public void SpawnGenericRoad()
    {
        GameObject newRoad = Instantiate(genericRoad, this.transform.localPosition, this.transform.localRotation);
        newRoad.transform.parent = movementContiner;
    }
}

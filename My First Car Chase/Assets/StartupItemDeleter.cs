using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartupItemDeleter : MonoBehaviour {

    public StartScreenSpawner spawner;
    private void OnTriggerEnter(Collider other)
    {
        spawner.SpawnGenericRoad();
        Destroy(other.gameObject);
    }
}

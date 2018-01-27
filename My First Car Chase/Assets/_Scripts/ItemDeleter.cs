using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDeleter : MonoBehaviour {

    public ItemSpawner spawner;
    private void OnTriggerEnter(Collider other)
    {
        spawner.SpawnGenericRoad();
        Destroy(other.gameObject);
    }
}

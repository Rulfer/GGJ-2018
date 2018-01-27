using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpeedLimit : MonoBehaviour {

    public Speed speed;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag.Equals("Player"))
        {
            speed.currentSpeed = int.Parse(this.transform.name);
        }
    }
}

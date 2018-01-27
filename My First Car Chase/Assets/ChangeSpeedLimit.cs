using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpeedLimit : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag.Equals("Player"))
        {
            GameObject.FindObjectOfType<Speed>().ChangeSpeed( float.Parse(this.transform.name));
        }
    }
}

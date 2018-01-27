using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenSpeed : MonoBehaviour {

    public float currentSpeed = 0.6f;


    // Update is called once per frame
    void FixedUpdate () {
        this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, this.transform.localPosition.z - currentSpeed);

    }
}

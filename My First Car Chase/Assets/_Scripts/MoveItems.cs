using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveItems : MonoBehaviour
{
    public float moveSpeed;
    public float gearModifier;
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        this.transform.localPosition =new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, this.transform.localPosition.z -  moveSpeed);
	}
}

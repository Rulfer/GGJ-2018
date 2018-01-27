using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    public float speedStep = 0.3f;
    public float baseSpeed = 0.5f;
    public float currentSpeed;
    public float maxSpeed;

    private CarGearing carGearing;

	// Use this for initialization
	void Start ()
    {
        currentSpeed = speedStep;
        carGearing = (CarGearing) GameObject.FindGameObjectWithTag("Player").GetComponent(typeof(CarGearing));
        maxSpeed = baseSpeed + speedStep * carGearing.maxGear;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("3"))
            currentSpeed += speedStep;
        else if (Input.GetKeyDown("2"))
            currentSpeed -= speedStep;

        if (currentSpeed < baseSpeed)
            currentSpeed = baseSpeed;
        else if (currentSpeed > maxSpeed)
            currentSpeed = maxSpeed;
	}

    private void FixedUpdate()
    {
        this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, this.transform.localPosition.z - currentSpeed);
    }
}

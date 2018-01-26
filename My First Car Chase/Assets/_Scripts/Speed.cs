using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    public int speedStep = 20;
    public int currentSpeed;
    public int maxSpeed;

    private CarGearing carGearing;

	// Use this for initialization
	void Start ()
    {
        currentSpeed = speedStep;
        carGearing = (CarGearing) GameObject.FindGameObjectWithTag("Player").GetComponent(typeof(CarGearing));
        maxSpeed = speedStep * carGearing.maxGear;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("3"))
        {
            currentSpeed += speedStep;
        }
        else if (Input.GetKeyDown("2"))
        {
            currentSpeed -= speedStep;
        }
	}
}

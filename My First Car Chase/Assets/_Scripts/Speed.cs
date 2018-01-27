using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speed : MonoBehaviour
{
    public float speedStep = 0.3f;
    public float baseSpeed = 0.5f;
    public float currentSpeed;
    public float maxSpeed;

    private CarGearing carGearing;
    private Text speedometer;

	// Use this for initialization
	void Start ()
    {
        currentSpeed = speedStep;
        carGearing = (CarGearing) GameObject.FindGameObjectWithTag("Player").GetComponent(typeof(CarGearing));
        maxSpeed = baseSpeed + speedStep * (carGearing.maxGear - 1);
        speedometer = GameObject.Find("Speedometer").GetComponent<Text>();
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
        speedometer.text = Mathf.Round(currentSpeed * 100).ToString() + " km/h";
	}

    private void FixedUpdate()
    {
        this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, this.transform.localPosition.z - currentSpeed);
    }

    public void ChangeSpeed(float signSpeed)
    {
        //70 becomes .7
        float newSpeedModifier = signSpeed * 0.1f;
        
    }
}

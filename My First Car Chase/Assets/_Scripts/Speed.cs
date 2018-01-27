using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speed : MonoBehaviour
{
    //public float speedStep = 0.3f;
    public float baseSpeed = 0.5f;
    public float currentSpeed;
    public float maxSpeed;
    public int targetGear = 1;

    private CarGearing carGearing;
    private Text speedometer;

    private float currentSpeedModifier = 0.1f;

	// Use this for initialization
	void Start ()
    {
        currentSpeed = baseSpeed + currentSpeedModifier;
        targetGear = 1;
        carGearing = (CarGearing) GameObject.FindGameObjectWithTag("Player").GetComponent(typeof(CarGearing));
        //maxSpeed = baseSpeed + speedStep * (carGearing.maxGear - 1);
        speedometer = GameObject.Find("Speedometer").GetComponent<Text>();
        speedometer.text = Mathf.Round(currentSpeedModifier * 100).ToString() + " km/h";
    }

    // Update is called once per frame
    void Update ()
    {
        /*if (Input.GetKeyDown("3"))
            currentSpeed += speedStep;
        else if (Input.GetKeyDown("2"))
            currentSpeed -= speedStep;
            
        if (currentSpeed < baseSpeed)
            currentSpeed = baseSpeed;
        else if (currentSpeed > maxSpeed)
            currentSpeed = maxSpeed;*/
	}

    private void FixedUpdate()
    {
        this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, this.transform.localPosition.z - currentSpeed);
    }

    public void ChangeSpeed(float signSpeed)
    { 
        float newSpeedModifier = signSpeed / 100f;
        if(newSpeedModifier != currentSpeedModifier)
        {
            currentSpeed = baseSpeed + newSpeedModifier;
            currentSpeedModifier = newSpeedModifier;
            speedometer.text = Mathf.Round(newSpeedModifier * 100).ToString() + " km/h";

            switch(newSpeedModifier.ToString())
            {
                case "0.1":
                    targetGear = 1;
                    return;
                case "0.3":
                    targetGear = 2;
                    return;
                case "0.5":
                    targetGear = 3;
                    return;
                case "0.7":
                    targetGear = 4;
                    return;
                case "0.9":
                    targetGear = 5;
                    return;

            }
        }
    }
}

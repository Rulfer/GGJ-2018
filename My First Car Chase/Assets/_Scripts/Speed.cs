using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speed : MonoBehaviour
{
    //public float speedStep = 0.3f;
    public float baseSpeed = 0.5f;
    public float currentSpeed;
    public float targetSpeed;
    private float speedTransitionModifyer = 0.1f;
    public int targetGear = 1;

    private CarGearing carGearing;
    private Text speedometer;

    private float currentSpeedModifier = 0.1f;


	// Use this for initialization
	void Start ()
    {
        currentSpeed = baseSpeed + currentSpeedModifier;
        targetSpeed = currentSpeed;
        targetGear = 1;
        carGearing = (CarGearing) GameObject.FindGameObjectWithTag("Player").GetComponent(typeof(CarGearing));
        //maxSpeed = baseSpeed + speedStep * (carGearing.maxGear - 1);
        speedometer = GameObject.Find("Speedometer").GetComponent<Text>();
        speedometer.text = Mathf.Round((currentSpeedModifier + 0.5f) * 100).ToString() + " km/h";
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
        if(targetSpeed == -1)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, Time.deltaTime * speedTransitionModifyer * 0.5f);
        }
        else
            currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, Time.deltaTime * speedTransitionModifyer);
        this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, this.transform.localPosition.z - currentSpeed);
    }

    //TODO: Update TargetSpeed, and accelerate towards that speed
    public void ChangeSpeed(float newSpeed)
    { 
        if(newSpeed == -1)
        {
            //Gradually loose speed
            currentSpeedModifier = -1;
            targetSpeed = -1;
            return;
        }
        float newSpeedModifier = newSpeed / 100f;
        if(newSpeedModifier != currentSpeedModifier)
        {
            targetSpeed = baseSpeed + newSpeedModifier;
            currentSpeedModifier = newSpeedModifier;
            speedometer.text = Mathf.Round((newSpeedModifier + 0.5f) * 100).ToString() + " km/h";
        }
    }
}

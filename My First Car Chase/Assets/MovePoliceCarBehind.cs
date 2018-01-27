using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoliceCarBehind : MonoBehaviour
{
    private Vector3 rotateCar = new Vector3(0, 1, 0);
    private int rotateDir = 0;
    float rotationDeg;
    float maxRotation = 25;

    private Vector3 drivingDirVec = new Vector3(0, 0, 1);
    private int drivingDir = 0;


    private float timer;


	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 lockXVec = new Vector3(.05f, this.transform.localPosition.y, this.transform.localPosition.z);

        this.transform.localPosition = lockXVec;
        timer += Time.deltaTime;

        if (rotationDeg <= maxRotation && rotateDir == 0)
        {
            this.transform.Rotate(rotateCar, Time.deltaTime * 5);
            rotationDeg += Time.deltaTime * 5;
        }
        
        else if (rotationDeg >= -maxRotation && rotateDir == 1)
        {
            this.transform.Rotate(-rotateCar, Time.deltaTime * 5);
            rotationDeg -= Time.deltaTime * 5;
        }

        if (this.transform.localPosition.z <= -0.65f && drivingDir == 0)
        {
            this.transform.Translate(drivingDirVec * Time.deltaTime / 5);
        }

        else if (this.transform.localPosition.z >= -0.85f && drivingDir == 1)
        {
            this.transform.Translate(-drivingDirVec * Time.deltaTime / 5);

        }



        if (timer >= 2f)
        {
            rotateDir = Mathf.RoundToInt(Random.Range(0, 2));
            drivingDir = Mathf.RoundToInt(Random.Range(0, 2));

            timer = 0;
        }
    }
}

﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{

    public GameObject player;
    public int currentLaneIndex;
    public GameObject[] lanes;
    public bool moving = false;
    public float movementSpeedFactor = 12.0f;
    private float movementSpeed;

    private Speed speed;
    private GameObject steeringWheel;

	// Use this for initialization
	void Start ()
    {
        speed = (Speed)GameObject.Find("ItemWorldMover").GetComponent(typeof(Speed));
        steeringWheel = GameObject.Find("Steering_Wheel");
        if (lanes.Length == 0)
        {
            lanes = GameObject.FindGameObjectsWithTag("Lane");
            Array.Sort(lanes, CompareXPosition);
        }
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");
        currentLaneIndex = FindCenterLaneIndex();
        player.transform.position = lanes[currentLaneIndex].transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        movementSpeed = speed.currentSpeed * movementSpeedFactor;
        if (moving && player.transform.position == lanes[currentLaneIndex].transform.position)
            moving = false;

        int newLane = FindTargetLane();
        if (!moving && newLane != currentLaneIndex && -1 < newLane && newLane < lanes.Length)
        {
            currentLaneIndex = newLane;
            MovePlayer();
        }
        if (moving && player.transform.position != lanes[currentLaneIndex].transform.position)
            MovePlayer();

        int direction = CompareXPosition(player, lanes[currentLaneIndex]);
        Vector3 rot = steeringWheel.transform.localEulerAngles;
        Vector3 targetRot = new Vector3(0, 270, 85);
        if (direction < 0)
            targetRot.x = 270;
        else if (direction > 0)
            targetRot.x = 90;
        else
            targetRot.x = 0;
        steeringWheel.transform.rotation = Quaternion.RotateTowards(Quaternion.Euler(rot), Quaternion.Euler(targetRot), 300 * Time.deltaTime);
    }

    private int FindTargetLane()
    {
        int newLane = currentLaneIndex;
        if (Input.GetKeyDown("a"))
            newLane -= 1;
        else if (Input.GetKeyDown("d"))
            newLane += 1;
        return newLane;
    }

    private void MovePlayer()
    {
        if (!moving)
            moving = true;
        float step = movementSpeed * Time.deltaTime;
        player.transform.position = Vector3.MoveTowards(
            player.transform.position, lanes[currentLaneIndex].transform.position, step);
    }

    private int FindCenterLaneIndex()
    {
        return (int) (Mathf.Ceil(((float)lanes.Length / 2.0f)) - 1.0f);
    }
    
    private int CompareXPosition(GameObject first, GameObject second)
    {
        return first.transform.position.x.CompareTo(second.transform.position.x);
    }
}

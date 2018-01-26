﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour {

    public GameObject player;
    public int currentLaneIndex;
    public GameObject[] lanes;
    public bool moving = false;
    public float playerSpeed = 1.0f;

	// Use this for initialization
	void Start () {
        if(lanes.Length == 0)
            lanes = GameObject.FindGameObjectsWithTag("Lane");
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");
        currentLaneIndex = FindCenterLaneIndex();
        player.transform.position = lanes[currentLaneIndex].transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (moving && player.transform.position == lanes[currentLaneIndex].transform.position)
            moving = false;

        int newLane = currentLaneIndex;

        float axis = Input.GetAxis("Horizontal");
        if (axis < -0.1f)
            newLane += 1;
        else if (axis > 0.1f)
            newLane -= 1;

        if (!moving && newLane != currentLaneIndex && -1 < newLane && newLane < lanes.Length)
        {
            currentLaneIndex = newLane;
            MovePlayer();
        }
        if (moving && player.transform.position != lanes[currentLaneIndex].transform.position)
            MovePlayer();
    }

    private void MovePlayer()
    {
        if (!moving)
            moving = true;
        float step = playerSpeed * Time.deltaTime;
        player.transform.position = Vector3.MoveTowards(
            player.transform.position, lanes[currentLaneIndex].transform.position, step);
    }

    private int FindCenterLaneIndex()
    {
        return (int) (Mathf.Ceil(((float)lanes.Length / 2.0f)) - 1.0f);
    }
}

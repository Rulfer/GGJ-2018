﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CarHitObstacle : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag.Equals("obstacle"))
        {
            SceneManager.LoadScene(0);
            Debug.Log("U ded");
            Debug.Log("Please restart the game");
        }

    }
}

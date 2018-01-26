using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGearing : MonoBehaviour
{
    public int maxGear = 5;
    public int minGear = 1;
    public int currentGear = 1;
    public int optimalGear = 1;

    public int health = 100;

    private Speed speed;

	// Use this for initialization
	void Start ()
    {
        speed = (Speed) GameObject.Find("GameManager").GetComponent(typeof(Speed));
	}
	
	// Update is called once per frame
	void Update ()
    {
        optimalGear = speed.currentSpeed / speed.speedStep;
        if (Input.GetKeyDown("w") && currentGear < maxGear)
        {
            currentGear += 1;
        }
        else if(Input.GetKeyDown("s") && currentGear > minGear)
        {
            currentGear -= 1;
        }
        if(currentGear != optimalGear)
        {
            TakeDamage();
        }
	}

    private void TakeDamage()
    {
        int damage = 0;
        if(currentGear > optimalGear)
        {
            damage = (currentGear - optimalGear) * 2;
        }
        else if(currentGear < optimalGear)
        {
            damage = (optimalGear - currentGear) * 2;
        }
        health -= damage;
        Debug.Log("TAKING DAMAGE. CURRENT HEALTH: " + health);
    }
}

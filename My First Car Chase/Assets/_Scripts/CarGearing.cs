using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarGearing : MonoBehaviour
{
    public int maxGear = 5;
    public int minGear = 1;
    public int currentGear = 1;
    //public int optimalGear = 1;

    public int health = 100;
    private bool takingDamage = false;

    private Speed speed;

    private GameObject[] gearNumbers;
    private GameObject gearIndicator;
    private Color optimalGearColor = new Color(0, 0.66f, 0, 1);
    private Color wrongGearColor = new Color(0.84f, 0, 0, 1);

    // Use this for initialization
    void Start ()
    {
        speed = (Speed) GameObject.Find("ItemWorldMover").GetComponent(typeof(Speed));
        gearNumbers = GameObject.FindGameObjectsWithTag("GearNumber");
        Array.Sort(gearNumbers, CompareGearNumber);
        gearIndicator = GameObject.FindGameObjectWithTag("GearIndicator");
	}
	
	// Update is called once per frame
	void Update ()
    {
        //optimalGear = FindOptimalGear();
        if (Input.GetKeyDown("w") || Input.GetKeyDown("up"))
            currentGear += 1;
        else if(Input.GetKeyDown("s") || Input.GetKeyDown("down"))
            currentGear -= 1;
        if (currentGear > maxGear)
            currentGear = maxGear;
        else if (currentGear < minGear)
            currentGear = minGear;

        if(currentGear == speed.targetGear && takingDamage)
        {
            takingDamage = false;
            StopCoroutine(DamageRoutine());
        }
        else if(currentGear != speed.targetGear && !takingDamage)
        {
            takingDamage = true;
            StartCoroutine(DamageRoutine());
        }
        UpdateGearIndicators();
    }

    /*private int FindOptimalGear()
    {
        if (speed.currentSpeed == speed.baseSpeed)
            return 1;
        return 1 + Mathf.RoundToInt((speed.currentSpeed - speed.baseSpeed) / speed.speedStep);
    }*/

    private void UpdateGearIndicators()
    {
        for(int i = 0; i < gearNumbers.Length; i++)
        {
            if(i + 1 == speed.targetGear)
                gearNumbers[i].GetComponent<Text>().color = optimalGearColor;
            else
                gearNumbers[i].GetComponent<Text>().color = wrongGearColor;
        }
        Vector3 targetPosition = gearNumbers[currentGear - 1].transform.position;
        gearIndicator.transform.position = new Vector3(targetPosition.x, targetPosition.y + 12, targetPosition.z);
    }

    IEnumerator DamageRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (takingDamage)
            {
                TakeDamage();
            }
        }
    }

    private void TakeDamage()
    {
        int damage = 0;
        if (currentGear > speed.targetGear)
        {
            damage = (currentGear - speed.targetGear) * 2;
        }
        else if (currentGear < speed.targetGear)
        {
            damage = (speed.targetGear - currentGear) * 2;
        }
        health -= damage;
        Debug.Log("TAKING DAMAGE. CURRENT HEALTH: " + health);
    }

    private int CompareGearNumber(GameObject first, GameObject second)
    {
        return int.Parse(first.GetComponent<Text>().text).CompareTo(int.Parse(second.GetComponent<Text>().text));
    }
}

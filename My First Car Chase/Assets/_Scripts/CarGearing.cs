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
    public int optimalGear = 1;

    public int health = 100;
    private bool takingDamage = false;

    private Speed speed;

    private GameObject[] gearNumbers;
    private GameObject gearIndicator;
    public Color optimalGearColor = new Color(0, 1, 0);
    public Color wrongGearColor = new Color(1, 0, 0);

    // Use this for initialization
    void Start ()
    {
        speed = (Speed) GameObject.Find("GameControl").GetComponent(typeof(Speed));
        gearNumbers = GameObject.FindGameObjectsWithTag("GearNumber");
        Array.Sort(gearNumbers, CompareGearNumber);
        gearIndicator = GameObject.FindGameObjectWithTag("GearIndicator");
	}
	
	// Update is called once per frame
	void Update ()
    {
        optimalGear = speed.currentSpeed / speed.speedStep;
        if (Input.GetKeyDown("w"))
            currentGear += 1;
        else if(Input.GetKeyDown("s"))
            currentGear -= 1;
        if (currentGear > maxGear)
            currentGear = maxGear;
        else if (currentGear < minGear)
            currentGear = minGear;

        if(currentGear == optimalGear && takingDamage)
        {
            takingDamage = false;
            StopCoroutine(DamageRoutine());
        }
        else if(currentGear != optimalGear && !takingDamage)
        {
            takingDamage = true;
            StartCoroutine(DamageRoutine());
        }
        UpdateGearIndicators();
    }

    private void UpdateGearIndicators()
    {
        for(int i = 0; i < gearNumbers.Length; i++)
        {
            if(i + 1 == optimalGear)
                gearNumbers[i].GetComponent<Text>().color = optimalGearColor;
            else
                gearNumbers[i].GetComponent<Text>().color = wrongGearColor;
        }
        Vector3 targetPosition = gearNumbers[currentGear - 1].transform.position;
        gearIndicator.transform.position = new Vector3(targetPosition.x + 2, targetPosition.y + 12, targetPosition.z);
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
        if (currentGear > optimalGear)
        {
            damage = (currentGear - optimalGear) * 2;
        }
        else if (currentGear < optimalGear)
        {
            damage = (optimalGear - currentGear) * 2;
        }
        health -= damage;
        Debug.Log("TAKING DAMAGE. CURRENT HEALTH: " + health);
    }

    private int CompareGearNumber(GameObject first, GameObject second)
    {
        return int.Parse(first.GetComponent<Text>().text).CompareTo(int.Parse(second.GetComponent<Text>().text));
    }
}

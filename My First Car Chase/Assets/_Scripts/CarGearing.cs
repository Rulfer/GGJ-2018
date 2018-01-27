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
    private Score score;

    private GameObject[] gearNumbers;
    private GameObject gearIndicator;
    private Color optimalGearColor = new Color(0, 0.66f, 0, 1);
    private Color wrongGearColor = new Color(0.84f, 0, 0, 1);

    private bool gearing = false;
    public GearPoint currentGearPoint = null;

    // Use this for initialization
    void Start ()
    {
        currentGearPoint.GetComponent<RawImage>().color = Color.green;
        speed = (Speed) GameObject.Find("ItemWorldMover").GetComponent(typeof(Speed));
        score = GameObject.FindObjectOfType<Score>();
        gearNumbers = GameObject.FindGameObjectsWithTag("GearNumber");
        Array.Sort(gearNumbers, CompareGearNumber);
        gearIndicator = GameObject.FindGameObjectWithTag("GearIndicator");
        StartCoroutine(DamageRoutine());
    }

    // Update is called once per frame
    /*void Update ()
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
        }
        else if(currentGear != speed.targetGear && !takingDamage)
        {
            takingDamage = true;
        }
        UpdateGearIndicators();
    }*/

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !gearing)
        {
            speed.ChangeSpeed(-1);
            score.generatePoints = false;
            gearing = true;
        }
        if(Input.GetKeyUp(KeyCode.Space) && gearing)
        {
            gearing = false;
            
            if(currentGearPoint.gameObject.transform.name.Equals("free"))
            {
                score.generatePoints = false;
                speed.ChangeSpeed(-1);
            }
            else
            {
                score.generatePoints = true;
                speed.ChangeSpeed(float.Parse(currentGearPoint.gameObject.transform.name));
            }
        }
        if(gearing)
        {
            DoGearing();
        }
    }

    /*private int FindOptimalGear()
    {
        if (speed.currentSpeed == speed.baseSpeed)
            return 1;
        return 1 + Mathf.RoundToInt((speed.currentSpeed - speed.baseSpeed) / speed.speedStep);
    }*/

    private void DoGearing()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(currentGearPoint.pointDown != null)
            {
                currentGearPoint.GetComponent<RawImage>().color = Color.white;
                currentGearPoint = currentGearPoint.pointDown;
                currentGearPoint.GetComponent<RawImage>().color = Color.green;

            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentGearPoint.pointUp != null)
            {
                currentGearPoint.GetComponent<RawImage>().color = Color.white;
                currentGearPoint = currentGearPoint.pointUp;
                currentGearPoint.GetComponent<RawImage>().color = Color.green;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentGearPoint.pointLeft != null)
            {
                currentGearPoint.GetComponent<RawImage>().color = Color.white;
                currentGearPoint = currentGearPoint.pointLeft;
                currentGearPoint.GetComponent<RawImage>().color = Color.green;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentGearPoint.pointRight != null)
            {
                currentGearPoint.GetComponent<RawImage>().color = Color.white;
                currentGearPoint = currentGearPoint.pointRight;
                currentGearPoint.GetComponent<RawImage>().color = Color.green;
            }
        }
    }

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
            else
            {
                Heal();
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

    private void Heal()
    {
        if (health < 100)
            health += 2;
    }

    private int CompareGearNumber(GameObject first, GameObject second)
    {
        return int.Parse(first.GetComponent<Text>().text).CompareTo(int.Parse(second.GetComponent<Text>().text));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampLightsScript : MonoBehaviour
{
    public Color[] lightColors;
    public Light[] numLights;
    public AudioClip clip01;
    public float clipLenght;
    private float timer;

    // Use this for initialization
    void Start ()
    {
        lightColors = new Color[] { Color.cyan, Color.red, Color.magenta};
        clipLenght = clip01.length / 16;
	}

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= clipLenght)
        { 
            for (int k = 0; k <= numLights.Length-1; k++)
            {
                int i = Mathf.RoundToInt(Random.Range(0, 3));
                if (lightColors[i] != numLights[k].GetComponent<Light>().color)
                {
                    numLights[k].GetComponent<Light>().color = lightColors[i];
                }
            }
            timer = 0;
        }
	}
}

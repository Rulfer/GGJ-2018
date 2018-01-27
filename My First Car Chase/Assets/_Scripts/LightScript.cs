using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    public MusicScriptTimed musicScript;
    public Light[] lights;
    private float changeLightInterval;
    private float timer;
    public int switchColor = 0;
    public bool switchLight = true;
    public AudioClip clip01;

    

	// Use this for initialization
	void Start ()
    {
        changeLightInterval = clip01.length / 32;
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        if (timer >= changeLightInterval)
        {
            if (switchColor == 0)
            {
                lights[0].intensity = 5f;
                lights[1].intensity = 2.5f;
                switchLight = false;
                
            }

            else if (switchColor == 1)
            {
                lights[0].intensity = 2.5f;
                lights[1].intensity = 5f;         
            }
            timer = 0;

            if(switchColor == 1)
            {
                switchColor = 0;
            }

            else if (switchColor == 0)
            {
                switchColor = 1;
            }

        }

        //Debug.Log("timer for light to change: " + timer);
		
	}
}

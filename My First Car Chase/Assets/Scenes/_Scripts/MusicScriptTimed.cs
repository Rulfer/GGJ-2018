using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScriptTimed : MonoBehaviour
{
    public AudioSource[] sound;
    public AudioClip clip01;
    private int i = 0;
    public float clipLenght;
    private float timer;
    public float timeModifier;

    // Use this for initialization
    void Start ()
    {
        clipLenght = clip01.length*timeModifier;		
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;

        if (timer >=  clipLenght && i < 4)
        {
            sound[i + 1].mute = false;
            i += 1;
            timer = 0f;
        }		
	}
}

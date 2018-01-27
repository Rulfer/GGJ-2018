using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    private bool coroutineRunningGU = false;
    private bool coroutineRunningGD = false;
    public AudioSource[] sound;
    int i = 0;


    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {/*
        if (Input.GetKeyDown(KeyCode.G))
        {
            sound[0].time = 0.0f;
        }*/

        if (sound[0].time <= 0.01)
        {
            Debug.Log(sound[0].time);
        }
		if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) && i < 4)
        {
            if (coroutineRunningGD)
            {
                StopCoroutine(WaitUntilLoopedGD());
                coroutineRunningGD = false;
            }
            if(!coroutineRunningGU)
            {
                Debug.Log("you should start the coroutine now pls thank");
                StartCoroutine(WaitUntilLoopedGU());
            }

        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) && i > 0)
        {
            if (coroutineRunningGU)
            {
                StopCoroutine(WaitUntilLoopedGU());
                coroutineRunningGU = false;

            }
            if (!coroutineRunningGD)
            {
                StartCoroutine(WaitUntilLoopedGD());
            }
        }
    }

    IEnumerator WaitUntilLoopedGU()
    {
        coroutineRunningGU = true;
        yield return new WaitUntil(() => sound[0].time <= 0.01f);

        sound[i + 1].mute = false;
        i += 1;
        Debug.Log(i + " this is the thing to play");
        coroutineRunningGU = false;
    }

    IEnumerator WaitUntilLoopedGD()
    {
        coroutineRunningGD = true;
        yield return new WaitUntil(() => sound[0].time <= 0.01f);

        sound[i].mute = true;
        i -= 1;
        Debug.Log(i + " this is the thing to play");
        coroutineRunningGD = false;
    }
}
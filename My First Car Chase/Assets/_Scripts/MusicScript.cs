using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    private bool coroutineRunningGU = false;
    private bool coroutineRunningGD = false;
    public AudioSource[] sound;
    public AudioClip clip01;
    
    int i = 0;
    public float startTime;
    public float midTime;
    private float clipLenght;


    // Use this for initialization
    void Start ()
    {
        clipLenght = clip01.length;
        midTime = clipLenght / 2;
	}
	
	// Update is called once per frame
	void Update ()
    {
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
        yield return new WaitUntil(() => sound[0].time <= startTime || (sound[0].time >= midTime - startTime && sound[0].time <= midTime));

        sound[i + 1].mute = false;
        i += 1;
        Debug.Log(i + " this is the thing to play");
        coroutineRunningGU = false;
    }

    IEnumerator WaitUntilLoopedGD()
    {
        coroutineRunningGD = true;
        yield return new WaitUntil(() => sound[0].time <= startTime || (sound[0].time >= midTime - startTime && sound[0].time <= midTime));

        sound[i].mute = true;
        i -= 1;
        Debug.Log(i + " this is the thing to play");
        coroutineRunningGD = false;
    }
}
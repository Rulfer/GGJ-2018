using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText;
    private int points = 0;
    public float timeUntilNewPoint;

    public bool generatePoints = true;

    private void Start()
    {
        StartCoroutine(PointGenerator());
    }

    private IEnumerator PointGenerator()
    {
        yield return new WaitForSeconds(timeUntilNewPoint);

        if (generatePoints)
        {
            points++;
            scoreText.text = points.ToString();
        }

        StartCoroutine(PointGenerator());
    }
}

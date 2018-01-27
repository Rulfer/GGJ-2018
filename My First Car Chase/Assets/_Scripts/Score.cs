using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText;
    private int points = 0;
    public float timeUntilNewPoint;

    public bool generatePoints = true;
    public int scoreMultiplier = 1;

    private void Start()
    {
        StartCoroutine(PointGenerator());
    }

    private IEnumerator PointGenerator()
    {
        yield return new WaitForSeconds(timeUntilNewPoint);

        if (generatePoints)
        {
            points += scoreMultiplier;
            scoreText.text = points.ToString();
        }

        StartCoroutine(PointGenerator());
    }
}

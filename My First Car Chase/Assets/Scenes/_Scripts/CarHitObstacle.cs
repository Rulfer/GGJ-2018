using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CarHitObstacle : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.tag.Equals("obstacle"))
            EndGame();
    }

    public void EndGame()
    {
        Score score = GameObject.FindObjectOfType<Score>();

        string savedScore = PlayerPrefs.GetString("points");
        if (savedScore == "")
        {
            PlayerPrefs.SetString("points", score.scoreText.text);
        }
        else
        {
            int bestScore = int.Parse(savedScore);
            int currentScore = int.Parse(score.scoreText.text);

            if (currentScore > bestScore)
            {
                PlayerPrefs.SetString("points", score.scoreText.text);
            }
        }
        SceneManager.LoadScene(0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetHighscore : MonoBehaviour {

    public Text highscoreText;
	// Use this for initialization
	void Start () {
        string score = PlayerPrefs.GetString("points");
        if (score == "")
            highscoreText.text = "";
        else
            highscoreText.text = "Current highscore: " + score;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MySpawnPoints : MonoBehaviour
{
    public List<Transform> mySpawnPoints = new List<Transform>();
    public List<GameObject> mySpeedSigns = new List<GameObject>();
    public List<Text> mySpeedSignTexts = new List<Text>();
    public GameObject speedWall;
}

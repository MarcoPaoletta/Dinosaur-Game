using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    int score;
    float timer;

    void Update()
    {
        int scorePerSecond = 10;
        timer += Time.deltaTime;
        score = (int)(timer * scorePerSecond);
        gameObject.GetComponent<Text>().text = string.Format("{0:00000}", score);
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public const string HighScoreKey = "HighScore";
    [SerializeField] TMP_Text scoreText;
    [SerializeField] float scoreRatio;
    float score;
   


    void Update()
    {
        score += Time.deltaTime * scoreRatio;
        scoreText.text = Mathf.FloorToInt(score).ToString();
    }

    private void OnDestroy() 
    {
        int currentHighScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        if(score > currentHighScore)
        {
            PlayerPrefs.SetInt(HighScoreKey, Mathf.FloorToInt(score));
        }
    }
}

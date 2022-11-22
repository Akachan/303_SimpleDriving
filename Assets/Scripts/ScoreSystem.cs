using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] float scoreRatio;
    float score;
   


    void Update()
    {
        score += Time.deltaTime * scoreRatio;
        scoreText.text = Mathf.FloorToInt(score).ToString();
    }
}

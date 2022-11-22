using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] TMP_Text highScoreText;
    

    [Header("Energy")]
    [SerializeField] int maxEnergy;
    [SerializeField] int energyRechargeDuration;    //el tiempo que tarda en recargarse 1 energia
    [SerializeField]  TMP_Text energyText;

    int energy;
    const string EnergyKey = "Energy";
    const string EnergyReadyKey = "EnergyReady";


    private void Start()
    {
        HighScore();
        energy = PlayerPrefs.GetInt(EnergyKey, maxEnergy);
        if (energy == 0)
        {
            string energyReadyString = PlayerPrefs.GetString(EnergyReadyKey, string.Empty);
            if(energyReadyString == string.Empty) {return;}

            DateTime energyReadyTime = DateTime.Parse(energyReadyString);
            if(DateTime.Now > energyReadyTime)
            {
                energy = maxEnergy;
                PlayerPrefs.SetInt(EnergyKey, energy);
            }

        }
        energyText.text = $"Play ({energy})";

        
    }

    private void HighScore()
    {
        int highScore = PlayerPrefs.GetInt(ScoreSystem.HighScoreKey, 0);
        highScoreText.text = $"Superame ésta \n {highScore}";
    }

    public void Play()
    {
        if(energy <= 0) {return;}

        energy --;
        PlayerPrefs.SetInt(EnergyKey, energy);

        if(energy <= 0)
        {
            DateTime energyReady = DateTime.Now.AddMinutes(energyRechargeDuration);
            
            PlayerPrefs.SetString(EnergyReadyKey, energyReady.ToString());
        }

      


        SceneManager.LoadScene(1);
    }
}

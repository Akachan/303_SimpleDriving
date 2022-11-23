using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header ("Notifications")]
    [SerializeField] AndroidNotificationHandler androidNotificationHandler;

    [Header("Score")]
    [SerializeField] TMP_Text highScoreText;
    

    [Header("Energy")]
    [SerializeField] int maxEnergy;
    [SerializeField] int energyRechargeDuration;    //el tiempo que tarda en recargarse 1 energia
    [SerializeField] TMP_Text energyText;
    [SerializeField] Button playButton;

    int energy;
    const string EnergyKey = "Energy";
    const string EnergyReadyKey = "EnergyReady";


    private void Start() 
    {
        OnApplicationFocus(true); //para que haga el proceso por primera vez
    }


    private void OnApplicationFocus(bool hasFocus)
    {
        if(!hasFocus) {return;}
        CancelInvoke(nameof(EnergyRecharged)); //Cancelo el Invoke, si es que había


        HighScore();
        SetEnergy();

    }

    private void SetEnergy()
    {
        energy = PlayerPrefs.GetInt(EnergyKey, maxEnergy);
        if (energy == 0)
        {
            string energyReadyString = PlayerPrefs.GetString(EnergyReadyKey, string.Empty);
            if (energyReadyString == string.Empty) { return; }

            DateTime energyReadyTime = DateTime.Parse(energyReadyString);
            if (DateTime.Now > energyReadyTime)
            {
                playButton.interactable = true;
                energy = maxEnergy;
                PlayerPrefs.SetInt(EnergyKey, energy);
            }
            else
            {
                playButton.interactable = false;
                Invoke(nameof(EnergyRecharged) ,(energyReadyTime - DateTime.Now).Seconds);
            }

        }
        energyText.text = $"Play ({energy})";
    }
    void EnergyRecharged()
    {   
        playButton.interactable = true;
        energy = maxEnergy;
        PlayerPrefs.SetInt(EnergyKey, energy);
        energyText.text = $"Play ({energy})";
    }

    private void HighScore()
    {
        int highScore = PlayerPrefs.GetInt(ScoreSystem.HighScoreKey, 0);
        highScoreText.text = $"Superame ésta \n {highScore}";
    }

    public void Play()
    {
        if(energy <1) {return;}

        energy --;
        PlayerPrefs.SetInt(EnergyKey, energy);

        if(energy == 0)
        {
            DateTime energyReady = DateTime.Now.AddMinutes(energyRechargeDuration);
            PlayerPrefs.SetString(EnergyReadyKey, energyReady.ToString());
#if UNITY_ANDROID
            androidNotificationHandler.ScheduleNotification(energyReady);
#endif

        }
        SceneManager.LoadScene(1);
    }


    public void Quit()
    {
        Application.Quit();
    }
    
}

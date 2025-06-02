using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
public UIManager Instance;
public TextMeshProUGUI scoreDisplay;
public Button infoButton;
public GameObject infoText;
public GameManager gameManager;

    private void Awake()
    {
        // if (Instance != null && Instance != this)
        // {
        //     Destroy(gameObject);
        //     return;
        // }
        // Instance = this;
        // DontDestroyOnLoad(gameObject);
    }


    void OnEnable()
    {
        InitializeHighscore();
    }

    public void OnInfoHoverEnter()
    {
        infoText.SetActive(true);
    }

        public void OnInfoHoverExit()
    {
        infoText.SetActive(false);
    }

    public void OnStartPressed()
    {
        gameManager.StartGame();
    }

        void InitializeHighscore()
    {
        
        //Get, set and display highscore
        
        if (PlayerPrefs.HasKey("highScore"))
        {
            Debug.Log("Player Score Exists");
            int highScore = PlayerPrefs.GetInt("HighScore", 0);
            scoreDisplay.text = highScore.ToString();
        }
        else
        {
            Debug.Log("First Time Setup Highscore");
            PlayerPrefs.SetInt("highScore", 0);
            PlayerPrefs.Save();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameState
{
    MainMenu,
    Playing,
    Paused,
    GameOver
}

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public GameState currentState = GameState.MainMenu;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        SoundManager.Play(SoundType.HANGARMUSIC, 0.8f,1,true);
    }



    #region GameStates 


    public void StartGame()
    {
        Debug.Log("StartGame method called");
        currentState = GameState.Playing;
        SceneManager.LoadScene(1);
        SoundManager.Stop(SoundType.HANGARMUSIC);
        SoundManager.Play(SoundType.FLYMUSIC, 0.7f, 1, true);
    }

    public void EndGame()
    {
        SoundManager.Stop(SoundType.NEARMISS);
        SoundManager.Stop(SoundType.WARNING);
        SoundManager.Play(SoundType.DEATH);
        currentState = GameState.GameOver;
        StartCoroutine(GameOverDelay());
    }

        public void EndGameB()
    {
        SoundManager.Stop(SoundType.NEARMISS);
        SoundManager.Stop(SoundType.WARNING);
        SoundManager.Play(SoundType.DEATH2);
        currentState = GameState.GameOver;
        StartCoroutine(GameOverDelay());
    }

    private IEnumerator GameOverDelay()
    {
        yield return new WaitForSeconds(3f);
        ReturnToMainMenu();
    }

    private void ReturnToMainMenu()
    {
        currentState = GameState.MainMenu;
        SceneManager.LoadScene(0);
        SoundManager.Stop(SoundType.FLYMUSIC);
        SoundManager.Stop(SoundType.DEATH);
        SoundManager.Stop(SoundType.DEATH2);
        SoundManager.Play(SoundType.HANGARMUSIC, 0.8f,1,true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void GetCurrentState(GameState gameState)
    {
        return;
    }
    #endregion
}


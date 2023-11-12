using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameManager
{
    public static string EndingNote;
    public static bool IsGameEnd = false;

    public static event Action OnGameStart;
    public static event Action OnGameEnd;

    public static void StartGame()
    {
        IsGameEnd = true;
    }

    public static void EndGame()
    {
        IsGameEnd = false;

        OnGameEnd?.Invoke();

        FadeManager.OnFadeOut += LoadEndingScene;
        FadeManager.Instance.FadeOut();
        //LoadEndingScene();
    }

    public static void LoadEndingScene()
    {
        SceneManager.LoadScene("EndingScene");
    }

    public static void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public static void LoadMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

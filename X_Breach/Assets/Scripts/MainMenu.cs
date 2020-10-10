using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject credits;

    public void NewGame()
    {
        SceneManager.LoadScene("Level01");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ShowCredits()
    {
        if(credits.activeSelf)
            credits.SetActive(false);
        else credits.SetActive(true);
    }
}

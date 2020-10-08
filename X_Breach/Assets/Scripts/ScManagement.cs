using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEditor.SceneManagement;

public class ScManagement : MonoBehaviour
{
    public AudioSource aSrc;
    public void GameOver()
    {
        Scene gameOverScene = SceneManager.GetSceneByName("GameOver");
        SceneManager.LoadScene(gameOverScene.buildIndex);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ScManagement : MonoBehaviour
{
    public void GameOver()
    {
        Scene gameOverScene = SceneManager.GetSceneByName("GameOver");
        SceneManager.LoadScene(gameOverScene.buildIndex);
    }
}

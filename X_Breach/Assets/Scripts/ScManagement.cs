using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ScManagement : MonoBehaviour
{
    Collider2D trigger;
    public Collider2D playerCol;

    void Start()
    {
        trigger = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (trigger.IsTouching(playerCol) &&
            SceneManager.GetActiveScene().name != "Level02")
            SceneManager.LoadScene("Level02");
        else if (trigger.IsTouching(playerCol))
            SceneManager.LoadScene("GameOver");

        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("MainMenu");
    }
}

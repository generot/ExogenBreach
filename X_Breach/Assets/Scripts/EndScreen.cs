using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    public Text msg;

    float duration = 5f;
    int alpha = 0;
         
    void Start()
    {
        //msg.color = new Color(defVal, defVal, defVal, 0);
        //AppearAndFade();
        StartCoroutine(AppearAndFade());
    }

    IEnumerator AppearAndFade()
    {
        msg.CrossFadeAlpha(alpha, duration, true);
        yield return new WaitForSeconds(duration);

        SceneManager.LoadScene("MainMenu");
    }

    void Sleep(float duration)
    {
        while (duration > 0)
            duration -= Time.deltaTime;
    }
}

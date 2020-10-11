using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    public Text msg;

    float duration = 5f, defVal = 255f;
    float alpha = 0f;

    bool isCompleted = true;
         
    void Start()
    {
        msg.color = new Color(defVal, defVal, defVal, 0f);
    }

    void Update()
    {
        if (isCompleted)
        {
            isCompleted = false;
            StartCoroutine(Appear(100f, .15f, alpha < 255f));
            StartCoroutine(Fade());
        }
    }

    IEnumerator Fade()
    {
        yield return new WaitForSeconds(duration + 7f);
        msg.CrossFadeAlpha(0f, duration-2.5f, true);

        yield return new WaitForSeconds(duration + 2f);
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator Appear(float step, float duration, bool comparison)
    {
        while(comparison)
        {
            yield return new WaitForSeconds(duration);
            msg.color = new Color(defVal, defVal, defVal, alpha);
            alpha += Time.deltaTime / step;

            isCompleted = true;
        }
    }
}

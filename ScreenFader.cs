using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;

public class ScreenFader : MonoBehaviour
{
    public enum Mode
    {
        Fade, UnFade
    }
    [SerializeField] private Mode fadeMode;
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadingSpeed;
    [SerializeField] private bool isLoop;
    [Range(0, 1)] private float fadeProgress;

    private void Update()
    {
        var color = fadeImage.color;
        if (fadeMode == Mode.Fade)
        {
            if (isLoop)
            {
                fadeProgress = Mathf.PingPong(Time.time * fadingSpeed, 1);
                fadeImage.CrossFadeAlpha(fadeProgress, fadingSpeed, false);
            }
            else
            {
                if (color.a >= 1)
                {
                    StartCoroutine(ScreenFaded());
                }
                color.a += fadingSpeed * Time.deltaTime;
                fadeImage.color = color;
            }
        }
        else
        {
            color.a -= fadingSpeed * Time.deltaTime;
            fadeImage.color = color;
        }
        
    }

    private IEnumerator ScreenFaded()
    {
        fadeMode = Mode.UnFade;
        yield return new WaitForSeconds(3f);
        var color = fadeImage.color;
        color.a = 0;
        fadeImage.color = color;
        fadeMode = Mode.Fade;
        gameObject.SetActive(false);
    }
}

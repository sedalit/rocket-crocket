using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UICountdownText : MonoBehaviour
{
    public UnityEvent CountDownFinish;
    private Text countdownText;
    private int counter;

    private void Start()
    {
        countdownText = GetComponent<Text>();
        counter = 0;
        Invoke("SetText", 1);
    }

    private void SetText()
    {
        switch (counter)
        {
            case 0:
                SoundManager.Instanse.Play(SoundManager.Instanse.CountdownSound);
                countdownText.text = "3";
                counter++;
                Invoke("SetText", 1);
                break;
            case 1:
                SoundManager.Instanse.Play(SoundManager.Instanse.CountdownSound);
                countdownText.text = "2";
                counter++;
                Invoke("SetText", 1);
                break;
            case 2:
                SoundManager.Instanse.Play(SoundManager.Instanse.CountdownSound);
                countdownText.text = "1";
                counter++;
                Invoke("SetText", 1);
                break;
            case 3:
                SoundManager.Instanse.Play(SoundManager.Instanse.CountdownFinishSound);
                countdownText.color = Color.green;
                countdownText.text = "СТАРТ";
                counter++;
                Invoke("SetText", 1);
                break;
            case 4:
                counter = 0;
                CountDownFinish.Invoke();
                gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }
}

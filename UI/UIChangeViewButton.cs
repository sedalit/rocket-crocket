using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIChangeViewButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Text buttonText;
    private int currentView;

    public void ChangeView()
    {
        switch (currentView)
        {
            case 0:
                CameraController.Instance.ChangeView(currentView);
                currentView = 1;
                break;
            case 1:
                CameraController.Instance.ChangeView(currentView);
                if (CameraController.Instance.IsDisableComponentAfterChange)
                {
                    CameraController.Instance.enabled = true;
                }
                currentView = 0;
                break;
            default:
                break;
        }
        StartCoroutine(DisableButton());
    }

    private IEnumerator DisableButton()
    {
        button.interactable = false;
        yield return new WaitForSeconds(1f);
        button.interactable = true;
    }
}

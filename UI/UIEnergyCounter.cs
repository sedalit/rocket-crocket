using UnityEngine;
using UnityEngine.UI;

public class UIEnergyCounter : MonoBehaviour
{
    [SerializeField] private Text energyText;
    [SerializeField] private Rocket targetRocket;

    private void Start()
    {
        energyText.text = targetRocket.StartEnergy.ToString();
    }
    private void Update()
    {
        energyText.text = Mathf.Round(targetRocket.CurrentEnergy).ToString();
    }
}

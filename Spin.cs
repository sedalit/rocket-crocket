using UnityEngine;

public class Spin : MonoBehaviour
{
    public enum SpinMode
    {
        Manual, Auto
    }
    [SerializeField] private SpinMode spinMode;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Vector3 direction;
    private int inputCounter;
    

    private void Update()
    {
        if (spinMode == SpinMode.Auto)
        {
            transform.Rotate(direction * rotationSpeed * Time.deltaTime);
        }
        if (spinMode == SpinMode.Manual)
        {
            if (Input.GetKey(KeyCode.R))
            {
                transform.Rotate(direction);
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                switch (inputCounter)
                {
                    case 0:
                        direction = new Vector3(0, 1, 0);
                        inputCounter++;
                        break;
                    case 1:
                        direction = new Vector3(0, 0, 1);
                        inputCounter++;
                        break;
                    case 2:
                        direction = new Vector3(1, 0, 0);
                        inputCounter = 0;
                        break;
                    default:
                        break;
                }
            }
        }
        
    }
}

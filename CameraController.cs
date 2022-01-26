using UnityEngine;

public class CameraController : MonoBehaviour
{
   public static CameraController Instance;
    [Header("Main Settings")]
   [SerializeField] private Camera mainCamera;
   [SerializeField] private Transform targetTransform;
   [SerializeField] private float interpolationLinear;
   [SerializeField] private float interpolationAngular;
   [SerializeField] private float cameraOffset;
   [SerializeField] private float forwardOffset;

    [SerializeField] private float changeForwardOffset;
    [SerializeField] private float changeCameraOffset;

    [Header("Points of view")]
    [SerializeField] private Transform firstViewPosition;
    [SerializeField] private Transform secondViewPosition;

    [SerializeField] private bool isDisableComponentAfterChange;

    public bool IsDisableComponentAfterChange => isDisableComponentAfterChange;

    private void Awake()
    {
        Instance = this;
    }

    private void FixedUpdate() {
       if(targetTransform == null || mainCamera == null) return;
       Vector2 camPos = mainCamera.transform.position;
       Vector2 targetPos = targetTransform.position + targetTransform.transform.up * forwardOffset;
       Vector2 newCamPos = Vector2.Lerp(camPos, targetPos, interpolationLinear * Time.deltaTime);
       mainCamera.transform.position = new Vector3(newCamPos.x, newCamPos.y, mainCamera.transform.position.z);
       if(interpolationAngular > 0)
       {
           mainCamera.transform.rotation = Quaternion.Slerp(mainCamera.transform.rotation, targetTransform.rotation, 
                                                                interpolationAngular * Time.deltaTime);
       }
   }

    public void ChangeView(int view)
    {
        switch (view)
        {
            case 0: // Общий вид на уровень
                transform.position = firstViewPosition.position;
                if (isDisableComponentAfterChange)
                {
                    enabled = false;
                    break;
                }
                cameraOffset = 2;
                forwardOffset = 30;
                break;
            case 1: // Приближенный к кораблю вид
                transform.position = secondViewPosition.position;
                forwardOffset = 10;
                break;

            default:
                break;
        }
    }

   public void SetTarget(Transform newTarget)
   {
       targetTransform = newTarget;
   }
}

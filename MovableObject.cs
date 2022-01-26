using UnityEngine;

[DisallowMultipleComponent]
public class MovableObject : MonoBehaviour
{
    [SerializeField] private Vector3 moveDirection;
    [SerializeField] private float movementSpeed;
    [Range(0,1)] private float moveProgress;
    private Vector3 defaultPosition;

    private void Start()
    {
        defaultPosition = transform.position;
    }

    private void Update()
    {
        moveProgress = Mathf.PingPong(Time.time * movementSpeed, 1);
        Vector3 offset = moveDirection * moveProgress;
        transform.position = defaultPosition + offset;
    }
}

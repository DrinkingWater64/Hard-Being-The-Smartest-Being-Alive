using UnityEngine;

public class SmoothCameraTilt : MonoBehaviour
{
    public float tiltSpeed = 1f;
    public float maxTiltAngle = 10f;

    private Quaternion initialRotation;
    private Quaternion targetRotation;

    private void Start()
    {
        initialRotation = transform.rotation;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse Y");

        Quaternion tiltRotation = Quaternion.Euler(0f, 0f, -mouseX * maxTiltAngle);

        targetRotation = Quaternion.Lerp(transform.rotation, tiltRotation, tiltSpeed * Time.deltaTime);

        transform.rotation = targetRotation;
    }
}

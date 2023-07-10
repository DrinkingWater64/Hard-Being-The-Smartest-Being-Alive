//Vector3(-21.7999992, 13.6999998, -7.19999981)
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    public Transform player;
    public float smoothSpeed = 0.125f;
    [SerializeField]
    private Vector3 offset = new Vector3(-8.79f, 13.69f, -7.199f);

    private void Update()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}

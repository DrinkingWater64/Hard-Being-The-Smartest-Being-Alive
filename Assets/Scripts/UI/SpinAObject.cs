using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAObject : MonoBehaviour
{
    public Vector3 spinAxis = Vector3.up;
    public float spinSpeed = 90f;
    public float bounceHeight = 0.5f;
    public float bounceSpeed = 1f;

    private float startY;

    private void Start()
    {
        startY = transform.position.y;
    }

    private void Update()
    {
        transform.Rotate(spinAxis, spinSpeed * Time.deltaTime);

        float bounceOffset = Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;

        Vector3 newPosition = transform.position;
        newPosition.y = startY + bounceOffset;
        transform.position = newPosition;
    }
}

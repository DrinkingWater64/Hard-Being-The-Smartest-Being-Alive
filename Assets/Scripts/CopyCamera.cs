using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyCamera : MonoBehaviour
{
    public Transform mainCamera;
    public Vector3 offset;

    private void Update()
    {
        // Update the position of the follower camera based on the main camera's position
        transform.position = mainCamera.position + offset;

        // Match the rotation of the main camera
        transform.rotation = mainCamera.rotation;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variant : MonoBehaviour
{
    public Vector3 worldOffset = Vector3.zero;
    public Camera _camera;
    public bool isLinked = true;
    public float maxHp = 100;
    public float hp = 100;
    public DisplaySystem displaySystem;



    private void Start()
    {
        displaySystem = GameObject.Find("displaySystem").GetComponent<DisplaySystem>();
    }

    private void Update()
    {
        if (hp <= 0)
        {
            HandleDeath();
        }
    }
    public void TakeDamage(float damage)
    {
        if (hp - damage < 0) {
            hp = 0;
        }
        else
        {
            hp -= damage;
        }
    }

    public void HealSelf(float health) 
    {
        hp += health;
    }

    public void HandleDeath()
    {
        //gameObject.SetActive(false);
        isLinked = false;
        if (_camera != null )
        {
            if (displaySystem.IsCameraInCameras(_camera)){
                _camera.gameObject.SetActive(false);
                displaySystem.RemoveFromCameraList(_camera);
            }
        }
    }
}

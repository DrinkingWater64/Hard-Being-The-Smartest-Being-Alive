using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("KillSelf", 1.8f);
    }
    
    private void KIllSelf()
    {
        Destroy(gameObject);
    }

}

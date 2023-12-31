using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField]
    private GameObject originGameObject;
    public Vector3 worldOffset;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    public void SetOriginObject(GameObject originObject) { 
       originGameObject = originObject;
    }
    // Update is called once per frame
    void Update()
    {
        if (originGameObject.GetComponent<Variant>().isLinked == true)
        {
            transform.position = originGameObject.transform.position - worldOffset;
            transform.rotation = originGameObject.transform.rotation;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Variant>().TakeDamage(200);
        }
    }
}

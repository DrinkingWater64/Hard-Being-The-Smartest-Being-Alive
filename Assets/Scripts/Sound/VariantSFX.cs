using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariantSFX : MonoBehaviour
{    [SerializeField] GameObject parent;
    [SerializeField] ButtonSFX deathSound;
    bool isDead = false;

    // Start is called before the first frame update
    // Update is called once per frame
    private void Update()
    {
        if (parent.GetComponent<Variant>().hp <= 0)
        {
            if (isDead == false)
            {
                Instantiate(deathSound, parent.transform);
                isDead = true;
            }
        }
    }
}

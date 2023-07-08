using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameGud : MonoBehaviour
{
    [SerializeField]
    private Variant mainVariant;
    [SerializeField]
    private Image playerHp;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        playerHp.fillAmount = mainVariant.hp / mainVariant.maxHp;
    }
}

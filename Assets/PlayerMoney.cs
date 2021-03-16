using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMoney : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI moneyUi;
    public int playerMoney;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(playerMoney);
        moneyUi.SetText(playerMoney + "$");
    }
}

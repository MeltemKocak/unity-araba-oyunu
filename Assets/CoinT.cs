using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinT : MonoBehaviour
{

    public Text cointext;
    public static int coAmount;
    void Start()
    {
        cointext = GetComponent<Text>();
    }

    void Update()
    {
        cointext.text = coAmount.ToString();
    }
}

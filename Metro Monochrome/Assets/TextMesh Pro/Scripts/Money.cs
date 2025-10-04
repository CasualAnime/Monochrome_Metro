using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Money : MonoBehaviour
{
    public GameObject money;
    public TextMeshProUGUI moneyAmount;


    public void SetValue(int amount)
    {
        moneyAmount.text = amount.ToString();
    }
}

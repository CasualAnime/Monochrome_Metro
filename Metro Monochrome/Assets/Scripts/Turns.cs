using UnityEngine;
using TMPro;

public class Turns : MonoBehaviour
{
    [SerializeField] GameObject turns;
    [SerializeField] TextMeshProUGUI turnsText;

    public void SetValue(int amount)
    {
        turnsText.text = amount.ToString();
    }
}

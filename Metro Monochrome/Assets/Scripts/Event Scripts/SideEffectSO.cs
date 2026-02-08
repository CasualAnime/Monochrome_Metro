using UnityEngine;

[CreateAssetMenu(fileName = "new Side Effect", menuName = "Side Effects")]
public class SideEffectSO : ScriptableObject
{
    public string outcomeText; //appears on the button

    // Stat Changes
    public int staminaChange, moneyChange, movesChange = -1;

    public int probability;

    public EventSO[] nextEvent;
}

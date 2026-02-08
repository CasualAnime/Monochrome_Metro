using UnityEngine;

[CreateAssetMenu(fileName = "new Choice", menuName = "Choices")]
public class ChoiceData : ScriptableObject
{
    public string choiceText; //appears on the button

    // Stat Changes
    public int staminaChange, moneyChange, movesChange = -1;
    public string outcomeText;

    public SideEffectSO[] sideEffectList;

    public EventSO[] nextEvent;
}

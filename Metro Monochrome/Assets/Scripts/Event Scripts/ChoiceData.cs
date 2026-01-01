using UnityEngine;

[CreateAssetMenu(fileName = "new Choice", menuName = "Choices")]
public class ChoiceData : ScriptableObject
{
    public string choiceText; //appears on the button

    // Stat Changes
    public int staminaChange, moneyChange, movesChange = -1;

    //Short Feedback
    public string outcomeText;
    public string[] randomOutcomeText;
    public int[] newStaminaChange, newMoneyChange, newMovesChange;

    public EventSO[] nextEvent;
}

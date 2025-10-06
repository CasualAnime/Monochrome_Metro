using UnityEngine;

[CreateAssetMenu(menuName = "Event")]
public class StatChangeEvent : Event
{
    [SerializeField] int movesCost = 1, moneyChange = 0, staminaChange = 0, moneyCapacity = 0, staminaCapacity = 0;

    public override void Apply(GameManager gameManager)
    {
        gameManager.UpdateStats(movesCost, moneyChange, staminaChange, moneyCapacity, staminaCapacity);
    }
}

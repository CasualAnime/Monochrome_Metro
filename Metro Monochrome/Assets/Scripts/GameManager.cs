using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public PlayerController playerController;


    public void UpdateCurrentStats(int movesCost, int moneyChange, int staminaChange)
    {
        if (playerController != null)
        {
            // change money
            playerController.ManipulateMoney(moneyChange);
            Debug.Log("Changed money by " + moneyChange.ToString());
            
            // change stamina
            playerController.ManipulateStamina(staminaChange);
            Debug.Log("Changed stamina by " + staminaChange.ToString());
            
            // change moves
            playerController.ManipulateMoves(movesCost);
            Debug.Log("Changed moves by " + movesCost.ToString());
        }

    }

    public void UpdateMaxStats(int moneyCapacity, int staminaCapacity)
    {
        playerController.ManipulateMaxMoney(moneyCapacity);
        playerController.ManipulateMaxStamina(staminaCapacity);

    }
}

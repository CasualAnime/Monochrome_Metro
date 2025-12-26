using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public PlayerController playerController;

    void Start()
    {
        
    }


    public void UpdateStats(int movesCost, int moneyChange, int staminaChange, int moneyCapacity, int staminaCapacity)
    {
        if (playerController != null)
        {
            // change money and maxMoney
            playerController.ManipulateMoney(moneyChange);
            playerController.ManipulateMaxMoney(moneyCapacity);

            // change stamina and maxStamina
            playerController.ManipulateStamina(staminaChange);
            playerController.ManipulateMaxStamina(staminaCapacity);

            // change moves
            playerController.ManipulateMoves(movesCost);
        }

    }
}

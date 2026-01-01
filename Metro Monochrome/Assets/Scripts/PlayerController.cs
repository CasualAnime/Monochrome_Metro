using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Stamina
    public StaminaBar stamina;
    [SerializeField] int maxStamina = 100, currentStamina, cappedStamina = 200;

    // Money
    public Money money;
    [SerializeField] int currentMoney, maxMoney = 2000, cappedMoney = 10000;

    // Moves
    public Turns turns;
    [SerializeField] int movesRemaining;

    void Start()
    {
        currentStamina = 100;
        stamina.SetValue(currentStamina);

        currentMoney = 100;
        money.SetValue(currentMoney, maxMoney);
    }


    void Update()
    {
        Test();
    }

    public bool CheckStats()
    {
        if (currentStamina <= 0 || movesRemaining <= 0)
        {
            Debug.Log("Game Over");
            return true;
        }

        return false;
    }


    // Gain and Lose Stamina
    public void ManipulateStamina(int amountGained)
    {
        currentStamina += amountGained;

        // check if currentStamina goes over maxStamina
        if (currentStamina > maxStamina)
        {
            // for now, prevents overflow; in the future, maybe allow overflow but gives a 
            // status as well? 
            currentStamina = maxStamina;
        }

        else if (currentStamina < 0)
        {
            currentStamina = 0;
        }

        stamina.SetValue(currentStamina);
    }

    // Raise and Lower Stamina Cap
    public void ManipulateMaxStamina(int amountGained)
    {
        maxStamina += amountGained;

        // capped out at this amount
        if (maxStamina > cappedStamina)
        {
            maxStamina = cappedStamina;
        }

        // stamina can't go below a certain value
        else if (maxStamina < 50)
        {
            maxStamina = 50;
        }

        // if at max stamina and then lowers the cap, set currentStamina = new maxStamina
        if (currentStamina > maxStamina)
        {
            currentStamina = maxStamina;
            stamina.SetValue(currentStamina);
        }

        stamina.ManipulateMaxValue(maxStamina);
    }


    // Gain and Lose Money
    public void ManipulateMoney(int moneyGained)
    {
        currentMoney += moneyGained;
        if (currentMoney > maxMoney)
        {
            currentMoney = maxMoney;
        }

        // if the player is in debt, gain broke status

        money.SetValue(currentMoney, maxMoney);
    }


    // Raise and Lower Max Money
    public void ManipulateMaxMoney(int amount)
    {
        maxMoney += amount;
        if (maxMoney > cappedMoney)
        {
            maxMoney = cappedMoney;
        }

        else if (maxMoney < 100)
        {
            maxMoney = 100;
        }

        money.SetValue(currentMoney, maxMoney);
    }

    public void ManipulateMoves(int amount)
    {
        movesRemaining += amount;

        turns.SetValue(movesRemaining);
    }

    private void Test()
    {
        // Testing Stamina
        if (Input.GetKeyDown(KeyCode.U))
        {
            ManipulateStamina(25);
            ManipulateMoney(50);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            ManipulateStamina(-25);
            ManipulateMoney(-50);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            ManipulateMaxStamina(50);
            ManipulateMaxMoney(1000);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            ManipulateMaxStamina(-50);
            ManipulateMaxMoney(-1000);
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            ManipulateMoves(-1);
        }
    }
    
}

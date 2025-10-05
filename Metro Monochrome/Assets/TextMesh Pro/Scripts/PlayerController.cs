using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Stamina
    public StaminaBar stamina;
    public int maxStamina = 100, currentStamina, cappedStamina = 200;

    // Money
    public Money money;
    public int currentMoney, maxMoney = 2000, cappedMoney = 10000;

    void Start()
    {
        currentStamina = 100;
        stamina.SetValue(currentStamina);

        currentMoney = 100;
        money.SetValue(currentMoney, maxMoney);
    }


    void Update()
    {
        // Testing Stamina
        if (Input.GetKeyDown(KeyCode.U))
        {
            GainStamina(25);
            GainMoney(50);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            LoseStamina(25);
            LoseMoney(50);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            RaiseMaxStamina(50);
            RaiseMaxMoney(1000);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            LowerMaxStamina(50);
            LowerMaxMoney(1000);
        }
    }

    // Lose Stamina
    public void LoseStamina(int amountLost)
    {
        currentStamina -= amountLost;
        if (currentStamina < 0)
        {
            currentStamina = 0;
        }

        stamina.SetValue(currentStamina);
    }

    // Gain Stamina
    public void GainStamina(int amountGained)
    {
        currentStamina += amountGained;

        // check if currentStamina goes over maxStamina
        if (currentStamina > maxStamina)
        {
            // for now, prevents overflow; in the future, maybe allow overflow but gives a 
            // status as well? 
            currentStamina = maxStamina;
        }

        stamina.SetValue(currentStamina);
    }

    // Raise Stamina Cap
    public void RaiseMaxStamina(int amountGained)
    {
        maxStamina += amountGained;

        // capped out at this amount
        if (maxStamina > cappedStamina)
        {
            maxStamina = cappedStamina;
        }

        stamina.ManipulateMaxValue(maxStamina);
    }

    // Lowers Stamina Cap
    public void LowerMaxStamina(int amountLost)
    {
        maxStamina -= amountLost;

        // stamina can't go below a certain value
        if (maxStamina < 50)
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

    // Lose Time

    // Gain Time

    // Gain Money
    public void GainMoney(int moneyGained)
    {
        currentMoney += moneyGained;
        if (currentMoney > maxMoney)
        {
            currentMoney = maxMoney;
        }

        money.SetValue(currentMoney, maxMoney);
    }

    // Lose Money
    public void LoseMoney(int moneyLost)
    {
        currentMoney -= moneyLost; // allow for the player to be in debt

        // if the player is in debt, gain broke status

        money.SetValue(currentMoney, maxMoney);
    }

    public void RaiseMaxMoney(int amount)
    {
        maxMoney += amount;
        if (maxMoney > cappedMoney)
        {
            maxMoney = cappedMoney;
        }

        money.SetValue(currentMoney, maxMoney);
    }
    
    public void LowerMaxMoney(int amount)
    {
        maxMoney -= amount;
        if (maxMoney < 100)
        {
            maxMoney = 100;
        }

        money.SetValue(currentMoney, maxMoney);
    }
}

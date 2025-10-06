using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public PlayerController playerController;
    public List<GameObject> allGameEvents; // assign prefabs here
    public List<Button> choiceButtons; // 3 or more UI buttons for choice
    public Text descriptionText; // UI Text box for description

    private List<GameObject> currentChoices = new List<GameObject>();

    void Start()
    {
        ShowRandomChoices();
    }

    public void ShowRandomChoices()
    {
        // clear current choices
        currentChoices.Clear();

        // get 3 random unique events
        List<GameObject> pool = new List<GameObject>(allGameEvents);
        for (int i = 0; i < 3 && pool.Count > 0; i++)
        {
            int index = Random.Range(0, pool.Count);
            currentChoices.Add(pool[index]);
            pool.RemoveAt(index);
        }

        // assign to buttons
        for (int i = 0; i < choiceButtons.Count; i++)
        {
            
        }
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

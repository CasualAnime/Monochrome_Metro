using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public PlayerController playerController;
    public EventDisplay eventDisplay;
    
    private bool isGameOver = false;

    [SerializeField] EventSO[] eventList;
    private EventSO currentEvent;

    void Start()
    {
        RandomizeEvent();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) RandomizeEvent();

        EndGame();
    }

    private void EndGame()
    {
        isGameOver = playerController.CheckStats();
        if (isGameOver)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

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

    private void RandomizeEvent()
    {
        // get random index to choose a random event from the eventList
        int randomIndex = Random.Range(0, eventList.Length);
        Debug.Log(randomIndex);
        currentEvent = eventList[randomIndex];

        // Display random event
        eventDisplay.SetCurrentEvent(currentEvent);
    }

    private void RandomizeEvent(ChoiceData currentChoice)
    {
        // get random index
        Debug.Log("Next Event Length: " + currentChoice.nextEvent.Length.ToString());
        int randomNumber = Random.Range(0, currentChoice.nextEvent.Length);

        // get random event based off of index
        Debug.Log("Random Number: " + randomNumber.ToString());
        currentEvent = currentChoice.nextEvent[randomNumber];

        // display random event
        eventDisplay.SetCurrentEvent(currentEvent);
    }

    public void ResolveChoice(ChoiceData currentChoice)
    {
        // display text
        DisplayText(currentChoice.outcomeText);

        // Get stats before random outcome
        int movesCost = currentChoice.movesChange;
        int moneyCost = currentChoice.moneyChange;
        int staminaCost = currentChoice.staminaChange;

        UpdateCurrentStats(movesCost, moneyCost, staminaCost);

        // Do Random Outcome afterwards
        //UpdateRandomChoice(currentChoice);

        // get random event based off choice
        RandomizeEvent(currentChoice);
    }

    private void DisplayText(string outcomeText)
    {
        // Get text
        Debug.Log("Choice applied");
        Debug.Log(outcomeText);
    }

    private void UpdateRandomChoice(ChoiceData currentChoice)
    {
        //Check if there is a random outcome
        if (currentChoice.randomOutcomeText.Length == 0) return;

        int randomOutcomeProbability = Random.Range(0, 100);

        int randomNumber = Random.Range(0, currentChoice.randomOutcomeText.Length);
        Debug.Log(randomNumber.ToString());

        // Get the random outcome text
        string randomOutcome = currentChoice.randomOutcomeText[randomNumber];
        Debug.Log(randomOutcome);

        // Get the random outcome's stat change
        int movesCost = currentChoice.newMovesChange[randomNumber];
        int moneyCost = currentChoice.newMoneyChange[randomNumber];
        int staminaCost = currentChoice.newStaminaChange[randomNumber];

        UpdateCurrentStats(movesCost, moneyCost, staminaCost);
    }

}

using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public PlayerController playerController;
    public EventDisplay eventDisplay;
    
    private bool isGameOver = false;
    private int isGameWon = 0;

    [SerializeField] EventSO[] eventList;
    private EventSO currentEvent, previousEvent;

    void Start()
    {
        RandomizeEvent();
    }

    void Update()
    {
        // testing
        if (Input.GetKeyDown(KeyCode.R)) RandomizeEvent();
        if (Input.GetKeyDown(KeyCode.T)) ResetGame();

        EndGame();
    }

    private void EndGame()
    {
        isGameOver = playerController.CheckStats();
        isGameWon = playerController.CheckWin();

        if (isGameOver)
        {
            PlayerPrefs.SetInt("Win?", isGameWon);
            PlayerPrefs.Save();

            SceneManager.LoadScene("GameOver");
        }
    }

    public void UpdateCurrentStats(int movesCost, int moneyChange, int staminaChange)
    {
        if (playerController != null)
        {
            // change money
            playerController.ManipulateMoney(moneyChange);
            //Debug.Log("Changed money by " + moneyChange.ToString());
            
            // change stamina
            playerController.ManipulateStamina(staminaChange);
            //Debug.Log("Changed stamina by " + staminaChange.ToString());
            
            // change moves
            playerController.ManipulateMoves(movesCost);
            //Debug.Log("Changed moves by " + movesCost.ToString());
        }

    }

    public void UpdateMaxStats(int moneyCapacity, int staminaCapacity)
    {
        playerController.ManipulateMaxMoney(moneyCapacity);
        playerController.ManipulateMaxStamina(staminaCapacity);

    }

    // randomly selects an event
    private void RandomizeEvent()
    {
        // track seen events
        previousEvent = currentEvent;
        Debug.Log("Previous Event: " + previousEvent);

        // get random index to choose a random event from the eventList
        int randomIndex = Random.Range(0, eventList.Length);
        Debug.Log(randomIndex);
        currentEvent = eventList[randomIndex];
        Debug.Log("Current Event: " + currentEvent);

         // Avoid immediate repeat events
        if (currentEvent == previousEvent)
        {
            while (currentEvent == previousEvent)
            {
                randomIndex = Random.Range(0, eventList.Length);
                currentEvent = eventList[randomIndex];
                Debug.Log("Current Event: " + currentEvent);
            }
        }

        // Display random event
        eventDisplay.SetCurrentEvent(currentEvent);
    }

    // randomly select an event based off of a choice
    private void RandomizeEvent(ChoiceData currentChoice)
    {
        // track seen events
        previousEvent = currentEvent;
        Debug.Log("Previous Event: " + previousEvent);

        // get random index
        int randomNumber = Random.Range(0, currentChoice.nextEvent.Length);

        // get random event based off of index
        Debug.Log("Random Number: " + randomNumber.ToString());
        currentEvent = currentChoice.nextEvent[randomNumber];
        Debug.Log("Current Event: " + currentEvent);

        // Avoid immediate repeat events
        if (currentEvent == previousEvent)
        {
            while (currentEvent == previousEvent)
            {
                randomNumber = Random.Range(0, currentChoice.nextEvent.Length);
                currentEvent = currentChoice.nextEvent[randomNumber];
                Debug.Log("Current Event: " + currentEvent);
            }
        }

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
        UpdateRandomChoice(currentChoice);

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
        Debug.Log
        (
            $"OutcomeText: {currentChoice.randomOutcomeText.Length}, " +
            $"Prob: {currentChoice.probability.Length}, " +
            $"Moves: {currentChoice.newMovesChange.Length}, " +
            $"Money: {currentChoice.newMoneyChange.Length}, " +
            $"Stamina: {currentChoice.newStaminaChange.Length}"
        );


        //Check if there is a random outcome
        if (currentChoice.randomOutcomeText.Length == 0) return;

        // Get random outcome and a random number 
        int randomOutcomeProbability = Random.Range(0, 100);
        int randomNumber = Random.Range(0, currentChoice.randomOutcomeText.Length);
        Debug.Log(randomOutcomeProbability.ToString());

        // check if the random number falls outside of the random outcome's ocurrence probability
        if (randomOutcomeProbability > currentChoice.probability[randomNumber]) return;

        // Get the random outcome text
        string randomOutcome = currentChoice.randomOutcomeText[randomNumber];
        Debug.Log(randomOutcome);

        // Get the random outcome's stat change
        int movesCost = currentChoice.newMovesChange[randomNumber];
        int moneyCost = currentChoice.newMoneyChange[randomNumber];
        int staminaCost = currentChoice.newStaminaChange[randomNumber];

        UpdateCurrentStats(movesCost, moneyCost, staminaCost);
    }

    private void ResetGame()
    {
        SceneManager.LoadScene("Main");
    }

}

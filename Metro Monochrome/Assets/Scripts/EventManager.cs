using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour
{
    public GameManager gameManager;

    public EventDisplay eventDisplay;

    [SerializeField] EventSO[] eventList;
    private EventSO currentEvent, previousEvent;

    private bool sideEffect_nextEvent = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RandomizeEvent();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) RandomizeEvent();
    }

    // randomly selects an event
    private void RandomizeEvent()
    {       
        // track seen events
        previousEvent = currentEvent;

        // get random index to choose a random event from the eventList
        int randomIndex = Random.Range(0, eventList.Length);

        currentEvent = eventList[randomIndex];

        // Avoid immediate repeat events 
        while (currentEvent == previousEvent)
        {
            randomIndex = Random.Range(0, eventList.Length);
            currentEvent = eventList[randomIndex];

        }
        
        // Display random event
        eventDisplay.SetCurrentEvent(currentEvent);
    }

    // randomly select an event based off of a choice
    private void RandomizeEvent(ChoiceData currentChoice)
    {
        // track seen events
        previousEvent = currentEvent;

        // get random index
        int randomNumber = Random.Range(0, currentChoice.nextEvent.Length);

        // get random event based off of index
        currentEvent = currentChoice.nextEvent[randomNumber];
  
        // Avoid immediate repeat events
        while (currentEvent == previousEvent)
        {
            randomNumber = Random.Range(0, currentChoice.nextEvent.Length);
            currentEvent = currentChoice.nextEvent[randomNumber];
            //Debug.Log("Current Event: " + currentEvent);
        }

        // display random event
        eventDisplay.SetCurrentEvent(currentEvent);
    }

    private void RandomizeEvent(SideEffectSO sideEffect)
    {
        Debug.Log("Side Effect -> Next Event");
        sideEffect_nextEvent = true;

        // track seen event
        previousEvent = currentEvent;
        //Debug.Log("Previous Event: " + previousEvent);

        // get random index
        int randomNumber = Random.Range(0, sideEffect.nextEvent.Length);

        // get random event based off of index
        currentEvent = sideEffect.nextEvent[randomNumber];
        //Debug.Log(currentEvent);

        // display random event
        eventDisplay.SetCurrentEvent(currentEvent);

    }

    private void UpdateRandomChoice(ChoiceData currentChoice)
    {
        //Check if there is a random outcome
        if (currentChoice.sideEffectList.Length == 0) return;

        // Get random outcome and a random number 
        int randomOutcomeProbability = Random.Range(0, 100);
        int randomNumber = Random.Range(0, currentChoice.sideEffectList.Length);
        SideEffectSO sideEffect = currentChoice.sideEffectList[randomNumber];

        // check if the random number falls outside of the random outcome's ocurrence probability
        Debug.Log
        (
            $"Side Effect: {sideEffect}, " +
            $"OutcomeText: {sideEffect.outcomeText}, " +
            $"Prob: {sideEffect.probability}, " +
            $"Achieved: {!(randomOutcomeProbability > sideEffect.probability)}, " +
            $"Moves: {sideEffect.movesChange}, " +
            $"Money: {sideEffect.moneyChange}, " +
            $"Stamina: {sideEffect.staminaChange}"
        );

        if (randomOutcomeProbability > sideEffect.probability) return;

        // Get the random outcome text
        string randomOutcome = sideEffect.outcomeText;
        Debug.Log(randomOutcome);

        // Get the random outcome's stat change
        int movesCost = sideEffect.movesChange;
        int moneyCost = sideEffect.moneyChange;
        int staminaCost = sideEffect.staminaChange;

        gameManager.UpdateCurrentStats(movesCost, moneyCost, staminaCost);

        if (sideEffect.nextEvent.Length != 0) 
        {
            RandomizeEvent(sideEffect);
        }
    }

    public void ResolveChoice(ChoiceData currentChoice)
    {
        sideEffect_nextEvent = false;

        // Get stats before random outcome
        int movesCost = currentChoice.movesChange;
        int moneyCost = currentChoice.moneyChange;
        int staminaCost = currentChoice.staminaChange;

        gameManager.UpdateCurrentStats(movesCost, moneyCost, staminaCost);

        // Do Random Outcome afterwards
        UpdateRandomChoice(currentChoice);

        if (sideEffect_nextEvent == false)
            RandomizeEvent(currentChoice);
    }

    
}

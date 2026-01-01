using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using System.Threading;

public class EventDisplay : MonoBehaviour
{
    [SerializeField] EventSO currentEvent;
    [SerializeField] GameManager manager;

    [SerializeField] GameObject choicePrefab;
    [SerializeField] Transform menuTransform; 
    private ChoiceData[] choiceList;

    private int movesCost, moneyCost, staminaCost;

    void Start()
    {
        CreateEvent();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateChoices(int index)
    {
        if (choiceList.Length == 0) 
        {
            Debug.Log("No Choices");
            return;
        }
        ChoiceData currentChoice = choiceList[index];

        // Get text
        Debug.Log("Choice applied");
        Debug.Log(currentChoice.outcomeText);

        // Get stats before random outcome
        movesCost = currentChoice.movesChange;
        moneyCost = currentChoice.moneyChange;
        staminaCost = currentChoice.staminaChange;

        manager.UpdateCurrentStats(movesCost, moneyCost, staminaCost);

        NextEvent(currentChoice);
        // Do Random Outcome afterwards
        //UpdateRandomChoice(currentChoice);

    }

    private void NextEvent(ChoiceData currentChoice)
    {
        // reset current event
        ResetCurrentEvent();

        // go to next event
        Debug.Log("Next Event Length: " + currentChoice.nextEvent.Length.ToString());
        int randomNumber = Random.Range(0, currentChoice.nextEvent.Length);
        Debug.Log("Random Number: " + randomNumber.ToString());
        currentEvent = currentChoice.nextEvent[randomNumber];

        CreateEvent();
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
        movesCost = currentChoice.newMovesChange[randomNumber];
        moneyCost = currentChoice.newMoneyChange[randomNumber];
        staminaCost = currentChoice.newStaminaChange[randomNumber];

        manager.UpdateCurrentStats(movesCost, moneyCost, staminaCost);
    }

    private void CreateEvent()
    {
        Debug.Log(currentEvent.situation);
        choiceList = currentEvent.choices;
        CreateChoices();
    }

    private void CreateChoices()
    {
        foreach (ChoiceData choice in choiceList)
        {
            GameObject newChoice = Instantiate(choicePrefab);
            newChoice.transform.SetParent(menuTransform, false); 

            newChoice.GetComponentInChildren<TMP_Text>().text = choice.choiceText;
        }
    }

    private void ResetCurrentEvent()
    {
        foreach (Transform child in menuTransform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}

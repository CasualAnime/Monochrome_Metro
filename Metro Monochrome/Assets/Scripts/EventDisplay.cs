using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using System.Threading;

public class EventDisplay : MonoBehaviour
{
    private EventSO currentEvent;
    public EventManager manager;

    [SerializeField] GameObject choicePrefab;
    [SerializeField] Transform menuTransform; 
    private ChoiceData[] choiceList;

    // refactor this into manager script
    public void OnChoiceSelected(int index)
    {
        if (choiceList.Length == 0) 
        {
            Debug.Log("No Choices");
            return;
        }
        ChoiceData currentChoice = choiceList[index];

        // send currentChoice to manager to apply stats and other logic
        manager.ResolveChoice(currentChoice);
    }

    private void CreateEvent()
    {
        Debug.Log(currentEvent.situation);
        choiceList = currentEvent.choices;
        CreateChoices();
    }

    // creates the buttons for each choice 
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

    public void SetCurrentEvent(EventSO newEvent)
    {
        currentEvent = newEvent;
        ResetCurrentEvent();
        CreateEvent();
    }


}

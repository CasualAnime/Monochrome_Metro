using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TMPro.EditorUtilities;

public class EventDisplay : MonoBehaviour
{
    [SerializeField] EventSO currentEvent;

    [SerializeField] GameObject choicePrefab;
    [SerializeField] Transform menuTransform; 
    private ChoiceData[] choiceList;

    void Start()
    {
        Debug.Log(currentEvent.situation);
        choiceList = currentEvent.choices;
        CreateChoices();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateChoices(GameObject button)
    {
        
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
}

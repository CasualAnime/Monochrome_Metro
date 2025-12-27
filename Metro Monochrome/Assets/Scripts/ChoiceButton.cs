using UnityEngine;

public class ChoiceButton : MonoBehaviour
{
    [SerializeField] EventDisplay eventDisplay;
    private int index;

    void Start()
    {
        eventDisplay = GetComponentInParent<EventDisplay>();
    }

    public void OnClick()
    {
        index = gameObject.transform.GetSiblingIndex();
        Debug.Log(index);
        eventDisplay.UpdateChoices(index);
    }
}

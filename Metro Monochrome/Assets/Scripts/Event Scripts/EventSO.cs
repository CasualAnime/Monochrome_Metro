using UnityEngine;

[CreateAssetMenu(fileName = "genericEvent", menuName = "Event")]
public class EventSO : ScriptableObject
{
    public string situation;

    public ChoiceData[] choices;

}

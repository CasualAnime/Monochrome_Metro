using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

// [System.Serializable]
// public class Choice
// {
//     public string choiceText, outcomeText;

//     public Event consequence; 
// }

public abstract class Event : ScriptableObject
{
    //[TextArea(3, 10)] // makes the textbox bigger in the inspection window for description
    //public string scenarioText;
    //public List<Choice> choices;

    public abstract void Apply(GameManager gameManager);

}

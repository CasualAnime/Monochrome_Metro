using UnityEngine;

public class ChoiceButton : MonoBehaviour
{
    private int index;

    public void OnClick()
    {
        index = gameObject.transform.GetSiblingIndex();
        Debug.Log(index);
    }
}

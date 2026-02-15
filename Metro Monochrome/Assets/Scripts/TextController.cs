using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textBox;

    public enum TextBoxStates
    {
        Shown,
        Hidden
    }

    public TextBoxStates state;

    void Start()
    {
        Hide(); 
    }

    public void Show()
    {
        gameObject.SetActive(true);
        state = TextBoxStates.Shown;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        state = TextBoxStates.Hidden;
    }

    public void DisplayText(string outcomeText)
    {
        // display text
        textBox.text = outcomeText;
    }
 
    IEnumerator DisplayText(string text, float waitTime)
    {
        Show();
        DisplayText(text);

        yield return new WaitForSeconds(waitTime);

       // StartCoroutine(ResetText(waitTime));
    }

    IEnumerator ResetText(float waitTime)
    {
        DisplayText(null);
        Hide();

        yield return new WaitForSeconds(waitTime);
    }

}

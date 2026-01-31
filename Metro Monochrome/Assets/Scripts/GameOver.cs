using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI GameOverText;

    private int winNumber;

    void Start()
    {
        winNumber = PlayerPrefs.GetInt("Win?");
        UpdateText(winNumber);
    }

    private void UpdateText(int winNumber)
    {
        if (winNumber == 1)
        {
            GameOverText.text = "You Win!";
        }
        else
        {
            GameOverText.text = "You Lose!";
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Main");
    }
}

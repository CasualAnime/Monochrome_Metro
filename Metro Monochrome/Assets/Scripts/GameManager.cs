using System.Collections.Generic;
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public EventManager eventManager;
    
    public PlayerController playerController;
    public TextController textController;
    
    private bool isGameOver = false;
    private int isGameWon = 0;
    [SerializeField] float waitTime = 5f;

    void Start()
    {
        //eventManager.RandomizeEvent();
    }

    void Update()
    {
        // testing
        
        if (Input.GetKeyDown(KeyCode.T)) ResetGame();

        //if (Input.GetKeyDown(KeyCode.R)) eventManager.RandomizeEvent();

        if (Input.GetKeyDown(KeyCode.H) && textController.state == TextController.TextBoxStates.Shown) textController.Hide();
        else if (Input.GetKeyDown(KeyCode.H) && textController.state == TextController.TextBoxStates.Hidden) textController.Show();

        EndGame();
    }

    private void EndGame()
    {
        isGameOver = playerController.CheckStats();
        isGameWon = playerController.CheckWin();

        if (isGameOver)
        {
            PlayerPrefs.SetInt("Win?", isGameWon);
            PlayerPrefs.Save();

            SceneManager.LoadScene("GameOver");
        }
    }

    public void UpdateCurrentStats(int movesCost, int moneyChange, int staminaChange)
    {
        if (playerController != null)
        {
            // change money
            playerController.ManipulateMoney(moneyChange);
            //Debug.Log("Changed money by " + moneyChange.ToString());
            
            // change stamina
            playerController.ManipulateStamina(staminaChange);
            //Debug.Log("Changed stamina by " + staminaChange.ToString());
            
            // change moves
            playerController.ManipulateMoves(movesCost);
            //Debug.Log("Changed moves by " + movesCost.ToString());
        }

    }

    public void UpdateMaxStats(int moneyCapacity, int staminaCapacity)
    {
        playerController.ManipulateMaxMoney(moneyCapacity);
        playerController.ManipulateMaxStamina(staminaCapacity);

    }

    private void ResetGame()
    {
        SceneManager.LoadScene("Main");
    }

}

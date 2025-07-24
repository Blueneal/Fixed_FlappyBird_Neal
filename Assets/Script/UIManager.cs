using UnityEngine;
using TMPro;


public class UIManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public GameObject titleScreen;
    public GameObject readyScreen;
    public GameObject gameOverScreen;
    public GameObject scoreUI;

    /// <summary>
    /// Increases the score that shows on screen by passing an int
    /// </summary>
    /// <param name="score"></param>
    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    /// <summary>
    /// Activates the title screen and deactivates the other screens 
    /// </summary>
    public void ShowStart()
    {
        titleScreen.SetActive(true);
        readyScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        scoreUI.SetActive(false);
    }

    /// <summary>
    /// Hides the title screen
    /// </summary>
    public void HideStart()
    {
        titleScreen.SetActive(false);
    }

    /// <summary>
    /// Activates the ready screen and deactivates the other screens after the player hits start
    /// </summary>
    public void ShowReady()
    {
        titleScreen.SetActive(false);
        readyScreen.SetActive(true);
        gameOverScreen.SetActive(false);
    }

    /// <summary>
    /// Hides the ready screen and activates the score UI
    /// </summary>
    public void HideReady()
    {
        readyScreen.SetActive(false);
        scoreUI.SetActive(true);
    }

    /// <summary>
    /// Activates the game over screen when the player dies
    /// </summary>
    public void ShowGameOver()
    {
        gameOverScreen.SetActive(true);
    }
}

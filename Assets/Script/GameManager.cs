using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Bird bird;
    public PipeSpawner pipeSpawner;
    public UIManager uiManager;
    public AudioSource audioSource;
    public AudioClip menuAudio;
    public AudioClip scoreAudio;
    public AudioClip hitAudio;
    public AudioClip deathAudio;

    private int score = 0;

    void Awake()
    {
        Instance = this;
        pipeSpawner.enabled = false;
    }

    void Start()
    {
        uiManager.ShowStart();
        bird.gameObject.SetActive(false);
    }

    /// <summary>
    /// Resets the game by placing the bird back at the starting position, and resetting the score and UI.
    /// Also sends the player back to start menu and unfreezes the time scale
    /// </summary>
    public void ResetGame()
    {
        audioSource.clip = menuAudio;
        audioSource.Play();
        Pipe[] pipes = FindObjectsByType<Pipe>(FindObjectsSortMode.None);
        foreach(Pipe pipe in pipes)
        {
            Destroy(pipe.gameObject);
        }
        score = 0;
        uiManager.UpdateScore(score);

        uiManager.ShowStart();
        pipeSpawner.enabled = false;
        bird.ResetBird();
        bird.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    /// <summary>
    /// Switches the UI on screen from the Title screen to the Get Ready screen and puts the bird into position
    /// Plays menu sound when player clicks
    /// </summary>
    public void ReadyGame()
    {
        audioSource.clip = menuAudio;
        audioSource.Play();
        uiManager.ShowReady();
        bird.ResetBird();
        bird.gameObject.SetActive(true);
    }

    /// <summary>
    /// Hides the Get Ready Screen and tells the bird.cs to start the game and let the player control the bird
    /// Plays menu sound when player clicks
    /// </summary>
    public void StartGame()
    {
        audioSource.clip = menuAudio;
        audioSource.Play();
        score = 0;
        uiManager.HideReady();
        pipeSpawner.enabled = true;
        bird.StartGame();
    }

    /// <summary>
    /// Ends the game when the player is hit by pipe. Freezes game and pulls up the game over screen with game over audio
    /// </summary>
    public void GameOver()
    {
        audioSource.clip = deathAudio;
        audioSource.Play();
        Time.timeScale = 0f;
        uiManager.ShowGameOver();
    }

    /// <summary>
    /// tells the uiManager script to increase the score by 1 when the player passes through a pipe and plays score audio
    /// </summary>
    public void IncreaseScore()
    {
        audioSource.clip = scoreAudio;
        audioSource.Play();
        score++;
        uiManager.UpdateScore(score);
    }
}

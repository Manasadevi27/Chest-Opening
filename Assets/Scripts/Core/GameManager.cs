using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Game State")]
    public GameState currentState = GameState.MainMenu;

    [Header("Difficulty")]
    [SerializeField]
    private LevelDifficulty defaultDifficulty = LevelDifficulty.Beginner;

    [Header("References")]
    public ScoreManager scoreManager;
    public MissCounter missCounter;
    public ChestMovement playerMovement;

    public LevelDifficulty CurrentDifficulty { get; private set; }
    public float GameTime { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        CurrentDifficulty = defaultDifficulty;
        GameTime = 0f;
    }

    private void Update()
    {
        if (currentState == GameState.Playing)
        {
            GameTime += Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && currentState == GameState.Playing)
        {
            PauseGame();
        }
    }

    public void SetDifficulty(int levelIndex)
    {
        CurrentDifficulty = levelIndex switch
        {
            0 => LevelDifficulty.Beginner,
            1 => LevelDifficulty.Intermediate,
            2 => LevelDifficulty.Difficult,
            _ => LevelDifficulty.Beginner,
        };
    }

    public void StartGame()
    {
        currentState = GameState.Playing;
        GameTime = 0f;
        Time.timeScale = 1f;
        GameEvents.GameStart();
    }

    public void GameOver()
    {
        if (currentState == GameState.GameOver)
            return;

        currentState = GameState.GameOver;

        if (playerMovement != null)
            playerMovement.enabled = false;

        scoreManager?.SaveHighScore();
        AudioManager.Instance?.PlayGameOver();
        GameEvents.GameOver();

        Time.timeScale = 0f;
    }

    public void PauseGame()
    {
        currentState = GameState.Paused;
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        currentState = GameState.Playing;
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        GameTime = 0f;
        Time.timeScale = 1f;
        int index = SceneManager.GetActiveScene().buildIndex;
        if (Instance == this)
            Instance = null;
        Destroy(gameObject);
        SceneManager.LoadScene(index);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RegisterTreasureCollected(int scoreValue)
    {
        scoreManager?.AddTreasureScore(scoreValue);
        AudioManager.Instance?.PlayTreasureCollect();
        GameEvents.TreasureCollected(scoreManager != null ? scoreManager.TreasuresCollected : 0);
    }

    public void RegisterTreasureMissed()
    {
        missCounter?.RegisterMiss();
        scoreManager?.BreakStreak();

        if (missCounter != null && missCounter.IsGameOver)
        {
            GameOver();
        }
    }
}

public enum GameState
{
    MainMenu,
    Playing,
    Paused,
    GameOver,
    LevelSelect,
}

public enum LevelDifficulty
{
    Beginner,
    Intermediate,
    Difficult,
}

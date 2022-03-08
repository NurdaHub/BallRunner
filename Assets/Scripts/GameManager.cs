using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public SpawnManager spawnManager;
    public SpeedUpManager speedUpManager;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Time.timeScale = 0;
    }

    public void Play()
    {
        Time.timeScale = 1;
        UIManager.Instance.eventDetectorGO.SetActive(true);
        PlayerController.Instance.liveManager.ResetLive();
        PlayerController.Instance.pointCalculator.ResetPoints();
    }

    public void GameOver()
    {
        spawnManager.DeactivateAllPools();
        speedUpManager.ResetSpeed();
        Time.timeScale = 0;
        UIManager.Instance.OnGameOver();
        PlayerController.Instance.canMove = false;
    }
}

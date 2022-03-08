using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    
    public TextMeshProUGUI liveValueText;
    public TextMeshProUGUI pointsValueText;
    public GameObject playButton;
    public GameObject gameOverText;
    public GameObject eventDetectorGO;

    private void Awake()
    {
        Instance = this;
    }

    public void SetLiveValue(string value)
    {
        liveValueText.text = value;
    }

    public void SetPointsValue(string value)
    {
        pointsValueText.text = value;
    }

    public void OnGameOver()
    {
        eventDetectorGO.SetActive(false);
        gameOverText.SetActive(true);
        playButton.SetActive(true);
    }
}

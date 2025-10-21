using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject introPanel;
    [SerializeField] private GameObject hudPanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;

    [Header("Intro")]
    [SerializeField] private Button startButton;

    [Header("HUD")]
    [SerializeField] private TextMeshProUGUI collectedText;

    [Header("End")]
    [SerializeField] private TextMeshProUGUI winText;
    [SerializeField] private TextMeshProUGUI loseText;
    [SerializeField] private Button restartButtonWin;
    [SerializeField] private Button restartButtonLose;

    void Awake()
    {
        if (startButton != null)
        {
            startButton.onClick.RemoveAllListeners();
            startButton.onClick.AddListener(() => GameManager.Instance.StartGame());
        }
        if (restartButtonWin != null)
        {
            restartButtonWin.onClick.RemoveAllListeners();
            restartButtonWin.onClick.AddListener(() => GameManager.Instance.Restart());
        }
        if (restartButtonLose != null)
        {
            restartButtonLose.onClick.RemoveAllListeners();
            restartButtonLose.onClick.AddListener(() => GameManager.Instance.Restart());
        }
    }

    public void InitIntroAndHud(int current, int total)
    {
        UpdateHUD(current, total);
    }

    public void UpdateHUD(int current, int total)
    {
        if (collectedText != null)
            collectedText.text = $"Collected: {current} / {total}";
    }

    public void SetWinText(int collected, int total)
    {
        if (winText != null) winText.text = $"You Won! \nCollected: {collected} / {total}";
    }

    public void SetLoseText(int collected, int total)
    {
        if (loseText != null) loseText.text = $"Youre a Loser! \nCollected: {collected} / {total}";
    }

    public void ShowIntro(bool show) { if (introPanel) introPanel.SetActive(show); }
    public void ShowHUD(bool show) { if (hudPanel) hudPanel.SetActive(show); }
    public void ShowWin(bool show) { if (winPanel) winPanel.SetActive(show); }
    public void ShowLose(bool show) { if (losePanel) losePanel.SetActive(show); }
}

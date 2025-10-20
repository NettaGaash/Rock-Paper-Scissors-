using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private UIManager ui;

    [Header("Collectibles")]
    [SerializeField] private int totalCollectibles = -1;
    public int CollectedCount { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
    }

    void Start()
    {
        if (totalCollectibles < 0)
        {
            totalCollectibles = FindObjectsByType<Collectible>(
                FindObjectsInactive.Include,
                FindObjectsSortMode.None
            ).Length;
        }

        CollectedCount = 0;
        ui.InitIntroAndHud(CollectedCount, totalCollectibles);

        ui.ShowIntro(true);
        ui.ShowHUD(false);
        ui.ShowWin(false);
        ui.ShowLose(false);
    }

    public void StartGame()
    {
        ui.ShowIntro(false);
        ui.ShowHUD(true);
    }

    public void IncrementCollectibles()
    {
        CollectedCount++;
        ui.UpdateHUD(CollectedCount, totalCollectibles);
    }

    public void WinGame()
    {
        ui.ShowHUD(false);
        ui.SetWinText(CollectedCount, totalCollectibles);
        ui.ShowWin(true);
    }

    public void LoseGame()
    {
        ui.ShowHUD(false);
        ui.SetLoseText(CollectedCount, totalCollectibles);
        ui.ShowLose(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

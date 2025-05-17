using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject gameWinPanel;

    private void Start()
    {
        GlobalEvents.GameOver.AddListener(ShowGameOverPanel);
        GlobalEvents.GameWin.AddListener(ShowGameWinPanel);
        GlobalEvents.RestartGame.AddListener(RestartGame);
    }

    private void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    private void ShowGameWinPanel()
    {
        gameWinPanel.SetActive(true);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}

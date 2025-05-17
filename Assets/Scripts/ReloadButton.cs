using UnityEngine;
using UnityEngine.UI;

public class ReloadButton : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Refresh);
        GlobalEvents.GameOver.AddListener(GameOver);
        GlobalEvents.GameWin.AddListener(GameOver);
    }

    private void Refresh()
    {
        GlobalEvents.RefreshItems.Invoke();
    }

    private void GameOver()
    {
        button.onClick.RemoveAllListeners();
    }
}

using UnityEngine;
using UnityEngine.UI;

public class ReloadButton : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Refresh);
        GlobalEvents.GameOver.AddListener(Deactivate);
        GlobalEvents.GameWin.AddListener(Deactivate);
        GlobalEvents.StartGenerateItems.AddListener(Deactivate);
        GlobalEvents.EndGenerateItems.AddListener(Activate);
    }

    private void Refresh()
    {
        GlobalEvents.RefreshItems.Invoke();
    }

    private void Deactivate()
    {
        button.onClick.RemoveAllListeners();
    }

    private void Activate()
    {
        button.onClick.AddListener(Refresh);
    }
}

using UnityEngine;
using UnityEngine.UI;

public class ReloadButton : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Refresh);
    }

    private void Refresh()
    {
        GlobalEvents.RefreshItems.Invoke();
    }
}

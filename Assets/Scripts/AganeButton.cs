using UnityEngine;
using UnityEngine.UI;

public class AganeButton : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(RestartGame);
    }

    private void RestartGame()
    {
        GlobalEvents.RestartGame.Invoke();
    }
}

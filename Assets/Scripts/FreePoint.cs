using UnityEngine;

public class FreePoint: MonoBehaviour
{
    private bool isFree = true;
    public bool IsFree => isFree;

    private void Start()
    {
        GlobalEvents.RefreshItems.AddListener(SetFree);
    }

    public void SetFree()
    {
        isFree = true;
    }

    public bool SetBusy()
    {
        if (isFree == true)
        {
            isFree = false;
            return true;
        }
        return false;
    }
}

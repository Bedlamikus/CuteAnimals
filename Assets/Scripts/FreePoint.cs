using UnityEngine;

public class FreePoint: MonoBehaviour
{
    private bool isFree = true;
    public bool IsFree => isFree;

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

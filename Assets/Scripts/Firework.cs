using UnityEngine;

public class Firework : MonoBehaviour
{
    private ParticleSystem particle;

    private void Start()
    {
        particle = GetComponent<ParticleSystem>();

        GlobalEvents.GameWin.AddListener(Show);
    }

    private void Show()
    {
        particle.Play();
    }
}

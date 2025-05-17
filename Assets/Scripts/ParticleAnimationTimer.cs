using System.Collections;
using UnityEngine;

public class ParticleAnimationTimer : MonoBehaviour
{
    [SerializeField] private float animationTime = 1.1f;
    [SerializeField] private ParticleSystem particle;

    private void OnEnable()
    {
        particle.Play();
        StartCoroutine(HideTimer());
    }

    private IEnumerator HideTimer()
    {
        yield return new WaitForSeconds(animationTime);

        particle.Stop();
        gameObject.SetActive(false);
    }
}

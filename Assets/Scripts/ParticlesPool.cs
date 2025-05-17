using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesPool : MonoBehaviour
{
    [SerializeField] private GameObject particlesPrefab;
    [SerializeField] private int presetCount = 5;

    private List<GameObject> particles = new();

    private void Start()
    {
        GlobalEvents.PlayParticles.AddListener(PlayParticles);

        for (int i = 0; i < presetCount; i++) 
        {
            CreateItem();
        }
    }

    private GameObject CreateItem()
    {
        var result = Instantiate(particlesPrefab);
        result.SetActive(false);
        particles.Add(result);
        return result;
    }

    public GameObject GetParticle()
    {
        foreach (var item in particles)
        {
            if (item.activeSelf == false)
            {
                return item;
            }
        }
        return CreateItem();
    }

    private void PlayParticles(Vector3 position)
    {
        var particle = GetParticle();
        particle.transform.position = position;
        particle.SetActive(true);
    }
}

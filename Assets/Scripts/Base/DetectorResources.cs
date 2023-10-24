using System.Collections;
using System.Collections.Generic;
using UnityEditor.iOS;
using UnityEngine;
using UnityEngine.Events;

public class DetectorResources : MonoBehaviour
{
    [SerializeField] private float _duration;

    public event UnityAction<Resource[]> ResourcesPositionsFound;

    private void Start()
    {
        StartCoroutine(ResourceSearch());
    }

    private IEnumerator ResourceSearch()
    {
        var wait = new WaitForSeconds(_duration);

        while (enabled)
        {
            Resource[] resources = FindObjectsOfType<Resource>();

            ResourcesPositionsFound?.Invoke(resources);

            yield return wait;
        }
    }
}

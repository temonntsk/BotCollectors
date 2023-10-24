using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Resource _resourcePrefabs;
    [SerializeField] private float _secondsBetweenSpawn;

    private Transform[] _spawnPoints;

    private void Start()
    {
        FillSpawnPoints();
        StartCoroutine(SpawnResources());
    }



    private IEnumerator SpawnResources()
    {
        var wait = new WaitForSeconds(_secondsBetweenSpawn);

        while (enabled)
        {
            int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
            Instantiate(_resourcePrefabs, _spawnPoints[spawnPointNumber].transform.position,Quaternion.identity);

            yield return wait;
        }
    }

    private void FillSpawnPoints()
    {
        _spawnPoints = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
            _spawnPoints[i] = transform.GetChild(i);
    }
}

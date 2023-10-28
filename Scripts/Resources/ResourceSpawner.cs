using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class ResourceSpawner : MonoBehaviour
{
    [SerializeField] private Resource _prefab;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private List<ResourceCell> _cells = new List<ResourceCell>();

    private Random _random = new Random();
    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_secondsBetweenSpawn < _timer)
        {
            Spawn();
            _timer = 0f;
        }
    }

    private void Spawn()
    {
        ResourceCell cell = GetRandomCell();

        if (cell == null)
        {
            return;
        }

        Resource resource = Instantiate(_prefab, cell.transform.position, Quaternion.identity);
        cell.SetResource(resource);
    }

    private ResourceCell GetRandomCell()
    {
        List<ResourceCell> tempCells = new List<ResourceCell>();

        foreach (var cell in _cells)
        {
            if (cell.IsEmpty)
            {
                tempCells.Add(cell);
            }
        }

        if (tempCells.Count == 0)
        {
            return null;
        }

        return tempCells[_random.Next(tempCells.Count)];
    }
}

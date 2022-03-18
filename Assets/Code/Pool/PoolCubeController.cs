using System.Collections.Generic;
using UnityEngine;

public class PoolCubeController 
{
    public List<CubeView> Pool;
    public static PoolCubeController Instance;
    private GameObject _cubePrefab;
    private Transform _parent;
    private int _startSize;

    public PoolCubeController(GameObject prefab, Transform parent)
    {
        Instance = this;
        _cubePrefab = prefab;
        _parent = parent;
        _startSize = 10;

        Start();
    }

    private void Start()
    {
        Pool = new List<CubeView>();

        for(int i = 0; i < _startSize; i++)
        {
            var cube = GameObject.Instantiate(_cubePrefab, _parent).GetComponent<CubeView>();
            cube.gameObject.SetActive(false);
            Pool.Add(cube);
        }
    }

    public void Add()
    {
        var cube = GameObject.Instantiate(_cubePrefab, _parent).GetComponent<CubeView>();
        Pool.Add(cube);
    }
}

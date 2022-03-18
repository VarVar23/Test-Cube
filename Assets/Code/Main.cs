using UnityEngine;

public class Main : MonoBehaviour
{
    [Header("Views")]
    [SerializeField] private InputDataView _inputDataView;


    [Header("Prefabs")]
    [SerializeField] private GameObject _prefabCube;
    [SerializeField] private Transform _parent;


    #region "Controllers"

    private PoolCubeController _poolCubeController;
    private CubeMoveController _cubeMoveController;
    private CubeFinishController _cubeFinishDistance;
    private CubeSpawnController _spawnController;

    #endregion


    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        _poolCubeController = new PoolCubeController(_prefabCube, _parent);
        _cubeMoveController = new CubeMoveController(_inputDataView);
        _cubeFinishDistance = new CubeFinishController(_inputDataView);
        _spawnController = new CubeSpawnController(_inputDataView);
    }

    private void FixedUpdate()
    {
        _cubeMoveController?.FixedUpdate();
        _cubeFinishDistance?.FixedUpdate();
    }
}

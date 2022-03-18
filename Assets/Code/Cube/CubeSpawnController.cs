using System.Threading.Tasks;
using UnityEngine;

public class CubeSpawnController 
{
    private InputDataView _inputDataView;
    private int _time = 5000;

    public CubeSpawnController(InputDataView inputDataView)
    {
        _inputDataView = inputDataView;

        Subscribe();
        StartSpawn();
    }

    private void Subscribe() => _inputDataView.TimeSpawn.onValueChanged.AddListener(ChangeTime);

    private void ChangeTime(string text)
    {
        _time = int.Parse(text) * 100;

        if(_time == 0)
        {
            _time = 5000;
        }
    }

    private async void StartSpawn()
    {
        while(true)
        {
            Spawn();
            await Task.Delay(_time);
        }
    }

    private void Spawn()
    {
        foreach(var cube in PoolCubeController.Instance.Pool)
        {
            if (!cube) return;

            if(!cube.gameObject.activeSelf)
            {
                cube.gameObject.SetActive(true);
                return;
            }
        }

        PoolCubeController.Instance.Add();
    }
}

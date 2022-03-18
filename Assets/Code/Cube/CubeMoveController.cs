using UnityEngine;

public class CubeMoveController
{
    private InputDataView _inputDataView;
    private float _speed = 0.1f;

    public CubeMoveController(InputDataView inputDataView)
    {
        _inputDataView = inputDataView;

        Subscribe();
    }

    private void Subscribe() => _inputDataView.Speed.onValueChanged.AddListener(ChangeSpeed);


    private void ChangeSpeed(string text)
    {
        _speed = float.Parse(text);
        _speed /= 10;
    }

    public void FixedUpdate()
    {
        foreach(var cube in PoolCubeController.Instance.Pool)
        {
            if (!cube.gameObject.activeSelf) continue;

            cube.transform.Translate(Vector3.forward * _speed);
        }
    }
}

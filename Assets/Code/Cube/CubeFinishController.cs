using UnityEngine;

public class CubeFinishController 
{
    private InputDataView _inputDataView;
    private float _distance = 100;

    public CubeFinishController(InputDataView inputDataView)
    {
        _inputDataView = inputDataView;

        Subscribe();
    }

    private void Subscribe() => _inputDataView.Distance.onValueChanged.AddListener(ChangeDistance);

    private void ChangeDistance(string text)
    {
        _distance = float.Parse(text);
    }

    public void FixedUpdate()
    {
        foreach (var cube in PoolCubeController.Instance.Pool)
        {
            if (!cube.gameObject.activeSelf) continue;

            if (cube.transform.position.z > _distance)
            {
                cube.gameObject.SetActive(false);
                cube.transform.position = Vector3.zero;
            }
        }
    }
}

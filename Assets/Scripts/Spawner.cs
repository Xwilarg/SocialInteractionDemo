using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _prefabs;

    private float _refTimer = 3f;
    private float _timer;

    private void Start()
    {
        _timer = _refTimer;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0f)
        {
            var random = _prefabs[Random.Range(0, _prefabs.Length)];
            Instantiate(random, transform.position, Quaternion.identity).transform.parent = transform;
            _timer = _refTimer;
        }
    }
}

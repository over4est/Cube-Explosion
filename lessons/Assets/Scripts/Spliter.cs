using System.Collections.Generic;
using UnityEngine;

public class Spliter : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private CubeDetector _cubeDetector;
    [SerializeField] private Exploder _exploder;

    private float _minSpawnAmount = 2f;
    private float _maxSpawnAmount = 6f;
    private float _reductionFactor = 0.5f;
    private List<Rigidbody> _cubeCopyes = new List<Rigidbody>();

    private void Update()
    {
        if (_inputReader.GetMousePressed && _cubeDetector.TryGetCube(out Cube cube))
        {
            Split(cube, _cubeCopyes);
            _exploder.Explode(_cubeCopyes);
        }
    }

    private void Split(Cube original, List<Rigidbody> rigidbodies)
    {
        float splitAmount = Random.Range(_minSpawnAmount, _maxSpawnAmount);
        _cubeCopyes = new List<Rigidbody>();

        Destroy(original.gameObject);

        if (Random.value <= original.SplitChance)
        {
            for (int i = 0; i < splitAmount; i++)
            {
                var clone = Instantiate(original, original.transform.position, Quaternion.identity);
                clone.transform.localScale = original.transform.localScale * _reductionFactor;
                clone.ReduceSplitChance(original.SplitChance, _reductionFactor);

                rigidbodies.Add(clone.GetComponent<Rigidbody>());
            }
        }
    }
}

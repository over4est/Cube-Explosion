using System.Collections.Generic;
using UnityEngine;

public class Spliter : MonoBehaviour
{
    [SerializeField] private CubeSpawner _spawner;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private CubeDetector _cubeDetector;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private TargetsFinder _targetsFinder;

    private float _minSpawnAmount = 2f;
    private float _maxSpawnAmount = 6f;
    private float _splitFactor = 0.5f;
    private float _scaleFactor = 0.5f;
    private float _explosionFactor = 2f;

    private void OnEnable()
    {
        _inputReader.LeftMouseButtonPressed += Split;
    }

    private void OnDisable()
    {
        _inputReader.LeftMouseButtonPressed -= Split;
    }

    private void Split()
    {
        if (_cubeDetector.TryGetCube(out Cube original) == false)
        {
            return;
        }

        List<Rigidbody> copyRigidbodies = new List<Rigidbody>();
        float splitAmount = Random.Range(_minSpawnAmount, _maxSpawnAmount);

        if (Random.value <= original.SplitChance)
        {
            for (int i = 0; i < splitAmount; i++)
            {
                Cube copy = _spawner.Spawn(original, _scaleFactor, _splitFactor, _explosionFactor);

                copyRigidbodies.Add(copy.Rigidbody);
            }

            _exploder.Explode(copyRigidbodies);
        }
        else
        {
            List<Rigidbody> targets = _targetsFinder.GetExplodableObject(original);

            _exploder.Explode(original, targets);
        }

        Destroy(original.gameObject);
    }
}

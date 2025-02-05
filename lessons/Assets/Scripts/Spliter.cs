using System.Collections.Generic;
using UnityEngine;

public class Spliter : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private CubeDetector _cubeDetector;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private TargetsFinder _targetsFinder;

    private float _minSpawnAmount = 2f;
    private float _maxSpawnAmount = 6f;
    private float _reductionFactor = 0.5f;
    private float _increasmentFactor = 2f;

    private void Update()
    {
        if (_inputReader.GetMousePressed && _cubeDetector.TryGetCube(out Cube cube))
        {
            Split(cube);
        }
    }

    private void Split(Cube original)
    {
        float splitAmount = Random.Range(_minSpawnAmount, _maxSpawnAmount);

        Destroy(original.gameObject);

        if (Random.value <= original.SplitChance)
        {
            for (int i = 0; i < splitAmount; i++)
            {
                var clone = Instantiate(original, original.transform.position, Quaternion.identity);
                clone.transform.localScale = original.transform.localScale * _reductionFactor;

                clone.ReduceSplitChance(original, _reductionFactor);
                clone.IncreaseExplosionEffect(original, _increasmentFactor);
            }
        }
        else
        {
            List<Rigidbody> targets = _targetsFinder.GetExplodableObject(original);

            _exploder.Explode(original, targets);
        }
    }
}

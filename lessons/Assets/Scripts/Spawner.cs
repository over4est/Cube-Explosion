using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float _minSpawnAmount = 2f;
    private float _maxSpawnAmount = 6f;
    private float _reductionFactor = 0.5f;

    public void Spawn(Cube original ,List<Rigidbody> rigidbodies)
    {
        float splitAmount = Random.Range(_minSpawnAmount, _maxSpawnAmount);

        for (int i = 0; i < splitAmount; i++)
        {
            var clone = Instantiate(original, original.transform.position, Quaternion.identity);
            clone.transform.localScale = original.transform.localScale * _reductionFactor;
            clone.ReduceSplitChance(original.SplitChance, _reductionFactor);

            rigidbodies.Add(clone.GetComponent<Rigidbody>());
        }
    }
}

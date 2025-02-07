using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public Cube Spawn(Cube original, float scaleFactor, float splitFactor, float explosionFactor)
    {
        var clone = Instantiate(original, original.transform.position, Quaternion.identity);
        clone.transform.localScale = original.transform.localScale * scaleFactor;

        clone.ReduceSplitChance(original.SplitChance, splitFactor);
        clone.IncreaseExplosionEffect(original.ExplosionPower, original.ExlosionRadius, explosionFactor);

        return clone;
    }
}

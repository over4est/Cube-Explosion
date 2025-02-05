using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public Cube Spawn(Cube original, float scaleFactor, float splitFactor, float explosionFactor)
    {
        var clone = Instantiate(original, original.transform.position, Quaternion.identity);
        clone.transform.localScale = original.transform.localScale * scaleFactor;

        clone.ReduceSplitChance(original, splitFactor);
        clone.IncreaseExplosionEffect(original, explosionFactor);

        return clone;
    }
}

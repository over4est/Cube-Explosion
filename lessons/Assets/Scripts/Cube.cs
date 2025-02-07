using UnityEngine;

public class Cube : MonoBehaviour
{
    public float SplitChance { get; private set; } = 1;
    public float ExplosionPower { get; private set; } = 100;
    public float ExlosionRadius { get; private set; } = 10;

    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    public void ReduceSplitChance(float originalSplitChance, float reductionFactor)
    {
        SplitChance = originalSplitChance * reductionFactor;
    }

    public void IncreaseExplosionEffect(float originalPower, float originalRadius, float increasmentFactor)
    {
        ExplosionPower = originalPower * increasmentFactor;
        ExlosionRadius = originalRadius * increasmentFactor;
    }
}

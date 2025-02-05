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

    public void ReduceSplitChance(Cube original, float reductionFactor)
    {
        SplitChance = original.SplitChance * reductionFactor;
    }

    public void IncreaseExplosionEffect(Cube original, float increasmentFactor)
    {
        ExplosionPower = original.ExplosionPower * increasmentFactor;
        ExlosionRadius = original.ExlosionRadius * increasmentFactor;
    }
}

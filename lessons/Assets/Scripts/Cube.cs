using UnityEngine;

public class Cube : MonoBehaviour
{
    public float SplitChance { get; private set; } = 1;

    public void ReduceSplitChance(float originalChance, float reductionFactor)
    {
        SplitChance = originalChance * reductionFactor;
    }
}

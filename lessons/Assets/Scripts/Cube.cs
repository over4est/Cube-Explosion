using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;

    private Cube _cube;
    private List<Rigidbody> _copyes = new List<Rigidbody>();

    public float SplitChance { get; private set; } = 1;

    private void Awake()
    {
        _cube = GetComponent<Cube>();
        Material material = GetComponent<MeshRenderer>().material;
        material.color = Random.ColorHSV();
    }

    private void OnMouseUpAsButton()
    {
        Destroy(gameObject);

        if (Random.value <= SplitChance)
        {
            _spawner.Spawn(_cube, _copyes);
            _exploder.Explode(_copyes);
        }
    }

    public void ReduceSplitChance(float originalChance, float reductionFactor)
    {
        SplitChance = originalChance * reductionFactor;
    }
}

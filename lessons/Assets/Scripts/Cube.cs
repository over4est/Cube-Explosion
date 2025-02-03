using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    private float _minSpawnAmount = 2f;
    private float _maxSpawnAmount = 6f;
    private float _reductionFactor = 0.5f;
    private List<Rigidbody> _copyes = new List<Rigidbody>();

    private void Awake()
    {
        Material material = GetComponent<MeshRenderer>().material;
        material.color = Random.ColorHSV();
    }

    private void OnMouseUpAsButton()
    {
        Destroy(gameObject);

        if (Random.value <= transform.localScale.x)
        {
            SplitUp();
            Explode();
        }
    }

    private void Explode()
    {
        foreach (var rigidbody in _copyes)
        {
            rigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }

    private void SplitUp()
    {
        for (int i = 0; i < Random.Range(_maxSpawnAmount, _minSpawnAmount); i++)
        {
            var clone = Instantiate(_prefab);

            clone.transform.localScale = transform.localScale * _reductionFactor;

            _copyes.Add(clone.GetComponent<Rigidbody>());
        }
    }
}

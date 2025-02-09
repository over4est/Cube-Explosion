using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    private float _explosionPower = 100f;
    private float _explosionRadius = 20f;

    public void Explode(Cube cube, List<Rigidbody> rigidbodies)
    {
        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.AddExplosionForce(cube.ExplosionPower, cube.transform.position, cube.ExlosionRadius);
        }
    }

    public void Explode(List<Rigidbody> copyes)
    {
        foreach (Rigidbody rigidbody in copyes)
        {
            rigidbody.AddExplosionForce(_explosionPower, rigidbody.transform.position, _explosionRadius);
        }
    }
}

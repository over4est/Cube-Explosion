using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    public void Explode(Cube cube, List<Rigidbody> rigidbodies)
    {
        foreach (var rigidbody in rigidbodies)
        {
            rigidbody.AddExplosionForce(cube.ExplosionPower, cube.transform.position, cube.ExlosionRadius);
        }
    }
}

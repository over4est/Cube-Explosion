using System.Collections.Generic;
using UnityEngine;

public class TargetsFinder : MonoBehaviour
{
    public List<Rigidbody> GetExplodableObject(Cube detonator)
    {
        List<Rigidbody> targets = new List<Rigidbody>();
        Collider[] potentialTargets = Physics.OverlapSphere(detonator.transform.position, detonator.ExlosionRadius);

        foreach (Collider target in potentialTargets)
        {
            if (target.attachedRigidbody != null)
            {
                targets.Add(target.attachedRigidbody);
            }
        }

        return targets;
    }
}

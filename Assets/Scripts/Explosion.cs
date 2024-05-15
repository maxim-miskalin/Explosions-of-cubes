using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _radius = 500f;
    [SerializeField] private float _force = 300f;

    public void Explode(List<Rigidbody> childCubes)
    {
        if (childCubes != null)
        {
            foreach (Rigidbody rigidbody in childCubes)
            {
                rigidbody.AddExplosionForce(_force, transform.position, _radius);
            }
        }
    }

    public void Explode()
    {
        foreach (Rigidbody rigidbody in GetExplodableObjects())
        {
            rigidbody.AddExplosionForce(_force / transform.localScale.y, transform.position, _radius / transform.localScale.y);
        }
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _radius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                cubes.Add(hit.attachedRigidbody);

        return cubes;
    }
}

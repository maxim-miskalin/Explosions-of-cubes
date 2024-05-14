using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 30f;
    [SerializeField] private float _explosionForce = 20f;

    public void Explode(List<Rigidbody> childCubes)
    {
        if (childCubes != null)
        {
            foreach (Rigidbody child in childCubes)
            {
                child.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
            }
        }
    }
}

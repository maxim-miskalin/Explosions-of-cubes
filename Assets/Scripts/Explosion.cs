using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 30f;
    [SerializeField] private float _explosionForce = 20f;

    public void Explode(List<Rigidbody> childObjects)
    {
        if (childObjects != null)
        {
            foreach (Rigidbody child in childObjects)
            {
                child.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
            }
        }
    }
}

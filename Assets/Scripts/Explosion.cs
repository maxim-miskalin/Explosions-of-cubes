using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _radius = 30f;
    [SerializeField] private float _force = 20f;

    public void Explode(List<Rigidbody> childCubes)
    {
        if (childCubes != null)
        {
            foreach (Rigidbody child in childCubes)
            {
                child.AddExplosionForce(_force, transform.position, _radius);
            }
        }
    }
}

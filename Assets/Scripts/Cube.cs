using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Explosion _explosion;

    private List<Rigidbody> _childObjects = new();

    public float ChanceOfSeparation = 1.0f;

    private void OnMouseUpAsButton()
    {
        _spawner.Spawn(ChanceOfSeparation, ref _childObjects);
        _explosion.Explode(_childObjects);
        Destroy(gameObject);
    }
}

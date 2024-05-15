using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Explosion _explosion;
    [SerializeField] private float _chanceOfSeparation = 1.0f;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnMouseUpAsButton()
    {
        List<Rigidbody> childCubes = new();

        childCubes = _spawner.Spawn(_chanceOfSeparation);
        _explosion.Explode(childCubes);
        Destroy(gameObject);
    }

    public Rigidbody GetRigidbody()
    {
        return _rigidbody;
    }

    public void ChangeParameters(float reducingParameters)
    {
        transform.localScale /= reducingParameters;
        _chanceOfSeparation /= reducingParameters;
        gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV();
    }
}

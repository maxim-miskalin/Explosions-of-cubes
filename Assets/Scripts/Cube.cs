using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Explosion _explosion;
    [SerializeField] private float _chanceOfSeparation = 1.0f;
    [SerializeField] private ParticleSystem _effect;

    private Rigidbody _rigidbody;

    public Rigidbody Rigidbody => _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnMouseUpAsButton()
    {
        List<Rigidbody> childCubes = new();

        Instantiate(_effect, transform.position, transform.rotation);

        childCubes = _spawner.Spawn(_chanceOfSeparation);

        if (childCubes.Count != 0)
            _explosion.Explode(childCubes);
        else
            _explosion.Explode();

        Destroy(gameObject);
    }

    public void ChangeParameters(float reducingParameters)
    {
        transform.localScale /= reducingParameters;
        _chanceOfSeparation /= reducingParameters;
        gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV();
    }
}

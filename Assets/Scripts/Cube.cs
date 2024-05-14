using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Explosion _explosion;
    [SerializeField] private float _chanceOfSeparation = 1.0f;

    private List<Rigidbody> _childCubes = new();

    private void OnMouseUpAsButton()
    {
        _childCubes = _spawner.Spawn(_chanceOfSeparation);
        _explosion.Explode(_childCubes);
        Destroy(gameObject);
    }

    public void ChangeParameters(float reducingParameters)
    {
        transform.localScale /= reducingParameters;
        _chanceOfSeparation /= reducingParameters;
        gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV();
    }
}

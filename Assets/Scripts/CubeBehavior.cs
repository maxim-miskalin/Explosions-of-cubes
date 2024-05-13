using System.Collections.Generic;
using UnityEngine;

public class CubeBehavior : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _explosionRadius = 10f;
    [SerializeField] private float _explosionForce = 10f;
    [SerializeField] private float _chanceOfSeparation = 1.0f;
    [SerializeField] private int _minQuantityObject = 2;
    [SerializeField] private int _maxQuantityObject = 6;

    private float _decrease = 2f;
    private List<GameObject> _childObjects = new();

    private void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV();
    }

    private void OnMouseUpAsButton()
    {
        ObjectCreate();
        Explode();
        Destroy(gameObject);
    }

    private void Explode()
    {
        if (_childObjects != null)
        {
            foreach (GameObject child in _childObjects)
            {
                child.GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
            }
        }
    }

    private void ObjectCreate()
    {
        if (Random.value <= _chanceOfSeparation)
        {
            int quantity = Random.Range(_minQuantityObject, _maxQuantityObject);
            GameObject newObject = DefinePpropertiesOfNewObject();

            for (int i = 0; i < quantity; i++)
            {
                _childObjects.Add(Instantiate(newObject, transform.position, Random.rotation));
            }
        }
    }

    private GameObject DefinePpropertiesOfNewObject()
    {
        GameObject newObject = _prefab;

        newObject.GetComponent<Transform>().localScale /= _decrease;
        newObject.GetComponent<CubeBehavior>()._chanceOfSeparation /= _decrease;

        return newObject;
    }
}

using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private int _minQuantityObject = 2;
    [SerializeField] private int _maxQuantityObject = 6;

    private float _reducingParameters = 2f;

    public List<Rigidbody> Spawn(float chanceOfSeparation)
    {
        List<Rigidbody> childCubes = new();

        if (Random.value <= chanceOfSeparation)
        {
            int quantity = Random.Range(_minQuantityObject, _maxQuantityObject);

            for (int i = 0; i < quantity; i++)
            {
                Cube newCube = Instantiate(_cubePrefab, transform.position, Random.rotation);

                newCube.ChangeParameters(_reducingParameters);

                childCubes.Add(newCube.Rigidbody);
            }
        }

        return childCubes;
    }
}

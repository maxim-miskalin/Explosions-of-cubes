using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private int _minQuantityObject = 2;
    [SerializeField] private int _maxQuantityObject = 6;

    private float _decrease = 2f;

    public void Spawn(float chanceOfSeparation, ref List<Rigidbody> childObjects)
    {
        if (Random.value <= chanceOfSeparation)
        {
            int quantity = Random.Range(_minQuantityObject, _maxQuantityObject);

            for (int i = 0; i < quantity; i++)
            {
                var newObject = Instantiate(_cube, transform.position, Random.rotation);

                newObject.transform.localScale /= _decrease;
                newObject.ChanceOfSeparation /= _decrease;
                newObject.GetComponent<Renderer>().material.color = Random.ColorHSV();
                childObjects.Add(newObject.GetComponent<Rigidbody>());
            }
        }
    }
}

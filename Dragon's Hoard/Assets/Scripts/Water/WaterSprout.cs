using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaterSprout : MonoBehaviour
{

    public float force = 1;
    public List<GameObject> _gameObjects;

    void Start()
    {
        _gameObjects = new List<GameObject>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        _gameObjects.Add(collision.gameObject);
    }

    void FixedUpdate()
    {
        foreach (var _object in _gameObjects)
        {
            if (_object.GetComponent<Rigidbody2D>())
            _object.GetComponent<Rigidbody2D>().AddForce(transform.up * force, ForceMode2D.Force); 
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (_gameObjects.Contains(other.gameObject))
        {
            _gameObjects.Remove(other.gameObject);
        }
    }
}

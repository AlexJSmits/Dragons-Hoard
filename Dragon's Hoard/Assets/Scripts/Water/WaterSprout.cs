using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaterSprout : MonoBehaviour
{

    public float force = 1;
    public Vector2 direction;
    public List<GameObject> _gameObjects;
    private AudioSource _audioSource;

    void Start()
    {
        _gameObjects = new List<GameObject>();

        if (GetComponent<AudioSource>())
        {
            _audioSource = GetComponent<AudioSource>();
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        _gameObjects.Add(collision.gameObject);
        _audioSource.pitch = Random.Range(-0.8f, 1.8f);
        _audioSource.Play();
    }

    void FixedUpdate()
    {
        foreach (var _object in _gameObjects)
        {
            if (_object.GetComponent<Rigidbody2D>())
            _object.GetComponent<Rigidbody2D>().AddForce(direction * force, ForceMode2D.Force); 
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

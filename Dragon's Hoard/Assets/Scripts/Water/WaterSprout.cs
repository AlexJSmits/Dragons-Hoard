using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaterSprout : MonoBehaviour
{

    public float force = 1;
    public Vector2 direction;
    public List<GameObject> _gameObjects;
    private AudioSource _audioSource;
    private NoiseMeter _noiseMeter;

    void Start()
    {
        _gameObjects = new List<GameObject>();

        if (GetComponent<AudioSource>())
        {
            _audioSource = GetComponent<AudioSource>();
        }

        if (GameObject.FindGameObjectWithTag("NoiseMeter"))
        {
            _noiseMeter = GameObject.FindGameObjectWithTag("NoiseMeter").GetComponent<NoiseMeter>();
        }
    }
    void OnTriggerEnter2D(Collider2D _collision)
    {
        _gameObjects.Add(_collision.gameObject);

        if (_collision.gameObject.GetComponent<Rigidbody2D>())
        {
            float noise = _collision.gameObject.GetComponent<Rigidbody2D>().linearVelocity.magnitude;
            
            if (noise > 1) 
            {
                if (_audioSource.isPlaying == false)
                {
                    _audioSource.pitch = Random.Range(0.8f, 1.2f);
                    _audioSource.Play();

                    if (_noiseMeter != null)
                    {
                        _noiseMeter.currentNoise += 2;
                        _noiseMeter.PlayDragonWakeUpNoise();
                    }
                }
            }
        }        
        
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

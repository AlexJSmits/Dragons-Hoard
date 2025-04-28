using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Drag2DObject : MonoBehaviour
{

    private bool _isBeingDragged;
    private Vector2 _targetOffset;
    private Vector2 _forceVector;
    private float forceMagnitude = 15;
    private Rigidbody2D _rigidBody;
    private AudioSource _impactSound;
    public AudioClip[] audioClips;
    private NoiseMeter _noiseMeter;
    private CameraShake _cameraShakeScript;
    private AudioSource _dragonWakeUpNoise;
    private Animator _snoreAnimator;

    void Start()
    {
        Time.timeScale = 1;

        _rigidBody = GetComponent<Rigidbody2D>();

        if (GetComponent<AudioSource>() != null)
        {
            _impactSound = GetComponent<AudioSource>();
        }

        if (GameObject.FindGameObjectWithTag("NoiseMeter"))
        {
            _noiseMeter = GameObject.FindGameObjectWithTag("NoiseMeter").GetComponent<NoiseMeter>();
        }

        if (GameObject.FindGameObjectWithTag("DragonWakeUpNoise"))
        {
            _dragonWakeUpNoise = GameObject.FindGameObjectWithTag("DragonWakeUpNoise").GetComponent<AudioSource>();
            _snoreAnimator = GameObject.FindGameObjectWithTag("DragonWakeUpNoise").GetComponent<Animator>();
        }
        else
        {
            Debug.Log("Could not find a game object in scene with the tag 'DragonWakeUpNoise'");
        }

        _cameraShakeScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();

    }

    void OnMouseDown()
    {
        _isBeingDragged = true;

        if(_rigidBody != null)
        {
            _rigidBody.gravityScale = 0;
        }
    }

    void OnMouseUp()
    {
        _isBeingDragged = false;

        if(_rigidBody != null)
        {
            _rigidBody.gravityScale = 1;
        }
    }

    void FixedUpdate()
    {
            _targetOffset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            _forceVector = _targetOffset * forceMagnitude;

            if (_isBeingDragged)
            {
                _rigidBody.linearVelocity = _rigidBody.linearVelocity * 0.9f;
                _rigidBody.AddForce(_forceVector, ForceMode2D.Force);               
            }
    
            if (_rigidBody.linearVelocityX > 1)
            {
                _rigidBody.AddTorque(-10 * Time.deltaTime);
            }
            else if (_rigidBody.linearVelocityX < -1)
            {
                _rigidBody.AddTorque(10 * Time.deltaTime);
            }

        if (_noiseMeter != null)
        {
            if (_noiseMeter.currentNoise == 0)
            {
                _snoreAnimator.speed = 1;
            }
            else
            {
                _snoreAnimator.speed = 0;
            }
        }
            
    }

    void OnCollisionEnter2D(Collision2D _collision)
    {
        float noise = _collision.relativeVelocity.magnitude * 0.75f;
        Mathf.Round(noise);

        if (_impactSound != null )
        {
            _impactSound.volume = noise / 30;
            _impactSound.clip = audioClips[UnityEngine.Random.Range(0, audioClips.Length)];
            _impactSound.Play();
        }

        if (_noiseMeter != null && _collision.relativeVelocity.magnitude > 1f)
        {
            if (_noiseMeter.currentNoise == 0)
            {
                _dragonWakeUpNoise.Play();
            }

            _noiseMeter.currentNoise += noise;
            _noiseMeter.decreasing = false;
            _noiseMeter.Invoke("ResumeNoiseDecrease", 2);
        }

        if (_cameraShakeScript != null && _collision.relativeVelocity.magnitude > 2f)
        {
            _cameraShakeScript.magnitude = noise;
        }
    }

}
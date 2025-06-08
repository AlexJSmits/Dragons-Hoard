using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Drag2DObject : MonoBehaviour
{
    public ProgressSaver playerProgressScriptableObject;
    private SpriteRenderer _spriteRenderer;
    private Color _startColor;
    public Color _highlightColor;
    private TrailRenderer _line;
    private ParticleSystem _particles;
    private bool _isBeingDragged;
    private Vector2 _targetOffset;
    private Vector2 _forceVector;
    private float forceMagnitude = 15;
    private Rigidbody2D _rigidBody;
    private AudioSource _impactSound;
    public AudioClip[] audioClips;
    private NoiseMeter _noiseMeter;
    private CameraShake _cameraShakeScript;
    public AudioClip grabSound;
    public AudioClip releaseSound;
    public AudioSource moveSound;
    public float moveVolumeDivision = 400;

    void Start()
    {
        if (GetComponent<SpriteRenderer>())
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _startColor = _spriteRenderer.color;
        }

        if (moveSound != null)
        {
            moveSound.volume = 0;
        }

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

        _cameraShakeScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();

        _particles = GetComponentInChildren<ParticleSystem>();
        _line = GetComponentInChildren<TrailRenderer>();

        if (_particles != null)
        {
            _particles.Stop();
        }

        if (_line != null)
        {
            _line.enabled = false;
        }

    }

    void OnMouseDown()
    {
        playerProgressScriptableObject.isDragging = true;
        _isBeingDragged = true;

        if (_impactSound != null)
        {
            _impactSound.volume = 0.2f;
            _impactSound.PlayOneShot(grabSound);
        }


        if (_rigidBody != null)
        {
            _rigidBody.gravityScale = 0;
        }

        if (_particles != null)
        {
            _particles.Play();
        }

        if (_line != null)
        {
            _line.enabled = true;
        }
    }

    void OnMouseUp()
    {
        if (_spriteRenderer != null)
        {
            _spriteRenderer.color = _startColor;
        }
        
        playerProgressScriptableObject.isDragging = false;

        _isBeingDragged = false;
        _impactSound.volume = 0.2f;
        _impactSound.PlayOneShot(releaseSound);
        if (moveSound != null)
        {
            moveSound.volume = 0;
        }

        if (_rigidBody != null)
        {
            _rigidBody.gravityScale = 1;
        }

        if (_particles != null)
        {
            _particles.Stop();
        }


        if (_line != null)
        {
            _line.enabled = false;
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

            if (moveSound != null)
            {
                moveSound.volume = _rigidBody.linearVelocity.magnitude / moveVolumeDivision;
            }
        }

        if (_rigidBody.linearVelocityX > 1)
        {
            _rigidBody.AddTorque(-10 * Time.deltaTime);
        }
        else if (_rigidBody.linearVelocityX < -1)
        {
            _rigidBody.AddTorque(10 * Time.deltaTime);
        }

    }

    void OnCollisionEnter2D(Collision2D _collision)
    {
        float noise = _collision.relativeVelocity.magnitude * 0.75f;
        Mathf.Round(noise);

        if (_impactSound != null)
        {
            _impactSound.volume = noise / 30;
            _impactSound.clip = audioClips[UnityEngine.Random.Range(0, audioClips.Length)];
            _impactSound.Play();
        }

        if (_noiseMeter != null && _collision.relativeVelocity.magnitude > 1f)
        {
            _noiseMeter.PlayDragonWakeUpNoise();
            _noiseMeter.currentNoise += noise;
        }

        if (_cameraShakeScript != null && _collision.relativeVelocity.magnitude > 2f)
        {
            _cameraShakeScript.magnitude = noise;
        }
    }

    void OnMouseOver()
    {
        if (playerProgressScriptableObject.isDragging == false && _spriteRenderer != null)
        {
            _spriteRenderer.color = _highlightColor;
        }
    }

    void OnMouseExit()
    {
        if (_isBeingDragged == false && _spriteRenderer != null)
        {
            _spriteRenderer.color = _startColor;
        }
            
    }

}
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    public float _fadeDuration = 2;
    public AudioClip[] _audioClips;

    private AudioSource _audioSource;
    private Scene _sceneReference;
    private Animator _animator;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
        _animator.speed /= _fadeDuration;
    }

    void OnLevelWasLoaded()
    {
        FadeMusicIn();
    }

    public void FadeMusicOut()
    {
        _animator.SetTrigger("Fade");
    }


    public void FadeMusicIn()
    {
        _sceneReference = SceneManager.GetActiveScene();

        if(_sceneReference.name == "Level 1-1" || _sceneReference.name == "Level 1-2" || _sceneReference.name == "Level 1-3")
        {
            if (_audioSource.clip != _audioClips[1])
            {
                _audioSource.clip = _audioClips[1];
                _audioSource.Play();
            }
        }
        else if (_sceneReference.name == "Level 2-1" || _sceneReference.name == "Level 2-2" || _sceneReference.name == "Level 2-3")
        {
            if (_audioSource.clip = _audioClips[2])
            {
                _audioSource.clip = _audioClips[2];
                _audioSource.Play();
            }
        }
        else if (_sceneReference.name == "Level 3-1" || _sceneReference.name == "Level 3-2" || _sceneReference.name == "Level 3-3")
        {
            if (_audioSource.clip != _audioClips[3])
            {
                _audioSource.clip = _audioClips[3];
                _audioSource.Play();
            }
        }
        else if (_audioSource.clip != _audioClips[0])
        {
            _audioSource.clip = _audioClips[0];
            _audioSource.Play();
        }

        _animator.SetTrigger("Wake");
    }

}

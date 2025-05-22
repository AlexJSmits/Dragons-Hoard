using UnityEngine;

public class MovingMetalDoor : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private AudioSource _audioSource;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if (_rigidBody.linearVelocity.magnitude > 0.1f)
        {
            if (_audioSource.isPlaying == false)
            _audioSource.Play();
        }
        else
        {
            _audioSource.Stop();
        }
    }
}

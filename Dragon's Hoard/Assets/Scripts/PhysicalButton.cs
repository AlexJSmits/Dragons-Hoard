using UnityEngine;

public class PhysicalButton : MonoBehaviour
{
    public GameObject button;
    public GameObject lightIndicator;

    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D _colliderEnter)
    {
        if (_colliderEnter.gameObject == button)
        {
            lightIndicator.SetActive(true);
            _audioSource.Play();
        }
    }

    void OnTriggerExit2D(Collider2D _colliderExit)
    {
        if (_colliderExit.gameObject == button)
        {
            lightIndicator.SetActive(false);
            _audioSource.Play();
        }
    }
}
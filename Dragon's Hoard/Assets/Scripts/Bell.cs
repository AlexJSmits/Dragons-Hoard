using UnityEngine;

public class Bell : MonoBehaviour
{
    public float _bellVolume = 10;
    private NoiseMeter _noiseMeter;
    private AudioSource _audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("NoiseMeter"))
        {
            _noiseMeter = GameObject.FindGameObjectWithTag("NoiseMeter").GetComponent<NoiseMeter>();
        }
        else
        {
            Debug.Log("Could not find game object with tag 'NoiseMeter'.");
        }

        if (GetComponent<AudioSource>())
        {
            _audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Debug.Log("No Audio Source component on Bell.");
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        float noise = collision.relativeVelocity.magnitude * 0.75f;
        Mathf.Round(noise);

        if (collision.relativeVelocity.magnitude > 1f && _audioSource.isPlaying == false)
        {
            if (_noiseMeter != null)
            {
                _noiseMeter.currentNoise += _bellVolume;
            }
            //probably will need to check if it hits a rope and ignore that
            _audioSource.pitch = Random.Range(0.8f, 1.2f);
            _audioSource.Play();
        }
    }
}

using System.Collections;
using System.Timers;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public float magnitude = 0;
    public float intensityDivision = 10;
    public float magnitudeEasingTime = 7;
    private Vector3 _originalPosition;
    
    [HideInInspector]
    public bool gamePaused = false;

    void Start()
    {
        _originalPosition = transform.localPosition;
    }

    void Update()
    {
        
        if (magnitude <= 0)
        {
            transform.localPosition = _originalPosition;
        }

        if (gamePaused == false)
        {
            float x = Random.Range(-0.4f, 0.4f) * (magnitude/intensityDivision);
            float y = Random.Range(-0.4f, 0.4f) * (magnitude/intensityDivision);

            transform.localPosition = _originalPosition + new Vector3(x, y, 0);
        }
        else
        {
            magnitude = 0;
            transform.localPosition = _originalPosition;
        }

        if (magnitude > 0)
        {
            magnitude -= Time.deltaTime * magnitudeEasingTime;
        }

        if (magnitude < 0 || magnitude > 0 && magnitude < 0.1f)
        {
            magnitude = 0;
        }

    }
}

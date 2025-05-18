using UnityEngine;

public class PhysicalButton : MonoBehaviour
{
    public GameObject button;
    public GameObject lightIndicator;
    public GameObject movingDoor;
    public GameObject doorOpenedPosition;
    public GameObject doorClosedPosition;
    public float movingDoorSpeed = 1;
    private bool _doorOpen = false;
    private Rigidbody2D _movingDoorRb;
    private Vector2 _targetOffset;
    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _movingDoorRb = movingDoor.GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D _colliderEnter)
    {
        if (_colliderEnter.gameObject == button)
        {
            lightIndicator.SetActive(true);
            _audioSource.Play();
            _doorOpen = true;
        }
    }

    void FixedUpdate()
    {
        if (_doorOpen == true)
        {
            _targetOffset = doorOpenedPosition.transform.position - movingDoor.transform.position;
            _movingDoorRb.AddForce(_targetOffset * movingDoorSpeed, ForceMode2D.Force);
        }
        else if (doorClosedPosition != null)
        {
            _targetOffset = doorClosedPosition.transform.position - movingDoor.transform.position;
            _movingDoorRb.AddForce(_targetOffset * movingDoorSpeed, ForceMode2D.Force);
        }
    }

    void OnTriggerExit2D(Collider2D _colliderExit)
    {
        if (_colliderExit.gameObject == button)
        {
            lightIndicator.SetActive(false);
            _audioSource.Play();
            _doorOpen = false;
        }
    }
}
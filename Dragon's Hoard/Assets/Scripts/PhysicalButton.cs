using UnityEngine;

public class PhysicalButton : MonoBehaviour
{
    public GameObject button;
    public GameObject lightIndicator;
    public GameObject movingDoor;
    public GameObject doorClosedPosition;
    public GameObject doorOpenedPosition;

    public float movingDoorSpeed = 1;
    private bool _doorOpen = false;
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
            _doorOpen = true;
        }
    }

    void FixedUpdate()
    {
        if (_doorOpen == true)
        {
            movingDoor.transform.position = Vector3.MoveTowards(movingDoor.transform.position, doorOpenedPosition.transform.position, movingDoorSpeed * Time.deltaTime);
        }
        else
        {
            // explore physics joints
            movingDoor.transform.position = Vector3.MoveTowards(movingDoor.transform.position, doorClosedPosition.transform.position, movingDoorSpeed * Time.deltaTime);
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
using UnityEngine;

public class PhysicalButton : MonoBehaviour
{
    public GameObject button;
    public GameObject lightIndicator;

    void OnTriggerEnter2D(Collider2D _colliderEnter)
    {
        if (_colliderEnter.gameObject == button)
        {
            lightIndicator.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D _colliderExit)
    {
        if (_colliderExit.gameObject == button)
        {
            lightIndicator.SetActive(false);
        }
    }
}
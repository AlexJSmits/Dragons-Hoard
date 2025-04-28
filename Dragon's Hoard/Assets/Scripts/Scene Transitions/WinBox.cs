using System.Linq;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class WinBox : MonoBehaviour
{
    private int _totalNumberOfValuables;
    private int _numberOfValuables = 0;
    private TextMeshPro _text;
    private float _winCountdown = 3;
    private bool _isCounting;
    public Canvas winCanvas;
    public GameObject currentlevel;
    public GameObject nextLevel;
    public GameObject levelSelectGate;
    private NoiseMeter _noiseMeter;
    private AudioSource _audio;

    void Start()
    {
        if (levelSelectGate == null)
        {
            _totalNumberOfValuables = GameObject.FindGameObjectsWithTag("Valuable").Length;
        }

        _text = GetComponentInChildren<TextMeshPro>();

        if (GameObject.FindGameObjectWithTag("NoiseMeter"))
        {
            _noiseMeter = GameObject.FindGameObjectWithTag("NoiseMeter").GetComponent<NoiseMeter>();
        }

        _audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Valuable"))
        {
            if(collision.gameObject == levelSelectGate)
            {
                _numberOfValuables += 1;
                _isCounting = true;
            }
            else
            {
                _numberOfValuables += 1;
                if (_numberOfValuables == _totalNumberOfValuables)
                {
                    _isCounting = true;
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Valuable"))
        {
            _numberOfValuables -= 1;
            _text.text = null;
            _isCounting = false;
            _winCountdown = 3;
        }
    }

    void Update()
    {
        if (_isCounting && _winCountdown > 0)
        {
            _text.text =  Mathf.Round(_winCountdown).ToString();
            _winCountdown -= Time.deltaTime;
        }
        else if (_isCounting && _winCountdown <= 0)
        {
            _text.text = null;
            WinCondition();
            _isCounting = false;
        }
    }

    void WinCondition()
    {
        if (_audio)
        _audio.Play();

        Time.timeScale = 0;

        if (_noiseMeter)
        {
            _noiseMeter.Win();
        }
        else
        {
            GetComponent<SceneChange>().LoadScene();
        }
    }
}

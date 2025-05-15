using System.Linq;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class WinBox : MonoBehaviour
{
    [Header("Level Progress Tracking")]
    public ProgressSaver playerProgressScriptableObject;
    public int levelNumber;

    public GameObject levelSelectGate;
    private int _totalNumberOfValuables;
    private int _numberOfValuables = 0;
    private TextMeshPro _text;
    private float _winCountdown = 3;
    private bool _isCounting;
    private NoiseMeter _noiseMeter;
    private AudioSource _audio;
    private Animator _animationManager;

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

        if (GameObject.FindGameObjectWithTag("AnimationManager"))
        {
            _animationManager = GameObject.FindGameObjectWithTag("AnimationManager").GetComponent<Animator>();
        }
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
        {
            _audio.Play();
        }
      
        if (playerProgressScriptableObject && playerProgressScriptableObject.levelProgress == levelNumber)
        {
            playerProgressScriptableObject.levelProgress ++;
        }

        Time.timeScale = 0;

        if (_noiseMeter)
        {
            _noiseMeter.Win();
        }
        else if (levelSelectGate != null)
        {
            GetComponent<SceneChange>().LoadScene();
        }
        else
        {
            //Only for level 0 because no noise meter or level gate.
            Camera.main.GetComponent<CameraShake>().gamePaused = true;
            Time.timeScale = 0;

            if (_animationManager!)
            {
                _animationManager.SetBool("Win", true);
            }
        }
    }
}

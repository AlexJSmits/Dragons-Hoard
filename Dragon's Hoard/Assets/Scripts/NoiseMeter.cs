using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NoiseMeter : MonoBehaviour
{
    public float maxNoise = 10;
    public float reductionFloat = 0.01f;
    private bool _pause = false;
    public float currentNoise = 0;
    private Animator _animationManager;
    private AudioSource _dragonWakeUpNoise;
    private Animator _snoreAnimator;
    
    [HideInInspector]
    public bool decreasing = true;

    [HideInInspector]
    public AudioSource _dragonSnoring;
    
    public GameObject loseNoise;

    void Start()
    {
        currentNoise = 0;
        _dragonSnoring = GetComponent<AudioSource>();

        if (GameObject.FindGameObjectWithTag("AnimationManager"))
        {
            _animationManager = GameObject.FindGameObjectWithTag("AnimationManager").GetComponent<Animator>();
        }
        else
        {
            Debug.Log("Could not find a game object with tag 'AnimationManager");
        }

        if (GameObject.FindGameObjectWithTag("DragonWakeUpNoise"))
        {
            _dragonWakeUpNoise = GameObject.FindGameObjectWithTag("DragonWakeUpNoise").GetComponent<AudioSource>();
            _snoreAnimator = GameObject.FindGameObjectWithTag("DragonWakeUpNoise").GetComponent<Animator>();
        }
        else
        {
            Debug.Log("Could not find a game object in scene with the tag 'DragonWakeUpNoise'");
        }
    }

    void FixedUpdate()
    {
        
        if (currentNoise > 0 && _pause == false && decreasing)
        {
            currentNoise -= reductionFloat;
        }

        if (currentNoise == 0)
        {
            _snoreAnimator.speed = 1;
        }
        else
        {
            _snoreAnimator.speed = 0;
        }
    }


    void Update()
    {
        if (_pause == false)
        {
            this.transform.localScale = new Vector3 (3.5f, currentNoise/10, 3.5f);
        }

        if (currentNoise > 0 && currentNoise <= 0.1f)
        {
            currentNoise = 0;
        }

        if (currentNoise >= maxNoise)
        {
            Lose();
            this.transform.localScale = new Vector3 (3.5f, maxNoise/10, 3.5f);
        }    

        if (currentNoise > 0)
        {
            _dragonSnoring.Stop();
            _dragonSnoring.time = 0.0f;
        }
        else if (currentNoise == 0 && _dragonSnoring.isPlaying == false)
        {
            _dragonSnoring.Play();
        }
    }

    void ResumeNoiseDecrease()
    {
        decreasing = true;
    }

    void Lose()
    {
        _pause = true;

        if (loseNoise)
        {
            loseNoise.SetActive(true);
        }
        else
        {
            Debug.Log("No Audio Clip assigned to dragon's 'lose noise'.");
        }
        

        Camera.main.GetComponent<CameraShake>().gamePaused = true;

        Time.timeScale = 0;

        if (_animationManager!)
        {
            _animationManager.SetBool("Lose", true);
        }
    }

    public void Win()
    {
        Camera.main.GetComponent<CameraShake>().gamePaused = true;

        Time.timeScale = 0;

        _pause = true;

        if (_animationManager!)
        {
            _animationManager.SetBool("Win", true);
        }
    }

    public void PlayDragonWakeUpNoise()
    {


        if (_dragonWakeUpNoise.isPlaying == false)
            {
                _dragonWakeUpNoise.pitch = Random.Range(0.6f, 1.4f);
                _dragonWakeUpNoise.Play();
                decreasing = false;
                Invoke("ResumeNoiseDecrease", 2);
            }
    }
}

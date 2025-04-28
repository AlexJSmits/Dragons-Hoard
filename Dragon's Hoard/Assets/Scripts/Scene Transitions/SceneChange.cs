using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string nextScene;
    public string mainMenu;
    private Animator _sceenTransitionAnimator;
    public float _sceneSwapDelay = 1f;

    void Start()
    {
        _sceenTransitionAnimator = GameObject.FindGameObjectWithTag("TransitionCanvas").GetComponent<Animator>();
    }

    public void LoadScene()
    {
        CircleTransition();       

        if (GameObject.FindGameObjectWithTag("Persistant"))
        {
            GameObject.FindGameObjectWithTag("Persistant").GetComponentInChildren<MouseCursor>().ForceHandOpen();
        }
        else
        {
            Debug.Log("Could Not Find Game Object with Tag 'Persistant'");
        }
        
        StartCoroutine(LoadNextSceneCoroutine(_sceneSwapDelay));
    }

    public IEnumerator LoadNextSceneCoroutine(float t)
    {
        yield return new WaitForSecondsRealtime(t);
        Time.timeScale = 1;
        SceneManager.LoadScene(nextScene);
    }

    public void LoadMainMenu()
    {
        CircleTransition();

        if (GameObject.FindGameObjectWithTag("Persistant"))
        {
            GameObject.FindGameObjectWithTag("Persistant").GetComponentInChildren<MouseCursor>().ForceHandOpen();
        }
        else
        {
            Debug.Log("Could Not Find Game Object with Tag 'Persistant'");
        }
        
        StartCoroutine(LoadMainMenuCoroutine(_sceneSwapDelay));

    }

    public IEnumerator LoadMainMenuCoroutine(float t)
    {
        yield return new WaitForSecondsRealtime(t);
        Time.timeScale = 1;
        SceneManager.LoadScene(mainMenu);
    }

    void CircleTransition()
    {
        _sceenTransitionAnimator.SetTrigger("Close");
    } 

}


using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatTracker : MonoBehaviour
{

    public ProgressSaver playerProgressScriptableObject;
    public TextMeshProUGUI treasureCount;
    public TextMeshProUGUI currentTime;
    public TextMeshProUGUI bestTime;


    [HideInInspector]
    public int numberOfValuables;

    [HideInInspector]
    public int totalNumberOfValuables;

    [HideInInspector]
    public bool _onTheClock = true;

    private Scene _sceneReference;
    private float _elaspedTime = 0.0f;

    void Start()
    {
        //Get/Set Best time from scriptable object
        _sceneReference = SceneManager.GetActiveScene();

        if (_sceneReference.name == "Level 0")
        {
            bestTime.text = playerProgressScriptableObject.level_0.ToString();
        }
        else if (_sceneReference.name == "Level 1-1")
        {
            bestTime.text = playerProgressScriptableObject.level_1_1.ToString();
        }
        else if (_sceneReference.name == "Level 1-2")
        {
            bestTime.text = playerProgressScriptableObject.level_1_2.ToString();
        }
        else if (_sceneReference.name == "Level 1-3")
        {
            bestTime.text = playerProgressScriptableObject.level_1_3.ToString();
        }
        else if (_sceneReference.name == "Level 2-1")
        {
            bestTime.text = playerProgressScriptableObject.level_2_1.ToString();
        }
        else if (_sceneReference.name == "Level 2-2")
        {
            bestTime.text = playerProgressScriptableObject.level_2_2.ToString();
        }
        else if (_sceneReference.name == "Level 2-2")
        {
            bestTime.text = playerProgressScriptableObject.level_2_3.ToString();
        }
        else if (_sceneReference.name == "Level 3-1")
        {
            bestTime.text = playerProgressScriptableObject.level_3_1.ToString();
        }
        else if (_sceneReference.name == "Level 3-2")
        {
            bestTime.text = playerProgressScriptableObject.level_3_2.ToString();
        }
        else if (_sceneReference.name == "Level 3-2")
        {
            bestTime.text = playerProgressScriptableObject.level_3_3.ToString();
        }
    }

    void Update()
    {
        //count how many of the treasures the player has in the chest. These ints are assigned in the winbox script.
        if (treasureCount != null)
        {
            treasureCount.text = numberOfValuables.ToString() + "/" + totalNumberOfValuables.ToString();
        }

        if (_onTheClock)
        {
            _elaspedTime += Time.deltaTime;
            currentTime.text = _elaspedTime.ToString("F1");
        }
        
    }

    public void SetHighScore()
    {

        if (float.Parse(bestTime.text) < 0.1f)
        {
            bestTime.text = currentTime.text;
        }
        else if (float.Parse(currentTime.text) < float.Parse(bestTime.text))
        {
            bestTime.text = currentTime.text;
        }
    
        if (_sceneReference.name == "Level 0")
        {
            playerProgressScriptableObject.level_0 = float.Parse(bestTime.text); 
        }
        else if (_sceneReference.name == "Level 1-1")
        {
            playerProgressScriptableObject.level_1_1 = float.Parse(bestTime.text);
        }
        else if (_sceneReference.name == "Level 1-2")
        {
            playerProgressScriptableObject.level_1_2 = float.Parse(bestTime.text);
        }
        else if (_sceneReference.name == "Level 1-3")
        {
            playerProgressScriptableObject.level_1_3 = float.Parse(bestTime.text);
        }
        else if (_sceneReference.name == "Level 2-1")
        {
            playerProgressScriptableObject.level_2_1 = float.Parse(bestTime.text);
        }
        else if (_sceneReference.name == "Level 2-2")
        {
            playerProgressScriptableObject.level_2_2 = float.Parse(bestTime.text);
        }
        else if (_sceneReference.name == "Level 2-3")
        {
            playerProgressScriptableObject.level_2_3 = float.Parse(bestTime.text);
        }
        else if (_sceneReference.name == "Level 3-1")
        {
            playerProgressScriptableObject.level_3_1 = float.Parse(bestTime.text);
        }
        else if (_sceneReference.name == "Level 3-2")
        {
            playerProgressScriptableObject.level_3_2 = float.Parse(bestTime.text);
        }
        else if (_sceneReference.name == "Level 3-3")
        {
            playerProgressScriptableObject.level_3_3 = float.Parse(bestTime.text);
        }
    }
}

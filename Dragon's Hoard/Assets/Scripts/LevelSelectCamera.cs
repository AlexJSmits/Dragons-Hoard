using System;
using UnityEngine;

public class LevelSelectCamera : MonoBehaviour
{
    public ProgressSaver playerProgressScriptableObject;
    public GameObject cameraObject;
    public GameObject waterFall;
    public float activeScreen = 1;
    public float moveSpeed = 25;

    [Header("Screen Transforms")]
    public Vector3 screen0transform;
    public Vector3 screen1transform;
    public Vector3 screen2transform;
    public Vector3 screen3transform;

    [Header("UI Arrows")]
    public GameObject screen0Arrows;
    public GameObject screen1Arrows;
    public GameObject screen2Arrows;
    public GameObject screen3Arrows;

    void Start()
    {
        if (playerProgressScriptableObject.cameraPosition == 1)
        {
            activeScreen = 1;
            cameraObject.transform.position = screen1transform;
        }    
        else if (playerProgressScriptableObject.cameraPosition == 2)
        {
            activeScreen = 2;
            cameraObject.transform.position = screen2transform;
        }
        else
        {
            activeScreen = 3;
            cameraObject.transform.position = screen3transform;
        }
    }

    void FixedUpdate()
    {
        if (activeScreen == 0)
        {
            cameraObject.transform.position = Vector3.Lerp(cameraObject.transform.position, screen0transform, moveSpeed * Time.deltaTime);
            screen0Arrows.SetActive(true);
        }
        else
        {
            screen0Arrows.SetActive(false);
        }

        if (activeScreen == 1)
        {
            cameraObject.transform.position = Vector3.Lerp(cameraObject.transform.position, screen1transform, moveSpeed * Time.deltaTime);
            screen1Arrows.SetActive(true);
        }
        else
        {
            screen1Arrows.SetActive(false);
        }
        
        if (activeScreen == 2)
        {
            cameraObject.transform.position = Vector3.Lerp(cameraObject.transform.position, screen2transform, moveSpeed * Time.deltaTime);
            waterFall.SetActive(true);
            screen2Arrows.SetActive(true);
        }
        else
        {
            waterFall.SetActive(false);
            screen2Arrows.SetActive(false);
        }
        
        if (activeScreen == 3)
        {
            cameraObject.transform.position = Vector3.Lerp(cameraObject.transform.position, screen3transform, moveSpeed * Time.deltaTime);
            screen3Arrows.SetActive(true);
        }
        else
        {
            screen3Arrows.SetActive(false);
        }

    }

    public void Screen0()
    {
        activeScreen = 0;
        playerProgressScriptableObject.cameraPosition = 0;
    }

    public void Screen1()
    {
        activeScreen = 1;
        playerProgressScriptableObject.cameraPosition = 1;
    }

    public void Screen2()
    {
        activeScreen = 2;
        playerProgressScriptableObject.cameraPosition = 2;
    }

    public void Screen3()
    {
        activeScreen = 3;
        playerProgressScriptableObject.cameraPosition = 3;
    }

}

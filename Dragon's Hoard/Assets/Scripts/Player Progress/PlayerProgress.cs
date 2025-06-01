using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerProgress : MonoBehaviour
{
    public ProgressSaver playerProgressScriptableObject;
    public LevelSelectCamera cameraScript;

    [Header("Level 1 Gates")]
    public Drag2DObject levelGate_1_2;
    public GameObject woodenBoards_1_2;
    public Drag2DObject levelGate_1_3;
    public GameObject woodenBoards_1_3;

    [Header("Level 2 Gates")]
    public Drag2DObject levelGate_2_1;
    public GameObject woodenBoards_2_1;
    public Drag2DObject levelGate_2_2;
    public GameObject woodenBoards_2_2;
    public Drag2DObject levelGate_2_3;
    public GameObject woodenBoards_2_3;

    [Header("Level 3 Gates")]
    public Drag2DObject levelGate_3_1;
    public GameObject woodenBoards_3_1;
    public Drag2DObject levelGate_3_2;
    public GameObject woodenBoards_3_2;
    public Drag2DObject levelGate_3_3;
    public GameObject woodenBoards_3_3;

    void Start()
    {
        if (playerProgressScriptableObject.levelProgress >= 2)
        {
            levelGate_1_2.enabled = true;
            woodenBoards_1_2.SetActive(false);

            if (playerProgressScriptableObject._level2FirstTime == true)
            {
                if (cameraScript.activeScreen != 1)
                {
                    cameraScript.Screen1();
                }

                playerProgressScriptableObject._level2FirstTime = false;
            }
        }

        if (playerProgressScriptableObject.levelProgress >= 3)
        {
            levelGate_1_3.enabled = true;
            woodenBoards_1_3.SetActive(false);

            if (playerProgressScriptableObject._level3FirstTime == true)
            {
                if (cameraScript.activeScreen != 1)
                {
                    cameraScript.Screen1();
                }

                playerProgressScriptableObject._level3FirstTime = false;
            }
        }

        if (playerProgressScriptableObject.levelProgress >= 4)
        {
            levelGate_2_1.enabled = true;
            woodenBoards_2_1.SetActive(false);

            if (playerProgressScriptableObject._level4FirstTime == true)
            {
                if (cameraScript.activeScreen != 2)
                {
                    cameraScript.Screen2();
                }

                playerProgressScriptableObject._level4FirstTime = false;
            }

        }

        if (playerProgressScriptableObject.levelProgress >= 5)
        {
            levelGate_2_2.enabled = true;
            woodenBoards_2_2.SetActive(false);

            if (playerProgressScriptableObject._level5FirstTime == true)
            {
                if (cameraScript.activeScreen != 2)
                {
                    cameraScript.Screen2();
                }

                playerProgressScriptableObject._level5FirstTime = false;
            }
        }

        if (playerProgressScriptableObject.levelProgress >= 6)
        {
            levelGate_2_3.enabled = true;
            woodenBoards_2_3.SetActive(false);

            if (playerProgressScriptableObject._level6FirstTime == true)
            {
                if (cameraScript.activeScreen != 2)
                {
                    cameraScript.Screen2();
                }

                playerProgressScriptableObject._level6FirstTime = false;
            }



        }

        if (playerProgressScriptableObject.levelProgress >= 7)
        {
            levelGate_3_1.enabled = true;
            woodenBoards_3_1.SetActive(false);

            if (playerProgressScriptableObject._level7FirstTime == true)
            {
                if (cameraScript.activeScreen != 3)
                {
                    cameraScript.Screen3();
                }

                playerProgressScriptableObject._level7FirstTime = false;
            }
        }

        if (playerProgressScriptableObject.levelProgress >= 8)
        {
            levelGate_3_2.enabled = true;
            woodenBoards_3_2.SetActive(false);

            if (playerProgressScriptableObject._level8FirstTime == true)
            {
                if (cameraScript.activeScreen != 3)
                {
                    cameraScript.Screen3();
                }

                playerProgressScriptableObject._level8FirstTime = false;
            }
        }

        if (playerProgressScriptableObject.levelProgress >= 9)
        {
            levelGate_3_3.enabled = true;
            woodenBoards_3_3.SetActive(false);

            if (playerProgressScriptableObject._level9FirstTime == true)
            {
                if (cameraScript.activeScreen != 3)
                {
                    cameraScript.Screen3();
                }

                playerProgressScriptableObject._level9FirstTime = false;
            }
        }

        if (playerProgressScriptableObject.levelProgress >= 10)
        {
            if (playerProgressScriptableObject._level10FirstTime == true)
            {
                if (cameraScript.activeScreen != 0)
                {
                    cameraScript.Screen0();
                }

                playerProgressScriptableObject._level10FirstTime = false;
            }
        }
    }
}

using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    public ProgressSaver playerProgressScriptableObject;
 
    [Header("Camera Position")]
    public Animator cameraAnimator;
 
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
        if (playerProgressScriptableObject.cameraPosition < 4)
        {
            cameraAnimator.SetTrigger("GoTo1");
        }
        else if (playerProgressScriptableObject.cameraPosition > 4 && playerProgressScriptableObject.cameraPosition < 7)
        {
            cameraAnimator.SetTrigger("GoTo2");
        }
        else
        {
            cameraAnimator.SetTrigger("GoTo3");
        }


        if (playerProgressScriptableObject.levelProgress == 2)
        {
            levelGate_1_2.enabled = true;
            woodenBoards_1_2.SetActive(false);
        }
        else if (playerProgressScriptableObject.levelProgress == 3)
        {
            levelGate_1_3.enabled = true;
            woodenBoards_1_3.SetActive(false);
        }
        else if (playerProgressScriptableObject.levelProgress == 4)
        {
            levelGate_2_1.enabled = true;
            woodenBoards_2_1.SetActive(false);
        }
        else if (playerProgressScriptableObject.levelProgress == 5)
        {
            levelGate_2_2.enabled = true;
            woodenBoards_2_2.SetActive(false);
        }
        else if (playerProgressScriptableObject.levelProgress == 6)
        {
            levelGate_2_3.enabled = true;
            woodenBoards_2_3.SetActive(false);
        }
        else if (playerProgressScriptableObject.levelProgress == 7)
        {
            levelGate_3_1.enabled = true;
            woodenBoards_3_1.SetActive(false);
        }
        else if (playerProgressScriptableObject.levelProgress == 8)
        {
            levelGate_3_2.enabled = true;
            woodenBoards_3_2.SetActive(false);
        }
        else if (playerProgressScriptableObject.levelProgress == 9)
        {
            levelGate_3_3.enabled = true;
            woodenBoards_3_3.SetActive(false);
        }
    }
}

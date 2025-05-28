using UnityEngine;

[CreateAssetMenu(fileName = "PlayerProgressScript", menuName = "Scriptable Objects/PlayerProgressScript")]
public class ProgressSaver : ScriptableObject
{

    [Header("Camera Position")]
    public int cameraPosition = 1;

    [Header("Level 1 Progress")]
    public int levelProgress = 1;

    [Header("Volume Sliders")]
    public float masterVolume = 1;
    public float SFXVolume = 1;
    public float musicVolume = 1;

    [Header("Level Times")]
    public float level_1_1 = 0.0f;
    public float level_1_2 = 0.0f;
    public float level_1_3 = 0.0f;
    public float level_2_1 = 0.0f;
    public float level_2_2 = 0.0f;
    public float level_2_3 = 0.0f;
    public float level_3_1 = 0.0f;
    public float level_3_2 = 0.0f;
    public float level_3_3 = 0.0f;

}

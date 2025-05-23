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


}

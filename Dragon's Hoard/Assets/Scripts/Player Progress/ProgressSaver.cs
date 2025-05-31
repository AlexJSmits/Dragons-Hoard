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
    public float level_0 = 0.0f;
    public float level_1_1 = 0.0f;
    public float level_1_2 = 0.0f;
    public float level_1_3 = 0.0f;
    public float level_2_1 = 0.0f;
    public float level_2_2 = 0.0f;
    public float level_2_3 = 0.0f;
    public float level_3_1 = 0.0f;
    public float level_3_2 = 0.0f;
    public float level_3_3 = 0.0f;

    [Header("Level Unlock Status")]
    public bool _level2FirstTime = true;
    public bool _level3FirstTime = true;
    public bool _level4FirstTime = true;
    public bool _level5FirstTime = true;
    public bool _level6FirstTime = true;
    public bool _level7FirstTime = true;
    public bool _level8FirstTime = true;
    public bool _level9FirstTime = true;

    public void SaveGame()
    {
        PlayerPrefs.SetInt("cameraPosition", cameraPosition);
        PlayerPrefs.SetInt("levelProgress", levelProgress);

        PlayerPrefs.SetFloat("masterVolume", masterVolume);
        PlayerPrefs.SetFloat("SFXVolume", SFXVolume);
        PlayerPrefs.SetFloat("musicVolume", musicVolume);

        PlayerPrefs.SetInt("_level2FirstTime", _level2FirstTime ? 1 : 0);
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("levelProgress"))
        {
            cameraPosition = PlayerPrefs.GetInt("cameraPosition");
            levelProgress = PlayerPrefs.GetInt("levelProgress");

            masterVolume = PlayerPrefs.GetFloat("masterVolume");
            SFXVolume = PlayerPrefs.GetFloat("masterVolume");
            musicVolume = PlayerPrefs.GetFloat("musicVolume");

            _level2FirstTime = PlayerPrefs.GetInt("_level2FirstTime") != 0;
            _level3FirstTime = PlayerPrefs.GetInt("_level3FirstTime") != 0;
            _level4FirstTime = PlayerPrefs.GetInt("_level4FirstTime") != 0;
            _level5FirstTime = PlayerPrefs.GetInt("_level5FirstTime") != 0;
            _level6FirstTime = PlayerPrefs.GetInt("_level6FirstTime") != 0;
            _level7FirstTime = PlayerPrefs.GetInt("_level7FirstTime") != 0;
            _level8FirstTime = PlayerPrefs.GetInt("_level8FirstTime") != 0;
            _level9FirstTime = PlayerPrefs.GetInt("_level9FirstTime") != 0;
        }
    }
}

using UnityEngine;

public class LevelScratches : MonoBehaviour
{
    public ProgressSaver playerProgressScriptableObject;
    public int levelNumber;
    public Color locked;
    public Color unlocked;
    public Color recentlyUnlocked;

    private SpriteRenderer _sprite;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();

        
        if (levelNumber == playerProgressScriptableObject.levelProgress)
        {
            _sprite.color = recentlyUnlocked;
        }
        else if (levelNumber < playerProgressScriptableObject.levelProgress)
        {
            _sprite.color = unlocked;
        }
        else
        {
            _sprite.color = locked;
        }
    }
}

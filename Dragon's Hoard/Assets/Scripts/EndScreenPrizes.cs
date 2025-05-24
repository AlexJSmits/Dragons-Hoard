using System.Collections;
using UnityEngine;

public class EndScreenPrizes : MonoBehaviour
{
    [Header("Spawn Point")]
    public GameObject spawnPoint;

    [Header("Prize Prefabs")]
    public GameObject trophy;
    public GameObject blueGem;
    public GameObject pinkGem;

    [Header("Prize Count")]
    public float trophyCount = 8;
    public float blueGemCount = 7;
    public float pinkGemCount = 6;

    [Header("Audio Source")]
    public AudioSource audioSource;

    void Start()
    {
        Invoke("StartSpawningTrophies", 1);
        Invoke("StartSpawningBlueGems", 2);
        Invoke("StartSpawningPinkGems", 2);
        
    }

    void StartSpawningTrophies()
    {
        StartCoroutine(SpawnTrophyPrizes(trophy));
    }

    void StartSpawningBlueGems()
    {
        StartCoroutine(SpawnBlueGemPrizes(blueGem));
    }

    void StartSpawningPinkGems()
    {
        StartCoroutine(SpawnPinkGemPrizes(pinkGem));
    }

    public IEnumerator SpawnTrophyPrizes(GameObject trophy)
    {
        yield return new WaitForSecondsRealtime(Random.Range(0.5f, 1f));

        if (trophyCount > 0)
        {
            GameObject newTrophy = Instantiate(trophy, spawnPoint.transform);
            newTrophy.GetComponent<Rigidbody2D>().AddForce(new Vector3(Random.Range(-7, 7), 13, 0), ForceMode2D.Impulse);
            trophyCount -= 1;
            audioSource.Play();
            StartCoroutine(SpawnTrophyPrizes(trophy));
        }
    }

    public IEnumerator SpawnBlueGemPrizes(GameObject blueGem)
    {
        yield return new WaitForSecondsRealtime(Random.Range(0.5f, 1f));

        if (blueGemCount > 0)
        {
            GameObject newBlueGem = Instantiate(blueGem, spawnPoint.transform);
            newBlueGem.GetComponent<Rigidbody2D>().AddForce(new Vector3(Random.Range(-7, 7), 14, 0), ForceMode2D.Impulse);
            blueGemCount -= 1;
            audioSource.Play();
            StartCoroutine(SpawnBlueGemPrizes(blueGem));
        }
    }

    public IEnumerator SpawnPinkGemPrizes(GameObject pinkGem)
    {
        yield return new WaitForSecondsRealtime(Random.Range(0.5f, 1f));

        if (trophyCount > 0)
        {
            GameObject newPinkGem = Instantiate(pinkGem, spawnPoint.transform);
            newPinkGem.GetComponent<Rigidbody2D>().AddForce(new Vector3(Random.Range(-7, 7), 15, 0), ForceMode2D.Impulse);
            pinkGemCount -= 1;
            audioSource.Play();
            StartCoroutine(SpawnPinkGemPrizes(pinkGem));
        }
    }

}

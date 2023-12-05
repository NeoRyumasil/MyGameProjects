using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public static PlatformSpawner Instance = null;

    [SerializeField] GameObject Platform;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        Instantiate(Platform, new Vector2(-3.5f, -2.5f), Platform.transform.rotation);
        Instantiate(Platform, new Vector2(0f, -2.5f), Platform.transform.rotation);
        Instantiate(Platform, new Vector2(3.5f, -2.5f), Platform.transform.rotation);
    }

    IEnumerator SpawnPlatform(Vector2 SpawnPosition)
    {
        yield return new WaitForSeconds(2f);
        Instantiate(Platform, SpawnPosition, Platform.transform.rotation);
    }
}

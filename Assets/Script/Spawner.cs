using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance = null;

    [SerializeField] GameObject SpawnObject;
    [SerializeField] Transform SpawnPos;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        else if (Instance != null)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Instantiate(SpawnObject, new Vector2 (-3.5f, -2.5f), SpawnObject.transform.rotation);
        Instantiate(SpawnObject, new Vector2 (0f, -2.5f), SpawnObject.transform.rotation);
        Instantiate(SpawnObject, new Vector2 (3.5f, -2.5f), SpawnObject.transform.rotation);
    }


    IEnumerator SpawnTheObject(Vector2 SpawnPosition)
    {
        yield return new WaitForSeconds(2f);
        Instantiate(SpawnObject, SpawnPosition, SpawnObject.transform.rotation);
    }
}

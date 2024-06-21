using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnItem : MonoBehaviour
{

    private void Start()
    {

        LoadPrefab();

    }

    private void LoadPrefab()
    {
        int spawnPos = Random.Range(-5, 6);

        int itemIdx = Random.Range(0, 3);

        transform.position = new Vector2(spawnPos, 5);

        Managers.Resource.Instantiate($"{Managers.Data.items[itemIdx].prefabPath}", transform);

    }
}

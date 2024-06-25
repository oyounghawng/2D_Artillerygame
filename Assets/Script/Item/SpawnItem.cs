using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnItem : MonoBehaviour
{

    private void Start()
    {
        InvokeRepeating("LoadPrefab", 1f, 1f);
        // 일정 시간 지난 후 반복 실행으로 할지 턴당 실행할지 모르겠음.
        // 턴당 실행 할거면 턴 변수에 할당해서 해야할듯함 아마 그게 생기면
        // 그냥 플레이어 행동 함수 소환될때 판별해서 아이템 소환하면 될 듯 함
    }

    private void LoadPrefab()
    {
        float spawnXPos = Random.Range(-8f, 8f);

        int itemIdx = Random.Range(0, 4);

        Vector2 spawnPosition = new Vector2(spawnXPos, 5);

        GameObject newPrefabInstance = Managers.Resource.Instantiate($"{Managers.Data.items[itemIdx].prefabPath}", transform);

        newPrefabInstance.transform.position = spawnPosition;
    }
}

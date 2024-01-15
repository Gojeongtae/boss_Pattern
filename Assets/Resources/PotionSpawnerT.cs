using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSpawnerT : MonoBehaviour
{
    public GameObject itemPrefab; // 생성할 아이템 프리팹
    public float spawnInterval = 5f; // 생성 간격(초)
    public Transform[] spawnPoints; // 여러 생성 위치의 Transform 배열
    public float itemLifetime = 10f; // 아이템 수명 (초)

    void Start()
    {
        // 시작 시간부터 일정 간격으로 SpawnItem 함수 호출
        StartCoroutine(SpawnItemRoutine());
    }

    IEnumerator SpawnItemRoutine()
    {
        while (true)
        {
            // 아이템을 무작위 생성 위치에서 생성
            Transform randomSpawnPoint = GetRandomSpawnPoint();
            GameObject newItem = SpawnItem(randomSpawnPoint);

            // 일정 간격 대기
            yield return new WaitForSeconds(spawnInterval);

            // 아이템 수명이 지난 후 파괴
            Destroy(newItem, itemLifetime);
        }
    }

    Transform GetRandomSpawnPoint()
    {
        // 무작위 생성 위치 반환
        return spawnPoints[Random.Range(0, spawnPoints.Length)];
    }

    GameObject SpawnItem(Transform spawnPoint)
    {
        // 아이템을 생성할 위치를 가져오기
        Vector3 position = spawnPoint != null ? spawnPoint.position : transform.position;

        // 아이템 생성
        GameObject newItem = Instantiate(itemPrefab, position, Quaternion.identity);

        return newItem;
    }
}

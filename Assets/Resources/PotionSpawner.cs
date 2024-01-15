using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSpawner : MonoBehaviour
{
    public GameObject itemPrefab; // 생성할 아이템 프리팹
    public float spawnInterval = 10f; // 생성 간격(초)
    public Transform spawnPoint; // 생성 위치의 Transform
    public float itemLifetime = 5f; // 아이템 수명 (초)

    void Start()
    {
        // 시작 시간부터 일정 간격으로 SpawnItem 함수 호출
        StartCoroutine(SpawnItemRoutine());
    }

    IEnumerator SpawnItemRoutine()
    {
        while (true)
        {
            // 아이템 생성
            GameObject newItem = SpawnItem();

            // 일정 간격 대기
            yield return new WaitForSeconds(spawnInterval);

            // 아이템 수명이 지난 후 파괴
            Destroy(newItem, itemLifetime);
        }
    }

    GameObject SpawnItem()
    {
        // 아이템을 생성할 위치를 가져오기
        Vector3 position = spawnPoint != null ? spawnPoint.position : transform.position;

        // 아이템 생성
        GameObject newItem = Instantiate(itemPrefab, position, Quaternion.identity);

        return newItem;
    }
}

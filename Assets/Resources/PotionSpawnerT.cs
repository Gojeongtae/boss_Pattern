using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSpawnerT : MonoBehaviour
{
    public GameObject itemPrefab; // ������ ������ ������
    public float spawnInterval = 5f; // ���� ����(��)
    public Transform[] spawnPoints; // ���� ���� ��ġ�� Transform �迭
    public float itemLifetime = 10f; // ������ ���� (��)

    void Start()
    {
        // ���� �ð����� ���� �������� SpawnItem �Լ� ȣ��
        StartCoroutine(SpawnItemRoutine());
    }

    IEnumerator SpawnItemRoutine()
    {
        while (true)
        {
            // �������� ������ ���� ��ġ���� ����
            Transform randomSpawnPoint = GetRandomSpawnPoint();
            GameObject newItem = SpawnItem(randomSpawnPoint);

            // ���� ���� ���
            yield return new WaitForSeconds(spawnInterval);

            // ������ ������ ���� �� �ı�
            Destroy(newItem, itemLifetime);
        }
    }

    Transform GetRandomSpawnPoint()
    {
        // ������ ���� ��ġ ��ȯ
        return spawnPoints[Random.Range(0, spawnPoints.Length)];
    }

    GameObject SpawnItem(Transform spawnPoint)
    {
        // �������� ������ ��ġ�� ��������
        Vector3 position = spawnPoint != null ? spawnPoint.position : transform.position;

        // ������ ����
        GameObject newItem = Instantiate(itemPrefab, position, Quaternion.identity);

        return newItem;
    }
}

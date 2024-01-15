using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSpawner : MonoBehaviour
{
    public GameObject itemPrefab; // ������ ������ ������
    public float spawnInterval = 10f; // ���� ����(��)
    public Transform spawnPoint; // ���� ��ġ�� Transform
    public float itemLifetime = 5f; // ������ ���� (��)

    void Start()
    {
        // ���� �ð����� ���� �������� SpawnItem �Լ� ȣ��
        StartCoroutine(SpawnItemRoutine());
    }

    IEnumerator SpawnItemRoutine()
    {
        while (true)
        {
            // ������ ����
            GameObject newItem = SpawnItem();

            // ���� ���� ���
            yield return new WaitForSeconds(spawnInterval);

            // ������ ������ ���� �� �ı�
            Destroy(newItem, itemLifetime);
        }
    }

    GameObject SpawnItem()
    {
        // �������� ������ ��ġ�� ��������
        Vector3 position = spawnPoint != null ? spawnPoint.position : transform.position;

        // ������ ����
        GameObject newItem = Instantiate(itemPrefab, position, Quaternion.identity);

        return newItem;
    }
}

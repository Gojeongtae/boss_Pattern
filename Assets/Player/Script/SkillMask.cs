using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillMask : MonoBehaviour
{
    public Sprite spriteA;  // A ��������Ʈ
    public Sprite spriteB;  // B ��������Ʈ
    public SpriteMask spriteMask;  // ��������Ʈ ����ũ
    private int spacebarCount = 0;  // �����̽��ٰ� ���� Ƚ��

    void Update()
    {
        // �����̽��� �Է� üũ
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spacebarCount++;

            // A���� B�� �����ϴ� ����
            ChangeSprite();
        }
    }

    void ChangeSprite()
    {
        // ���� ��ų �������� Sprite
        Sprite currentSprite = spriteMask.sprite;

        // ���� ��������Ʈ�� A�� ��� 3���� 1 ��ŭ B�� ����
        if (currentSprite == spriteA)
        {
            float progress = (float)spacebarCount / 3f;

            // ũ�⸦ �����Ͽ� ��ȯ ȿ��
            spriteMask.transform.localScale = Vector3.Lerp(Vector3.one, new Vector3(0.333f, 1f, 1f), progress);
        }

        // �����̽��� 3�� ������ �ʱ�ȭ
        if (spacebarCount >= 3)
        {
            spacebarCount = 0;
        }
    }
}

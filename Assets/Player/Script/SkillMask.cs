using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillMask : MonoBehaviour
{
    public Sprite spriteA;  // A 스프라이트
    public Sprite spriteB;  // B 스프라이트
    public SpriteMask spriteMask;  // 스프라이트 마스크
    private int spacebarCount = 0;  // 스페이스바가 눌린 횟수

    void Update()
    {
        // 스페이스바 입력 체크
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spacebarCount++;

            // A에서 B로 변경하는 로직
            ChangeSprite();
        }
    }

    void ChangeSprite()
    {
        // 현재 스킬 아이콘의 Sprite
        Sprite currentSprite = spriteMask.sprite;

        // 현재 스프라이트가 A일 경우 3분의 1 만큼 B로 변경
        if (currentSprite == spriteA)
        {
            float progress = (float)spacebarCount / 3f;

            // 크기를 조절하여 전환 효과
            spriteMask.transform.localScale = Vector3.Lerp(Vector3.one, new Vector3(0.333f, 1f, 1f), progress);
        }

        // 스페이스바 3번 누르면 초기화
        if (spacebarCount >= 3)
        {
            spacebarCount = 0;
        }
    }
}

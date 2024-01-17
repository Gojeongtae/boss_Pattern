using UnityEngine;
using TMPro;

public class SimpleDialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public GameObject endUI; // ���� �� ��Ȱ��ȭ�� UI

    private int currentDialogueIndex = 0;

    private string[] dialogues = {
        "������ �����? ���?",
        "�ƴѵ�?",
        "��..�Ƿ��߽��ϴ�..",
        "���θ� �ϸ� �ٴ�?"
    };

    void Start()
    {
        DisplayCurrentDialogue();
    }

    void Update()
    {
        // �ƹ� ���̳� Ŭ���ϸ� ���� ��ȭ�� �Ѿ���� ����
        if (Input.GetMouseButtonDown(0))
        {
            NextDialogue();
        }
    }

    private void DisplayCurrentDialogue()
    {
        if (currentDialogueIndex < dialogues.Length)
        {
            dialogueText.text = dialogues[currentDialogueIndex];
        }
        else
        {
            dialogueText.text = "��ȭ�� ����Ǿ����ϴ�.";
            // ��ȭ�� ����Ǹ� 2�� �Ŀ� UI�� ��Ȱ��ȭ�ϰ� �� ����
            Invoke("DeactivateUIAndQuit", 2f);
        }
    }

    private void NextDialogue()
    {
        currentDialogueIndex++;
        DisplayCurrentDialogue();
    }

    private void DeactivateUIAndQuit()
    {
        // UI�� ��Ȱ��ȭ
        if (endUI != null)
        {
            endUI.SetActive(false);
        }

        // �� ����
        Application.Quit();
    }
}

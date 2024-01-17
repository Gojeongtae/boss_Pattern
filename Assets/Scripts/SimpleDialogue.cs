using UnityEngine;
using TMPro;

public class SimpleDialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public GameObject endUI; // 종료 후 비활성화할 UI

    private int currentDialogueIndex = 0;

    private string[] dialogues = {
        "아저씨 용사죠? 용사?",
        "아닌데?",
        "아..실례했습니다..",
        "말로만 하면 다니?"
    };

    void Start()
    {
        DisplayCurrentDialogue();
    }

    void Update()
    {
        // 아무 곳이나 클릭하면 다음 대화로 넘어가도록 설정
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
            dialogueText.text = "대화가 종료되었습니다.";
            // 대화가 종료되면 2초 후에 UI를 비활성화하고 앱 종료
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
        // UI를 비활성화
        if (endUI != null)
        {
            endUI.SetActive(false);
        }

        // 앱 종료
        Application.Quit();
    }
}

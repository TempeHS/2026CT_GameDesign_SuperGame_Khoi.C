using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueReceiver : MonoBehaviour
{
    public TextMeshProUGUI text;
    public string[] lines;
    public float textSpeed = 0.05f;

    private int index;
    
    public void GetLines(string[] receivedLines) {
        lines = receivedLines;
        gameObject.SetActive(true);
        StartDialogue();
    }

    void Start()
    {
        text.text = string.Empty;
        gameObject.SetActive(false);
    }

    public void NextDialogue() {
        text.text = string.Empty;
        index += 1;
        if (index < lines.Length) {
            StopAllCoroutines();
            StartCoroutine(TypeLine());
        }
    }

    void Update() {
        if (index >= lines.Length) {
            gameObject.SetActive(false);
        }
    }

    void StartDialogue() {
        index = 0;
        StartCoroutine(TypeLine());
    }

    public void CloseDialogue() {
        index = 0;
        text.text = string.Empty;
        StopAllCoroutines();
        gameObject.SetActive(false);
    }

    IEnumerator TypeLine() {
        foreach (char c in lines[index].ToCharArray()) {
            text.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}

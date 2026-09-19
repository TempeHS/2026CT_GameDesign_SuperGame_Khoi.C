using UnityEngine;

public class DialogueTransmitter : MonoBehaviour
{
    public string[] linePacket;
    public DialogueReceiver dialogueRef;
    private bool hasInteracted = false;

    void OnTriggerEnter2D(Collider2D collision) {
        if (hasInteracted == false) {
            bool isPlayer = collision.CompareTag("Player");
            if (isPlayer == true) {
                dialogueRef.GetLines(linePacket);
                hasInteracted = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hasInteracted = false;
            dialogueRef.CloseDialogue();
        }
    }
}

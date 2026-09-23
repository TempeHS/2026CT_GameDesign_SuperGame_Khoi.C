using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public GameEndMenu gameEndMenu;

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player"))
        {
            gameEndMenu.WinScreen();
        }
    }
}

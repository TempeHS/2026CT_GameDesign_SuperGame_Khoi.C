using UnityEngine;
using TMPro;

public class OrbCounter : MonoBehaviour
{
    public int orbs;
    public TextMeshProUGUI counter;

    public void ChangeOrbCount(int count) {
        orbs += count;
    }

    void Update()
    {
        counter.text = orbs.ToString();
    }
}

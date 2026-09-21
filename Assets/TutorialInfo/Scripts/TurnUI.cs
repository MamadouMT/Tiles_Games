using UnityEngine;
using TMPro;

public class TurnUI : MonoBehaviour
{
    public TMP_Text turnText;

    void Update()
    {
        if (TurnManager.currentTeam == 1)
        {
            turnText.text = "Team 1's Turn";
            turnText.color = Color.yellow;
        }
        else
        {
            turnText.text = "Team 2's Turn";
            turnText.color = Color.green;
        }
    }
}
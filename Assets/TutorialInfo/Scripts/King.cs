using UnityEngine;

public class King : MonoBehaviour
{
    public static King selectedKing;
    public int team;

    void OnMouseDown()
    {
        // Only select the King if it is your turn
        if (team != TurnManager.currentTeam)
        {
            Debug.Log("It's not your turn!");
            return;
        }

        selectedKing = this;
        Debug.Log("King selected!");
    }

    public void MoveTo(Vector3 position)
    {
        float distance = Vector3.Distance(transform.position, position);

        if (distance <= 1.5f)
        {
            transform.position = position;
            selectedKing = null;

            // Change to the other team's turn
            TurnManager.ChangeTurn();
        }
    }
}
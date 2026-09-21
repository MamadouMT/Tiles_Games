using UnityEngine;

public class Bishop : MonoBehaviour
{
    public static Bishop selectedBishop;
    public int team;

    void OnMouseDown()
    {
        // Only select the Bishop if it is your turn
        if (team != TurnManager.currentTeam)
        {
            Debug.Log("It's not your turn!");
            return;
        }

        selectedBishop = this;
        Debug.Log("Bishop selected!");
    }

    public void MoveTo(Vector3 position)
    {
        float xDistance = Mathf.Abs(transform.position.x - position.x);
        float zDistance = Mathf.Abs(transform.position.z - position.z);

        // Bishop moves diagonally
        if (Mathf.Abs(xDistance - zDistance) < 0.1f)
        {
            transform.position = position;
            selectedBishop = null;

            // Change turn
            TurnManager.ChangeTurn();
        }
    }
}
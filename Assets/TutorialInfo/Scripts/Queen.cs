using UnityEngine;

public class Queen : MonoBehaviour
{
    public static Queen selectedQueen;
    public int team;

    void OnMouseDown()
    {
        if (team != TurnManager.currentTeam)
        {
            Debug.Log("It's not your turn!");
            return;
        }

        selectedQueen = this;
        Debug.Log("Queen selected!");
    }

    public void MoveTo(Vector3 position)
    {
        float xDistance = Mathf.Abs(transform.position.x - position.x);
        float zDistance = Mathf.Abs(transform.position.z - position.z);

        // Queen moves straight
        bool straightMove = xDistance < 0.1f || zDistance < 0.1f;

        // Queen moves diagonally
        bool diagonalMove = Mathf.Abs(xDistance - zDistance) < 0.1f;

        if (straightMove || diagonalMove)
        {
            transform.position = position;
            selectedQueen = null;

            TurnManager.ChangeTurn();
        }
    }
}
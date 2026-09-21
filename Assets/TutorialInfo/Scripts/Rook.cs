using UnityEngine;

public class Rook : MonoBehaviour
{
    public static Rook selectedRook;
    public int team;

    void OnMouseDown()
    {
        // Only select the Rook if it is your turn
        if (team != TurnManager.currentTeam)
        {
            Debug.Log("It's not your turn!");
            return;
        }

        selectedRook = this;
        Debug.Log("Rook selected!");
    }

    public void MoveTo(Vector3 position)
    {
        float xDistance = Mathf.Abs(transform.position.x - position.x);
        float zDistance = Mathf.Abs(transform.position.z - position.z);

        // Rook moves straight, not diagonally
        if (xDistance < 0.1f || zDistance < 0.1f)
        {
            transform.position = position;
            selectedRook = null;

            // Change turn
            TurnManager.ChangeTurn();
        }
    }
}
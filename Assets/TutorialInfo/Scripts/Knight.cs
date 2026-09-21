using UnityEngine;

public class Knight : MonoBehaviour
{
    public static Knight selectedKnight;
    public int team;

    void OnMouseDown()
    {
        // Only select the Knight if it is your turn
        if (team != TurnManager.currentTeam)
        {
            Debug.Log("It's not your turn!");
            return;
        }

        selectedKnight = this;
        Debug.Log("Knight selected!");
    }

    public void MoveTo(Vector3 position)
    {
        float xDistance = Mathf.Abs(transform.position.x - position.x);
        float zDistance = Mathf.Abs(transform.position.z - position.z);

        // Knight moves 2 columns and 1 row
        bool moveX = Mathf.Abs(xDistance - 1.50f) < 0.1f &&
                     Mathf.Abs(zDistance - 0.77f) < 0.1f;

        // Knight moves 1 column and 2 rows
        bool moveZ = Mathf.Abs(xDistance - 0.75f) < 0.1f &&
                     Mathf.Abs(zDistance - 1.54f) < 0.1f;

        if (moveX || moveZ)
        {
            transform.position = position;
            selectedKnight = null;

            // Change turn
            TurnManager.ChangeTurn();
        }
    }
}
using UnityEngine;

public class Chawn : MonoBehaviour
{
    public static Chawn selectedChawn;
    public int team;

    void OnMouseDown()
    {
        if (team != TurnManager.currentTeam)
        {
            Debug.Log("It's not your turn!");
            return;
        }

        selectedChawn = this;
        Debug.Log("Chawn selected!");
    }

    public void MoveTo(Vector3 position)
    {
        float xDistance = Mathf.Abs(transform.position.x - position.x);
        float zDistance = Mathf.Abs(transform.position.z - position.z);

        // Chawn moves diagonally one square
        if (xDistance > 0.6f && xDistance < 0.9f &&
            zDistance > 0.6f && zDistance < 0.9f)
        {
            transform.position = position;
            selectedChawn = null;

            TurnManager.ChangeTurn();
        }
    }
}
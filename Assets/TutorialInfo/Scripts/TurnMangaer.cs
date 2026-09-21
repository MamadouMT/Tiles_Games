using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static int currentTeam = 1;

    public static void ChangeTurn()
    {
        if (currentTeam == 1)
        {
            currentTeam = 2;
        }
        else
        {
            currentTeam = 1;
        }
    }
}
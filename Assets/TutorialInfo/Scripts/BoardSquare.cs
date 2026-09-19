using UnityEngine;

public class BoardSquare : MonoBehaviour
{
    public int x;
    public int y;

    public void SetPosition(int newX, int newY)
    {
        x = newX;
        y = newY;
    }

    void OnMouseDown()
    {
        Debug.Log("Clicked square: " + x + ", " + y);
    }
}
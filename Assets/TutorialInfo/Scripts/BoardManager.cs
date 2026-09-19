using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public GameObject squarePrefab;

    public float squareSize = 1f;
    public float squareHeight = 0.1f;

    public Vector3 boardStartPosition = Vector3.zero;

    void Start()
    {
        CreateClickableBoard();
    }

    void CreateClickableBoard()
    {
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                Vector3 position = new Vector3(
                    boardStartPosition.x + x * squareSize,
                    boardStartPosition.y + squareHeight,
                    boardStartPosition.z + y * squareSize
                );

                GameObject square = Instantiate(
                    squarePrefab,
                    position,
                    Quaternion.identity
                );

                BoardSquare boardSquare =
                    square.GetComponent<BoardSquare>();

                boardSquare.SetPosition(x, y);

                square.transform.parent = transform;
            }
        }
    }
}
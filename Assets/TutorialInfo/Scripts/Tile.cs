using UnityEngine;

public class Tile : MonoBehaviour
{
    private Renderer tileRenderer;
    private Color originalColor;

    private static Tile selectedTile;

    void Start()
    {
        tileRenderer = GetComponent<Renderer>();
        originalColor = tileRenderer.material.color;
    }

    void OnMouseDown()
    {
        // Find which piece is selected
        int movingTeam = 0;

        if (King.selectedKing != null)
            movingTeam = King.selectedKing.team;
        else if (Rook.selectedRook != null)
            movingTeam = Rook.selectedRook.team;
        else if (Knight.selectedKnight != null)
            movingTeam = Knight.selectedKnight.team;
        else if (Bishop.selectedBishop != null)
            movingTeam = Bishop.selectedBishop.team;
        else if (Queen.selectedQueen != null)
            movingTeam = Queen.selectedQueen.team;
        else if (Chawn.selectedChawn != null)
            movingTeam = Chawn.selectedChawn.team;

        // Remember the selected piece's position
        Vector3 oldPosition = Vector3.zero;

        if (King.selectedKing != null)
            oldPosition = King.selectedKing.transform.position;
        else if (Rook.selectedRook != null)
            oldPosition = Rook.selectedRook.transform.position;
        else if (Knight.selectedKnight != null)
            oldPosition = Knight.selectedKnight.transform.position;
        else if (Bishop.selectedBishop != null)
            oldPosition = Bishop.selectedBishop.transform.position;
        else if (Queen.selectedQueen != null)
            oldPosition = Queen.selectedQueen.transform.position;
        else if (Chawn.selectedChawn != null)
            oldPosition = Chawn.selectedChawn.transform.position;

        // Find a piece on this tile
        GameObject pieceOnTile = null;

        GameObject[] pieces = GameObject.FindGameObjectsWithTag("Piece");

        foreach (GameObject piece in pieces)
        {
            float xDistance = Mathf.Abs(piece.transform.position.x - transform.position.x);
            float zDistance = Mathf.Abs(piece.transform.position.z - transform.position.z);

            if (xDistance < 0.3f && zDistance < 0.3f)
            {
                // Don't count the piece we're moving
                if (piece == King.selectedKing?.gameObject ||
                    piece == Rook.selectedRook?.gameObject ||
                    piece == Knight.selectedKnight?.gameObject ||
                    piece == Bishop.selectedBishop?.gameObject ||
                    piece == Queen.selectedQueen?.gameObject ||
                    piece == Chawn.selectedChawn?.gameObject)
                {
                    continue;
                }

                pieceOnTile = piece;
                break;
            }
        }

        // Check the team of the piece on the tile
        if (pieceOnTile != null)
        {
            int otherTeam = 0;

            if (pieceOnTile.GetComponent<King>() != null)
                otherTeam = pieceOnTile.GetComponent<King>().team;
            else if (pieceOnTile.GetComponent<Rook>() != null)
                otherTeam = pieceOnTile.GetComponent<Rook>().team;
            else if (pieceOnTile.GetComponent<Knight>() != null)
                otherTeam = pieceOnTile.GetComponent<Knight>().team;
            else if (pieceOnTile.GetComponent<Bishop>() != null)
                otherTeam = pieceOnTile.GetComponent<Bishop>().team;
            else if (pieceOnTile.GetComponent<Queen>() != null)
                otherTeam = pieceOnTile.GetComponent<Queen>().team;
            else if (pieceOnTile.GetComponent<Chawn>() != null)
                otherTeam = pieceOnTile.GetComponent<Chawn>().team;

            // Can't capture your own piece
            if (otherTeam == movingTeam)
            {
                Debug.Log("You can't capture your own piece!");
                return;
            }
        }

        // Move the selected piece
        if (King.selectedKing != null)
            King.selectedKing.MoveTo(transform.position);
        else if (Rook.selectedRook != null)
            Rook.selectedRook.MoveTo(transform.position);
        else if (Knight.selectedKnight != null)
            Knight.selectedKnight.MoveTo(transform.position);
        else if (Bishop.selectedBishop != null)
            Bishop.selectedBishop.MoveTo(transform.position);
        else if (Queen.selectedQueen != null)
            Queen.selectedQueen.MoveTo(transform.position);
        else if (Chawn.selectedChawn != null)
            Chawn.selectedChawn.MoveTo(transform.position);

        // Check if the piece actually moved
        bool pieceMoved = false;

        if (King.selectedKing == null &&
            Rook.selectedRook == null &&
            Knight.selectedKnight == null &&
            Bishop.selectedBishop == null &&
            Queen.selectedQueen == null &&
            Chawn.selectedChawn == null)
        {
            pieceMoved = true;
        }

        // Only capture if the move was successful
        if (pieceMoved && pieceOnTile != null)
        {
            Destroy(pieceOnTile);
            Debug.Log("Piece captured!");
        }

        // Highlight tile
        if (selectedTile != null)
        {
            selectedTile.tileRenderer.material.color =
                selectedTile.originalColor;
        }

        tileRenderer.material.color = Color.yellow;
        selectedTile = this;
    }
}
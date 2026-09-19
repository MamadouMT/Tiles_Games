using UnityEngine;

public class Tile : MonoBehaviour
{
    private Renderer tileRenderer;

    void Start()
    {
        tileRenderer = GetComponent<Renderer>();
        Debug.Log("Tile started!");
    }

    void OnMouseDown()
    {
        Debug.Log("TILE CLICKED!");

        tileRenderer.material.color = Color.yellow;
    }
}
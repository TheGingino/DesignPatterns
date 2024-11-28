using UnityEngine;

/// <summary>
/// Vertegenwoordigt een enkele tegel binnen het grid.
/// </summary>
public class Tile
{
    /// <summary>
    /// De wereldpositie van de tegel.
    /// </summary>
    public Vector3 WorldPosition { get; }

    /// <summary>
    /// De grid-coördinaten van de tegel.
    /// </summary>
    public Vector2Int GridPosition { get; }

    /// <summary>
    /// Geeft aan of de tegel bezet is.
    /// </summary>
    public bool IsOccupied { get; set; }

    /// <summary>
    /// Initialiseert een nieuwe instance van de Tile-klasse.
    /// </summary>
    /// <param name="worldPosition">De wereldpositie van de tegel.</param>
    /// <param name="gridPosition">De grid-coördinaten van de tegel.</param>
    public Tile(Vector3 worldPosition, Vector2Int gridPosition)
    {
        WorldPosition = worldPosition;
        GridPosition = gridPosition;
        IsOccupied = false;
    }
}

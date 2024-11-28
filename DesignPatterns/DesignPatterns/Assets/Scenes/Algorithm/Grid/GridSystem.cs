using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Beheert het grid-systeem binnen de Unity-omgeving.
/// </summary>
public class GridSystem : MonoBehaviour
{
    [SerializeField] private int width = 10;
    [SerializeField] private int height = 10;
    [SerializeField] private float cellSize = 10f;
    
    private Tile[,] _grid;

    private void Awake()
    {
        CreateGrid();
    }

    /// <summary>
    /// Maakt het grid aan op basis van de opgegeven breedte, hoogte en celgrootte.
    /// </summary>
    private void CreateGrid()
    {

        _grid = new Tile[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 worldPosition = new Vector3(x * cellSize, 0f, y * cellSize);
                var newTile = new Tile(worldPosition, new Vector2Int(x, y));
                _grid[x, y] = newTile;

                newTile.IsOccupied = x == 3;

            }
        }
    }

    /// <summary>
    /// Haalt de tegel op de opgegeven grid-coördinaten.
    /// </summary>
    /// <param name="x">De x-coördinaat van de tegel.</param>
    /// <param name="y">De y-coördinaat van de tegel.</param>
    /// <returns>De tegel op de gegeven coördinaten of null als de coördinaten buiten het bereik liggen.</returns>
    public Tile GetTile(int x, int y)
    {
        if (x < 0 || x >= width || y < 0 || y >= height)
        {
            return null;
        }

        return _grid[x, y];
    }

    /// <summary>
    /// Haalt de buren van de opgegeven tegel op.
    /// </summary>
    /// <param name="tile">De tegel waarvan de buren worden opgehaald.</param>
    /// <returns>Een lijst met buren van de opgegeven tegel.</returns>
    public List<Tile> GetNeighbors(Tile tile)
    {
        var neighbors = new List<Tile>();

        for (int xOffset = -1; xOffset <= 1; xOffset++)
        {
            for (int yOffset = -1; yOffset <= 1; yOffset++)
            {
                if (xOffset == 0 && yOffset == 0)
                {
                    continue;
                }

                int checkX = tile.GridPosition.x + xOffset;
                int checkY = tile.GridPosition.y + yOffset;

                if (checkX >= 0 && checkX < width && checkY >= 0 && checkY < height)
                {
                    neighbors.Add(_grid[checkX, checkY]);
                }
            }
        }

        return neighbors;
    }

    /// <summary>
    /// Converteert grid-coördinaten naar wereldposities.
    /// </summary>
    /// <param name="x">De x-coördinaat op de grid.</param>
    /// <param name="y">De y-coördinaat op de grid.</param>
    /// <returns>De wereldpositie overeenkomstig de grid-coördinaten.</returns>
    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x * cellSize, 0f, y * cellSize);
    }

    /// <summary>
    /// Converteert wereldposities naar grid-coördinaten.
    /// </summary>
    /// <param name="worldPosition">De wereldpositie die geconverteerd moet worden.</param>
    /// <returns>De grid-coördinaten overeenkomstig de wereldpositie.</returns>
    public Vector2Int GetGridPosition(Vector3 worldPosition)
    {
        int x = Mathf.FloorToInt(worldPosition.x / cellSize);
        int y = Mathf.FloorToInt(worldPosition.z / cellSize);
        return new Vector2Int(x, y);
    }


    private void OnDrawGizmos()
    {
        if (_grid == null) return;
        
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var currentTile = GetTile(x, y);
                Gizmos.color =currentTile.IsOccupied ? Color.red : Color.cyan;
                var point = new Vector3(x, y, 0) * cellSize;
                Gizmos.DrawWireCube(point, new Vector3(cellSize,cellSize,0));
            }
        }
    }
    
    
}
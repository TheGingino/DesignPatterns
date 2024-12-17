using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorGrid : MonoBehaviour
{
    [SerializeField] private int gridWidth = 10;
    [SerializeField] private int gridHeight = 10;
    [SerializeField] private int tileSize = 50;

    private SpriteRenderer[,] _tileGrid;
    private float _unitSize;

    // Eigenschappen voor Width en Height
    public int Width => _tileGrid.GetLength(0);
    public int Height => _tileGrid.GetLength(1);
    public float UnitSize => _unitSize;

    void Start()
    {
        _unitSize = tileSize / 100f;
        InitializeGrid();
        AddBoxCollider();
    }

    private void InitializeGrid()
    {
        _tileGrid = new SpriteRenderer[gridWidth, gridHeight];

        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                var tile = new GameObject($"Tile_{x}_{y}");
                tile.transform.position = new Vector3(x * _unitSize, y * _unitSize, 0);
                tile.transform.parent = transform;

                var sr = tile.AddComponent<SpriteRenderer>();
                var color = GetRandomColor();
                sr.sprite = CreateDefaultSprite(Color.white);
                sr.color = color;

                _tileGrid[x, y] = sr;
            }
        }
    }

    private void AddBoxCollider()
    {
        var collider = gameObject.AddComponent<BoxCollider2D>();
        collider.size = new Vector2(Width * _unitSize, Height * _unitSize);
        collider.offset = new Vector2((Width * _unitSize) / 2, (Height * _unitSize) / 2);
    }

    private static Color GetRandomColor()
    {
        var colors = new[]
        {
            Color.red,
            Color.blue,
            Color.green,
            Color.yellow,
            new Color(1f, 0f, 1f) // Paars/Magenta
        };

        return colors[Random.Range(0, colors.Length)];
    }

    private Sprite CreateDefaultSprite(Color targetColor)
    {
        var texture = new Texture2D(tileSize, tileSize);
        var colors = new Color[tileSize * tileSize];
        for (var i = 0; i < colors.Length; i++)
        {
            colors[i] = targetColor;
        }

        texture.SetPixels(colors);
        texture.Apply();

        var pixelsPerUnit = 100f;
        return Sprite.Create(texture, new Rect(0, 0, tileSize, tileSize), Vector2.one * 0.5f, pixelsPerUnit);
    }

    public Color GetPixel(int x, int y)
    {
        return _tileGrid[x, y].color;
    }

    public void SetPixel(Color color, int x, int y)
    {
        _tileGrid[x, y].color = color;
    }
}

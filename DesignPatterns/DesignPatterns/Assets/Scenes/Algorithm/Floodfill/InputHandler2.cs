using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class InputHandler2 : MonoBehaviour
{
    [SerializeField] private ColorGrid colorGrid;
    [SerializeField] private FloodFill floodFill;

    void OnMouseDown()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 localPosition = transform.InverseTransformPoint(mousePosition);
        
        // we bepalen waar je in het grid klikt (welke pixel)
        int x = Mathf.FloorToInt(localPosition.x / colorGrid.UnitSize);
        int y = Mathf.FloorToInt(localPosition.y / colorGrid.UnitSize);

        floodFill.StartFloodFill(colorGrid, x, y, floodFill.ReplaceColor);
    }
}
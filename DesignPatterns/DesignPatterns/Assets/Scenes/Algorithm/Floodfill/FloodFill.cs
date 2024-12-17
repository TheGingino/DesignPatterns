using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FloodFill : MonoBehaviour
{
    [SerializeField] private Color replaceColor = Color.red;

    public Color ReplaceColor => replaceColor;

    public void StartFloodFill(ColorGrid colorGrid, int startX, int startY, Color newColor)
    {
        if (colorGrid == null) return;

        if (startX < 0 || startX >= colorGrid.Width || startY < 0 || startY >= colorGrid.Height) return;

        Color targetColor = colorGrid.GetPixel(startX, startY);
        FloodFillArea(colorGrid, startX, startY, targetColor, newColor);
    }

    // opdracht: laat deze method werken
    private void FloodFillArea(ColorGrid colorGrid, int x, int y, Color targetColor, Color replacementColor)
    {
        // Stap 1: als de x en y niet 'binnen' de grid width en height liggen, return dan
        if (x >= colorGrid.Width || y >= colorGrid.Height || x < 0 || y < 0)
        {
            return;
        }
        
        // Stap 2: Haal de huidige kleur van de tile op (deze x en y) en sla deze op in een variabele

        Color currentColorOnTile = colorGrid.GetPixel(x, y);
        
        // Stap 3: Stop (return) als de currentColor niet overeenkomt met de targetColor

        if (currentColorOnTile != targetColor) return;


        // Stap 4: Stop (return) als de huidige kleur al de replacementColor is

        if (currentColorOnTile == replacementColor) return;

        
        // Stap 5: Verander de kleur van de huidige tile (colorGrid heeft een SetPixel functie)

        colorGrid.SetPixel(replacementColor, x, y);
        
        // Stap 6: Roep deze functie ook recursief aan voor aangrenzende tiles
        FloodFillArea(colorGrid, x-1,y,targetColor,replacementColor);
        FloodFillArea(colorGrid, x+1,y,targetColor,replacementColor);
        FloodFillArea(colorGrid, x,y -1,targetColor,replacementColor);
        FloodFillArea(colorGrid, x,y +1,targetColor,replacementColor);

    }
}

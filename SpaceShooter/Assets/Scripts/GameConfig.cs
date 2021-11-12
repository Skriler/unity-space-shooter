using UnityEngine;

public static class GameConfig
{
    public static readonly Vector2 minCoords = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); 
    public static readonly Vector2 maxCoords = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
}

using UnityEngine;

public static class SpriteUtils
{
    public static float[] GetRendererBounds(Renderer renderer)
    {
        var bounds = renderer.bounds;
        float minX = bounds.min.x;
        float maxX = bounds.max.x;
        float minY = bounds.min.y;
        float maxY = bounds.max.y;
        return new[] { minX, maxX, minY, maxY };
    }
}
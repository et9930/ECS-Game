using Entitas;

[Game]
public class BoundingBoxComponent : IComponent
{
    public float minX;
    public float minY;
    public float minZ;
    public float maxX;
    public float maxY;
    public float maxZ;
}
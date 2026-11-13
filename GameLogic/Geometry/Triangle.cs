namespace GameLogic.Geometry;

public class Triangle
{
    public Vertex VertexA;
    public Vertex VertexB;
    public Vertex VertexC;
    

    public Triangle(Vertex a, Vertex b, Vertex c)
    {
        VertexA = a;
        VertexB = b;
        VertexC = c;
    }
}
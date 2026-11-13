using System.Numerics;
using GameLogic.Geometry;

namespace GameLogic;

public class World
{
    public List<Entities> EntitiesList = new List<Entities>();

    public World()
    {
        Vector3 A = new(320f, 150f, 0);
        Vector3 B = new(180f, 420f, 0);
        Vector3 C = new(480f, 390f, 0);
        Vector3 D = new(540f, 360f, 0);
        Vertex a = new Vertex(A);
        Vertex b = new Vertex(B);
        Vertex c = new Vertex(C);
        Vertex d = new Vertex(D);
        Triangle triangle = new(a, b, c);
        Triangle triangle2 = new(a, b, d);
        Entities entity = new Entities();
        entity.Triangles.Add(triangle);
        entity.Triangles.Add(triangle2);
        EntitiesList.Add(entity);
    }
}
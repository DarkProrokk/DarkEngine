using System.Numerics;
using GameLogic;
using Raylib_cs;
namespace GraphicsLibV1;

public static class Ui
{
    public static void Run()
    {
        Raylib.InitWindow(800, 600, "My Renderer");
        Raylib.SetTargetFPS(60);
        var actualPosition = new Vector2(100, 200);
        bool mouseWasClicked = false;
        World world = new World();
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.Black);

            // Raylib.DrawPixel(100, 100, Color.Red);
            // var cursorPosition = Raylib.GetMousePosition();
            foreach (var entity in world.EntitiesList)
            {
                foreach (var triangle in entity.Triangles)
                {
                    Vector2 A = new Vector2(triangle.VertexA.position.X, triangle.VertexA.position.Y);
                    Vector2 B = new Vector2(triangle.VertexB.position.X, triangle.VertexB.position.Y);
                    Vector2 C = new Vector2(triangle.VertexC.position.X, triangle.VertexC.position.Y);
                    Draw(A, B, C);
                }
            }
            
            //Console.WriteLine(mouseWasClicked);
            // if (Raylib.IsMouseButtonPressed(MouseButton.Left))
            // {
            //     mouseWasClicked = !mouseWasClicked;
            // }
            //
            // if (mouseWasClicked)
            // {
            //     actualPosition = cursorPosition;
            // }

           // Raylib.DrawRectangle((int)actualPosition.X, (int)actualPosition.Y, 100, 100, Color.Green);
            //Raylib.DrawCircle(400, 300, 50, Color.Blue);

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }


    public static void Draw(Vector2 a, Vector2 b, Vector2 c)
    {
        Vector2 extremePoints;
        Vector2 lowerPoints;
        lowerPoints.X = MathF.Min(Math.Min(a.X, b.X), c.X);
        lowerPoints.Y = MathF.Min(Math.Min(a.Y, b.Y), c.Y);
        extremePoints.X = Math.Max(a.X, Math.Max(c.X, b.X));
        extremePoints.Y = Math.Max(a.Y, Math.Max(c.Y, b.Y));
        for (int y = 0; y <= extremePoints.Y; y++)  
        {
            Vector2 p = new Vector2();
            p.Y = y;
            if (y <lowerPoints.Y) continue;
            for (int x = (int)lowerPoints.X; x <= extremePoints.X; x++)
            {
                p.X = x;
                var abp = EdgeFunction(a, b, p);
                var bcp = EdgeFunction(b, c, p);
                var cap = EdgeFunction(c, a, p);
                var abc = EdgeFunction(a, b, p);
                var clockWise = abp > 0 || bcp > 0 || cap > 0;
                var counterClockWise = abp < 0 || bcp < 0 || cap < 0;
                if ( !(clockWise && counterClockWise) )
                {
                    Raylib.DrawPixel(x, y, Color.Red);
                    // if (clockWise)
                    // {
                    //     if (abp == bcp && bcp == cap)
                    //     {
                    //         chars[y].Add('#'); 
                    //     }
                    //
                    //     else if (abp >= bcp && bcp <= cap)
                    //     {
                    //         chars[y].Add(secondSideSign); 
                    //     }
                    //     else if (bcp >= cap && cap <= abp)
                    //     {
                    //         chars[y].Add(bottomSign); 
                    //     }
                    //     else
                    //     {
                    //         chars[y].Add(sideSign); 
                    //     }
                    // }
                    // else
                    // {
                    //     if (abp == bcp && bcp == cap)
                    //     {
                    //         chars[y].Add('#'); 
                    //     }
                    //
                    //     else if (!(abp >= bcp || bcp <= cap))
                    //     {
                    //         chars[y].Add(sideSign); 
                    //     }
                    //     else if (!(bcp >= cap || cap <= abp))
                    //     {
                    //         chars[y].Add(bottomSign); 
                    //     }
                    //     else
                    //     {
                    //         chars[y].Add(secondSideSign); 
                    //     }
                    // }
                     
                    
                }
                else
                {
                    
                    //chars[y].Add('.');
                }
            }
        }

        //return chars.Slice((int)lowerPoints.Y, (int)extremePoints.Y - (int)lowerPoints.Y);

    }
    
    private static float EdgeFunction(Vector2 a, Vector2 b, Vector2 c)
    {
        return (b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X);
    }

}
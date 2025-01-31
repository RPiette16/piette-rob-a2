// Include the namespaces (code libraries) you need below.
using System;
using System.Data;
using System.Numerics;
using Raylib_cs;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        //Sparks
    Vector2[] Sparks = new Vector2[100];
        void ResetSparks() 
        {
            for (int spark = 0; spark < Sparks.Length; spark++) 
            {
                Sparks[spark] = new Vector2(Random.Float() * Window.Width, Random.Float() * Window.Height);
            }
        }
//Ashes
Vector2[] Ashes = new Vector2[50];
        void ResetAshes()
        {
            for (int ash = 0; ash < Ashes.Length; ash++)
            {
                Ashes[ash] = new Vector2(ash * 8, Random.Integer(-50, -5));
            }
        }
        
        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("Black Phoenix");
            Window.SetSize(400, 400);
            ResetAshes();
            ResetSparks();
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.DarkGray);
            if (Input.IsKeyboardKeyDown(KeyboardInput.Space))
            {
                //Make ashes fall down the screen
                for (int ash = 0; ash < Ashes.Length; ash++)
                {
                    Ashes[ash] += Vector2.UnitY;
                    Draw.FillColor = Color.Gray;
                    Draw.Circle(Ashes[ash], 2f);
                }
                //make random sparks pop across the window
                for (int spark = 0; spark < Sparks.Length; spark++) 
                {
                    Draw.FillColor = Color.Magenta;
                    Draw.Circle(Sparks[spark], 2f);
                }
            }
            else ResetAshes();
            ResetSparks();   
            //Phoenix head
            if (Input.IsKeyboardKeyDown(KeyboardInput.Space))
            {
                Draw.FillColor = Color.Magenta;
            }
            else
            {
                Draw.FillColor = Color.Black;
            }
            Draw.Triangle(200, 20, 220, 50, 180, 50);
            Draw.Square(180, 50, 40);

            //Phoenix tails
            for (int t = 0; t < 3; t++)
            {
                if (Input.IsKeyboardKeyDown(KeyboardInput.Space))
                {
                    Draw.FillColor = Color.Magenta;
                }
                int x = t * 80;
                // First tail
                Draw.Triangle(120 + x, 200, 150 + x, 230, 90 + x, 230);
            }
            //Phoenix Wings
            for (int i = 0; i < 3; i++)
            {
                int y = i * 30 + 60; // Adjust y position based on the loop index
                Draw.FillColor = Color.Black;

                // Draw the first triangle
                Draw.Quad(260, y, 260, y + 10, 200, y + 70, 200, y + 60);

                // Draw the second triangle
                Draw.Quad(140, y, 200, y + 60, 200, y + 70, 140, y + 10);
            }
        }
    }
}



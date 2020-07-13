using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
			//Console.SetBufferSize(80, 25);
			Walls walls = new Walls(80, 25);
			walls.Draw();

			FoodCreator foodCreator = new FoodCreator(80, 25, '$');
			Point food = foodCreator.CreateFood();
			food.Draw();

			Point p = new Point(4, 5, '*');
			Snake snek = new Snake(p, 4, Direction.RIGHT);
			snek.Draw();
			 
			 while (true)
			 {
				if(walls.IsHit(snek) || snek.IsHitTail())
				{
					break;
				}
				if (snek.Eat(food))
				{
					food = foodCreator.CreateFood();
					food.Draw();
				}
				else
				{
					snek.Move();
				}

				Thread.Sleep(100);

				 if (Console.KeyAvailable)
				 {
					 ConsoleKeyInfo key = Console.ReadKey();
					 snek.HandleKey(key.Key);
				 }
			 }
			WriteGameOver(snek);
			Console.ReadLine();

		}
		static void Draw(Figure figure)
		{
			figure.Draw();
		}

		static void WriteGameOver(Snake snake)
		{
			int xOffset = 25;
			int yOffset = 8;
			Console.ForegroundColor = ConsoleColor.Red;
			Console.SetCursorPosition(xOffset, yOffset++);
			WriteText("=================", xOffset, yOffset++);
			WriteText("G A M E  O V E R", xOffset + 1, yOffset++);
			WriteText("S C O R E :", xOffset + 2, yOffset++);
			WriteText(snake.foodCount.ToString(), xOffset + 2, yOffset++);
			WriteText("=================", xOffset, yOffset++);
		}

		static void WriteText(String text, int xOffset, int yOffset)
		{
			Console.SetCursorPosition(xOffset, yOffset);
			Console.WriteLine(text);
		}
	}
}

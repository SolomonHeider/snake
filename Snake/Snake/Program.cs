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

			VerticalLine vl = new VerticalLine(0, 10, 5, '%');
			Draw(vl);

			Point p = new Point(4, 5, '*');
			Figure fSnake = new Snake(p, 4, Direction.RIGHT);
			Draw(fSnake);
			Snake snake = (Snake)fSnake;

			HorizontalLine hl = new HorizontalLine(0, 5, 6, '&');

			List<Figure> figures = new List<Figure>();
			figures.Add(fSnake);
			figures.Add(vl);
			figures.Add(hl);

			foreach (var f in figures)
			{
				f.Draw();
			}
			Console.Read();
			//Console.SetBufferSize(80, 25);

			/* HorizontalLine upLine = new HorizontalLine(0,78,0,'+');
			 HorizontalLine downLine = new HorizontalLine(0, 78, 24, '+');
			 VerticalLine leftLine = new VerticalLine(0, 24, 0, '+');
			 VerticalLine rightLine = new VerticalLine(0, 24, 78, '+');
			 upLine.Draw();
			 downLine.Draw();
			 leftLine.Draw();
			 rightLine.Draw();

			 Point p = new Point(4, 5, '*');
			 Snake snek = new Snake(p, 4, Direction.RIGHT);
			 snek.Draw();

			 FoodCreator foodCreator = new FoodCreator(80, 25, '$');
			 Point food = foodCreator.CreateFood();
			 food.Draw();

			 while (true)
			 {
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
			 }*/

		}
		static void Draw(Figure figure)
		{
			figure.Draw();
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Snake
{
	class Program
	{
		static void Main( string[] args )
		{
            Console.SetWindowSize( 80, 30);
			Console.SetBufferSize( 80, 30);

			Walls walls = new Walls( 80, 30 );
			walls.Draw();

			// Отрисовка точек			
			Point p = new Point( 4, 5, '*' );
			Snake snake = new Snake( p, 4, Direction.RIGHT );
			snake.Draw();

			FoodCreator foodCreator = new FoodCreator( 80, 30, '@' );
			Point food = foodCreator.CreateFood();
			food.Draw();

			while (true)
			{
				if ( walls.IsHit(snake) || snake.IsHitTail() )
				{
					break;
				}
				if(snake.Eat( food ) )
				{
					food = foodCreator.CreateFood();
					food.Draw();
				}
				else
				{
					snake.Move();
				}

				Thread.Sleep( 100 );
				if ( Console.KeyAvailable )
				{
					ConsoleKeyInfo key = Console.ReadKey();
					snake.HandleKey( key.Key );
				}
			}
			WriteGameOver();
			Console.ReadKey();
      }


		static void WriteGameOver()
		{
			int xOffset = 25;
            int yOffset = 8;
			Console.SetCursorPosition( xOffset, yOffset++ );
			WriteText( "G A M E    O V E R", xOffset + 1, yOffset++ );
		}

		static void WriteText( String text, int xOffset, int yOffset )
		{
			Console.SetCursorPosition( xOffset, yOffset );
			Console.WriteLine( text );
		}

	}
}

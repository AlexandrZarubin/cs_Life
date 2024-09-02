using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleLife
{
	internal class Program
	{
		[DllImport("kernel32.dll", ExactSpelling = true)]
		public static extern IntPtr GetConsoleWindow();
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
		private const int MAXIMiZE = 3;
		static void Main(string[] args)
		{
			Console.ReadLine();
			Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
			ShowWindow(GetConsoleWindow(), MAXIMiZE);
			Console.CursorVisible = false;
			Console.SetCursorPosition(0, 0);
			int oldRows = 168;
			int oldCols = 630;
			int oldFontSize = 6;
			int newFontSize = 12;
			double scaleFactor = (double)oldFontSize / newFontSize;
			int newRows = (int)(oldRows * scaleFactor);
			int newCols = (int)(oldCols * scaleFactor);
			//int rows = Console.WindowHeight; // Количество строк в окне консоли
			//int cols = Console.WindowWidth;  // Количество символов в строке консоли
			var gameEngine = new GameEngine
			(
				//rows:168,
				//cols:630,
				rows: newRows,
				cols: newCols,
				density:25
			);
			while(true)
			{
				Console.Title=gameEngine.CurrentGeneration.ToString();

				var field=gameEngine.GetCurrentGeneration();

				for(int y = 0; y < field.GetLength(1); y++)
				{
					var str = new char[field.GetLength(0)];
					for(int x = 0; x < field.GetLength(0); x++)
					{
						if (field[x, y])
							str[x] = '#';
						else str[x] = ' ';
					}
                    Console.WriteLine(str);
                }
				Console.SetCursorPosition(0, 0);
				gameEngine.NextGeneration();
				Thread.Sleep(50);

			}
		}
	}
}

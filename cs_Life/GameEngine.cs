using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_Life
{
	public class GameEngine
	{
		private bool[,] field;
		private readonly int rows;
		private readonly int cols;
		private Random random=new Random();
		public GameEngine(int rows, int cols,int density)
		{
			this.rows = rows;
			this.cols = cols;
			field = new bool[cols, rows];
			for (int x = 0; x < cols; x++)
			{
				for (int y = 0; y < rows; y++)
				{
					field[x, y] = random.Next((int)nudDensity.Value) == 0;
				}
			}
		}

	}
}

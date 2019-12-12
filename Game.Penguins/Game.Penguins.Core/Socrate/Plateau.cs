using Game.Penguins.Core.Interfaces.Game.GameBoard;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Penguins.Core.Socrate
{
    public class Board : IBoard
    {
        //public ICell[,] Plateau => throw new NotImplementedException();
		private int case1poisson = 34;
        private int case2poissons = 20;
        private int case3poissons = 10;

		ICell[,] IBoard.Board { get { return BoardObject; } }
		public Cell[,] BoardObject { get; set; }

		//génération aléatoire de la position des poissons sur le plateau
		public List<int> GenerationPoisson()
        {
            Random rand = new Random();
           
            List<int> tab = new List<int>(64);
            List<int> tabFinal = new List<int>();

            for (int i = 0; i < 34; i++)
            {
                tab.Add(1);
            }
            for (int i = 35; i < 54; i++)
            {
                tab.Add(2);
            }
            for (int i = 55; i < 64; i++)
            {
                tab.Add(3);
            }

            while (tab.Count > 0)
            {
                int index = rand.Next(0, tab.Count);
				tabFinal.Add(tab[index]);
                tab.RemoveAt(index);
            }

			return tabFinal;
        }

        //génération du plateau de jeu principal
        public void GenerationPlateau()
		{
			int tailleX = 8;
			int tailleY = 8;

            List<int> tabPoisson = new List<int>(64);
            tabPoisson = GenerationPoisson();
            int tailleTab = 0;
            BoardObject = new Cell[8, 8];

			for (int i=0; i < tailleX; i++)
			{
				for (int j=0; j < tailleY; j++)
				{
                    Cell tempCell = new Cell();
                    tempCell.FishCount = tabPoisson[tailleTab];
                    BoardObject[i, j] = tempCell;
				}
                tailleTab++;
			}

            for (int i = 0; i < tailleX; i++)
            {
                for (int j = 0; j < tailleY; j++)
                {
					Cell tempCell = new Cell();
					tempCell.FishCount = tabPoisson[tailleTab];
					BoardObject[i, j] = tempCell;
                }
            }
        }

			/*système des IAs : -pour l'IA de niveau 1 : elle cherche en priorité à récupérer les cases qui comportes 1 poisson puis 2 puis 3
								-pour l'IA de niveau 2 : elle cherche en priorité à récupérer les cases qui comportes 2 poisson puis 3 puis 1
								-pour l'IA de niveau 3 : elle cherche en priorité à récupérer les cases qui comportes 3 poisson puis 2 puis 1 */
	}
}

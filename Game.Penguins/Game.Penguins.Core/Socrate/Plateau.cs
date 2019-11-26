using Game.Penguins.Core.Interfaces.Game.GameBoard;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Penguins.Core.Socrate
{
	class Plateau : IBoard
	{
		public ICell[,] Board => throw new NotImplementedException();
		private int case1poisson = 34;
		private int case2poissons = 20;
		private int case3poissons = 10;
   
		//génération aléatoire de la position des poissons sur le plateau
        public int[] GenerationPoisson()
		{
            Random rand = new Random(); // zbeub
            int randpoisson = rand.Next(1, 3);

            int tailleTab = 64;
            int[] tab = new int[tailleTab];
			for (int i = 0; i < tailleTab; i++)
			{
				randpoisson = rand.Next(1, 3);
				if (randpoisson == 3 && case3poissons > 0)
				{
					tab[i] = 3;
					case3poissons--;
				}
				else if (randpoisson == 2 && case2poissons > 0)
				{
                    tab[i] = 2;
					case2poissons--;
				}
				else if (randpoisson == 1 && case1poisson > 0)
				{
					tab[i] = 1;
					case1poisson--;
				}
                else if(case1poisson == 0 && case2poissons > 0 && case3poissons > 0)
				{
					randpoisson = rand.Next(2, 3);
                    tab[i] = randpoisson;
                }
				else if (case2poissons == 0 && case1poisson > 0 && case3poissons > 0)
				{
					randpoisson = rand.Next(1, 2);
                    if(randpoisson == 2){
                        randpoisson = 3;
                    }
					tab[i] = randpoisson;
				}
				else if (case3poissons == 0 && case2poissons > 0 && case1poisson > 0)
				{
					randpoisson = rand.Next(1, 2);
					tab[i] = randpoisson;
				}
                else if(case1poisson < 0 && case2poissons < 0 && case3poissons > 0)
                {
                    tab[i] = 3;
                }
                else if (case2poissons < 0 && case1poisson < 0 && case2poissons > 0)
                {
                    tab[i] = 2;
                }
                else if (case3poissons < 0 && case2poissons < 0 && case1poisson > 0)
                {
                    tab[i] = 1;
                }
            }

			return tab;
		}

		//génération du plateau de jeu principal
		public void GenerationPlateau()
		{
			int tailleX = 8;
			int tailleY = 8;
            int[,] tab = new int[8, 8];
            int[,] tabcoord = new int[8, 8];

            //int coordonneeX = 0;
            //int coordonneeY = 0;

            int[] tabPoisson = new int[64];
            tabPoisson = GenerationPoisson();
            int tailleTab = 0;

			for (int i=0; i < tailleX; i++)
			{
				for (int j=0; j < tailleY; j++)
				{
                    tab[i,j] = tabPoisson[tailleTab];
				}
                tailleTab++;
			}

            for (int i = 0; i < tailleX; i++)
            {
                for (int j = 0; j < tailleY; j++)
                {
                    tab[i, j] = tabPoisson[tailleTab];
                }
                tailleTab++;
            }
        }
	}
}

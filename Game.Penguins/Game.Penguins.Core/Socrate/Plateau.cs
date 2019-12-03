using Game.Penguins.Core.Interfaces.Game.GameBoard;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Penguins.Core.Socrate
{
    public class Board : IBoard
    {
        public ICell[,] Board => throw new NotImplementedException();
        private int case1poisson = 34;
        private int case2poissons = 20;
        private int case3poissons = 10;
        
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
            for (int i = 0; i < 20; i++)
            {
                tab.Add(2);
            }
            for (int i = 0; i < 10; i++)
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
        public int[,] GenerationPlateau()
		{
			int tailleX = 8;
			int tailleY = 8;
            int[,] tab = new int[8, 8];
            int[,] tabcoord = new int[8, 8];

            List<int> tabPoisson = new List<int>(64);
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
                    tabcoord[i, j] = tabPoisson[tailleTab];
                }
            }

            return tab;
        }

		public void GenerationPingouins()
		{
			int nb_joueurs = 0;
			int nb_pingouins = 0;
			//recupérer le nb de joueurs depuis le menu principal
			
			if (nb_joueurs == 2)
			{
				nb_pingouins = 8;
				int nb_pingouinsJ1 = 4;
				int nb_pingouinsJ2 = 4;
				for(int i = 0; i < nb_pingouinsJ1; i++)
				{
					//placement des pingouins
				}
				for(int i = 0; i < nb_pingouinsJ2; i++)
				{

				}
			}

			if (nb_joueurs == 3)
			{
				nb_pingouins = 9;
				int nb_pingouinsJ1 = 3;
				int nb_pingouinsJ2 = 3;
				int nb_pingouinsJ3 = 3;
				for (int i = 0; i < nb_pingouinsJ1; i++)
				{
					//placement des pingouins
				}
				for (int i = 0; i < nb_pingouinsJ2; i++)
				{

				}
				for (int i = 0; i < nb_pingouinsJ3; i++)
				{

				}
			}

			if (nb_joueurs == 4)
			{
				nb_pingouins = 8;
				int nb_pingouinsJ1 = 2;
				int nb_pingouinsJ2 = 2;
				int nb_pingouinsJ3 = 2;
				int nb_pingouinsJ4 = 2;
				for (int i = 0; i < nb_pingouinsJ1; i++)
				{
					//placement des pingouins
				}
				for (int i = 0; i < nb_pingouinsJ2; i++)
				{

				}
				for (int i = 0; i < nb_pingouinsJ3; i++)
				{

				}
				for (int i = 0; i < nb_pingouinsJ4; i++)
				{

				}
			}
		}
	}
}

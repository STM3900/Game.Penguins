using Game.Penguins.Core.Interfaces.Game.GameBoard;
using Game.Penguins.Core.Interfaces.Game.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using Game.Penguins.Core.Socrate;

namespace Game.Penguins.Core.Socrate
{
	public class CustomGame : IGame
	{
		IBoard IGame.Board => throw new NotImplementedException();
        
		public NextActionType NextAction { get; set; }

		public IPlayer CurrentPlayer { get { return CurrentPlayerObject; } }
		private int currentPlayerIndex = 0;
		public Player CurrentPlayerObject { get; set; }

		public IList<IPlayer> Players { get { return PlayersObject.OfType<IPlayer>().ToList(); } }
		private int penguinsByPlayer = 4;
		public List<Player> PlayersObject { get; set; } = new List<Player>();

		public event EventHandler StateChanged;

		public IPlayer AddPlayer(string playerName, PlayerType playerType)
		{
			var identifier = Guid.NewGuid();

			PlayersObject.Add(new Player()
			{
				Identifier = identifier,
				Name = playerName,
				PlayerType = playerType,
				Penguins = 0,
				Points = 0,
			});

			return PlayersObject.Last();
		}

		public void Move() //move pour les IAs ()
		{
			throw new NotImplementedException();
		}

		public void MoveManual(ICell origin, ICell destination)
		{
			//fonction de déplacement by Noé
		}

		public void PlacePenguin() //placement des IAs ()
		{
			throw new NotImplementedException();
		}

		public void PlacePenguinManual(int x, int y)
		{
			//fonction de placement
		}

		public void StartGame()
		{
			Board Plateau = new Board();
			{
				Board[,] new_Plateau = new Board[8, 8];
			}
			Plateau.GenerationPlateau();
			Plateau.GenerationPingouins();
		}
	}

	public class Player : IPlayer
	{
		private Guid identifier;
		public Guid Identifier
		{
			get { return identifier; }
			set
			{
				identifier = value;
				if (StateChanged != null)
					StateChanged.Invoke(this, null);
			}
		}

		private PlayerType playerType;
		public PlayerType PlayerType
		{
			get { return playerType; }
			set
			{
				playerType = value;
				if (StateChanged != null)
					StateChanged.Invoke(this, null);
			}
		}

		private PlayerColor color;
		public PlayerColor Color
		{
			get { return color; }
			set
			{
				color = value;
				if (StateChanged != null)
					StateChanged.Invoke(this, null);
			}
		}

		private string name;
		public string Name
		{
			get { return name; }
			set
			{
				name = value;
				if (StateChanged != null)
					StateChanged.Invoke(this, null);
			}
		}

		private int points;
		public int Points
		{
			get { return points; }
			set
			{
				points = value;
				if (StateChanged != null)
					StateChanged.Invoke(this, null);
			}
		}

		private int penguins;
		public int Penguins
		{
			get { return penguins; }
			set
			{
				penguins = value;
				if (StateChanged != null)
					StateChanged.Invoke(this, null);
			}
		}

		public event EventHandler StateChanged;
	}

	public class Cell : ICell
	{
		private CellType cellType;
		public CellType CellType
		{
			get { return cellType; }
			set
			{
				cellType = value;
				if (StateChanged != null)
					StateChanged.Invoke(this, null);
			}
		}

		private int fishCount;
		public int FishCount
		{
			get { return fishCount; }
			set
			{
				fishCount = value;
				if (StateChanged != null)
					StateChanged.Invoke(this, null);
			}
		}

		private Penguin currentPenguinObject;
		public Penguin CurrentPenguinObject
		{
			get { return currentPenguinObject; }
			set
			{
				currentPenguinObject = value;
				if (StateChanged != null)
					StateChanged.Invoke(this, null);
			}
		}

		public IPenguin CurrentPenguin
		{
			get
			{
				return currentPenguinObject;
			}
		}

		public event EventHandler StateChanged;
	}

	public class Penguin : IPenguin
	{
		public IPlayer Player
		{
			get { return Penguin_Object; }
		}

		public Player Penguin_Object { get; private set; }
	}
}

using Game.Penguins.Core.Interfaces.Game.GameBoard;
using Game.Penguins.Core.Interfaces.Game.Players;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Penguins.Core.Socrate
{
	public class CustomGame : IGame
	{
		public IBoard Board { get { return } }

		public NextActionType NextAction => throw new NotImplementedException();

		public IPlayer CurrentPlayer => throw new NotImplementedException();

		public IList<IPlayer> Players => throw new NotImplementedException();

		public event EventHandler StateChanged;

		public IPlayer AddPlayer(string playerName, PlayerType playerType)
		{
			List<Player> players = new List<Player>();
			
		}

		public void Move()
		{
			throw new NotImplementedException();
		}

		public void MoveManual(ICell origin, ICell destination)
		{
			throw new NotImplementedException();
		}

		public void PlacePenguin()
		{
			throw new NotImplementedException();
		}

		public void PlacePenguinManual(int x, int y)
		{
			throw new NotImplementedException();
		}

		public void StartGame()
		{
			throw new NotImplementedException();
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

		private IPenguin currentPenguin;
		public IPenguin CurrentPenguin
		{
			get { return currentPenguin; }
			set
			{
				currentPenguin = value;
				if (StateChanged != null)
					StateChanged.Invoke(this, null);
			}
		}

		public event EventHandler StateChanged;
	}

	public class Penguin : IPenguin
	{
		public IPlayer Player
		{
			get { return PlayerObject; }
		}

		public Player PlayerObject { get; private set; }
	}
}

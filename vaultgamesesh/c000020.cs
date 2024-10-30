using api2019;
using server;

namespace vaultgamesesh;

internal sealed class c000020
{
	public sealed class c000022
	{
		private string f000002;

		private int f000001;

		private bool f000037;

		private int f000020;

		private int f000003;

		private c000041.c000044 f000038;

		public string Error
		{
			get
			{
				return f000002;
			}
			set
			{
				f000002 = value;
			}
		}

		public int PlayerId
		{
			get
			{
				return f000001;
			}
			set
			{
				f000001 = value;
			}
		}

		public bool IsOnline
		{
			get
			{
				return f000037;
			}
			set
			{
				f000037 = value;
			}
		}

		public int PlayerType
		{
			get
			{
				return f000020;
			}
			set
			{
				f000020 = value;
			}
		}

		public int StatusVisibility
		{
			get
			{
				return f000003;
			}
			set
			{
				f000003 = value;
			}
		}

		public c000041.c000044 GameSession
		{
			get
			{
				return f000038;
			}
			set
			{
				f000038 = value;
			}
		}
	}

	public sealed class c000023
	{
		private int f000001;

		private int f000020;

		private int f000003;

		private RebornMatch.RoomInstance f000038;

		public int playerId
		{
			get
			{
				return f000001;
			}
			set
			{
				f000001 = value;
			}
		}

		public int statusVisibility
		{
			get
			{
				return f000003;
			}
			set
			{
				f000003 = value;
			}
		}

		public int deviceClass
		{
			get
			{
				return f000020;
			}
			set
			{
				f000020 = value;
			}
		}

		public RebornMatch.RoomInstance roomInstance
		{
			get
			{
				return f000038;
			}
			set
			{
				f000038 = value;
			}
		}
	}

	public static c000022 m000027()
	{
		c000041.c000044 gameSession = ((c000041.f000013 != null) ? c000041.f000013 : c000041.m00002f());
		return new c000022
		{
			Error = "",
			PlayerId = APIServer.CachedPlayerID,
			IsOnline = true,
			PlayerType = 2,
			StatusVisibility = 0,
			GameSession = gameSession
		};
	}

	public static c000023 m000028()
	{
		RebornMatch.RoomInstance currentRoomInstance = RebornMatch.currentRoomInstance;
		return new c000023
		{
			playerId = APIServer.CachedPlayerID,
			statusVisibility = 0,
			deviceClass = 0,
			roomInstance = currentRoomInstance
		};
	}
}

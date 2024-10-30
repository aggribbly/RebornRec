using System.IO;
using api;
using Newtonsoft.Json;
using server;
using start;

namespace gamesesh;

public class GameSessions
{
	public class PlayerStatus
	{
		public int PlayerId { get; set; }

		public bool IsOnline { get; set; }

		public bool InScreenMode { get; set; }

		public SessionInstance GameSession { get; set; }
	}

	public class SessionInstance
	{
		public long GameSessionId { get; set; }

		public string RegionId { get; set; }

		public string RoomId { get; set; }

		public long? EventId { get; set; }

		public long? RecRoomId { get; set; }

		public int CreatorPlayerId { get; set; }

		public string Name { get; set; }

		public string ActivityLevelId { get; set; }

		public bool Private { get; set; }

		public bool Sandbox { get; set; }

		public bool SupportsVR { get; set; }

		public bool SupportsScreens { get; set; }

		public bool GameInProgress { get; set; }

		public int MaxCapacity { get; set; }

		public bool IsFull { get; set; }
	}

	public class JoinRandomRequest
	{
		public string[] ActivityLevelIds { get; set; }

		public int[] ExpectedPlayerIds { get; set; }

		public RegionPing[] RegionPings { get; set; }
	}

	public class CreateRequest
	{
		public bool IsSandbox { get; set; }

		public string ActivityLevelId { get; set; }

		public int[] ExpectedPlayerIds { get; set; }

		public RegionPing[] RegionPings { get; set; }
	}

	public class RoomCodeRequest
	{
		public string RoomCode { get; set; }

		public string ActivityLevelId { get; set; }

		public int[] ExpectedPlayerIds { get; set; }

		public RegionPing[] RegionPings { get; set; }
	}

	public class RegionPing
	{
		public string Region { get; set; }

		public int Ping { get; set; }
	}

	private class JoinResult
	{
		public int Result { get; set; }

		public SessionInstance GameSession { get; set; }
	}

	public static string JoinRandom(string jsonData)
	{
		JoinRandomRequest joinRandomRequest = JsonConvert.DeserializeObject<JoinRandomRequest>(jsonData);
		string text = joinRandomRequest.ActivityLevelIds[0];
		if (File.ReadAllText("SaveData/App/privaterooms.txt") != "")
		{
			text += File.ReadAllText("SaveData/App/privaterooms.txt");
		}
		if (Program.flag)
		{
			text = "666";
		}
		Config.localGameSession = new SessionInstance
		{
			GameSessionId = long.Parse(Program.version + "2"),
			RegionId = "us",
			RoomId = text,
			RecRoomId = null,
			EventId = null,
			CreatorPlayerId = APIServer.CachedPlayerID,
			Name = "",
			ActivityLevelId = joinRandomRequest.ActivityLevelIds[0],
			Private = false,
			Sandbox = false,
			SupportsScreens = true,
			SupportsVR = true,
			GameInProgress = false,
			MaxCapacity = 20,
			IsFull = false
		};
		return JsonConvert.SerializeObject(new JoinResult
		{
			Result = 0,
			GameSession = Config.localGameSession
		});
	}

	public static string Create(string jsonData)
	{
		CreateRequest createRequest = JsonConvert.DeserializeObject<CreateRequest>(jsonData);
		string text = createRequest.ActivityLevelId;
		if (File.ReadAllText("SaveData/App/privaterooms.txt") != "")
		{
			text += File.ReadAllText("SaveData/App/privaterooms.txt");
		}
		if (Program.flag)
		{
			text = "666";
		}
		Config.localGameSession = new SessionInstance
		{
			GameSessionId = long.Parse(Program.version + "2"),
			RegionId = "us",
			RoomId = text,
			RecRoomId = null,
			EventId = null,
			CreatorPlayerId = APIServer.CachedPlayerID,
			Name = "",
			ActivityLevelId = createRequest.ActivityLevelId,
			Private = false,
			Sandbox = true,
			SupportsScreens = true,
			SupportsVR = true,
			GameInProgress = false,
			MaxCapacity = 20,
			IsFull = false
		};
		return JsonConvert.SerializeObject(new JoinResult
		{
			Result = 0,
			GameSession = Config.localGameSession
		});
	}

	public static string JoinRoomCode(string jsonData)
	{
		RoomCodeRequest roomCodeRequest = JsonConvert.DeserializeObject<RoomCodeRequest>(jsonData);
		string roomId = roomCodeRequest.RoomCode;
		if (Program.flag)
		{
			roomId = "666";
		}
		Config.localGameSession = new SessionInstance
		{
			GameSessionId = long.Parse(Program.version + "2"),
			RegionId = "us",
			RoomId = roomId,
			RecRoomId = null,
			EventId = null,
			CreatorPlayerId = APIServer.CachedPlayerID,
			Name = "",
			ActivityLevelId = roomCodeRequest.ActivityLevelId,
			Private = false,
			Sandbox = false,
			SupportsScreens = true,
			SupportsVR = true,
			GameInProgress = false,
			MaxCapacity = 20,
			IsFull = false
		};
		return JsonConvert.SerializeObject(new JoinResult
		{
			Result = 0,
			GameSession = Config.localGameSession
		});
	}

	public static PlayerStatus StatusSession()
	{
		return new PlayerStatus
		{
			PlayerId = APIServer.CachedPlayerID,
			IsOnline = true,
			InScreenMode = false,
			GameSession = Config.localGameSession
		};
	}
}

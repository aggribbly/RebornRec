using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using server;
using start;

namespace vaultgamesesh;

internal sealed class c000041
{
	public sealed class c000042
	{
		private int f00001f;

		private c000044 f000013;

		private RoomData.c000060 f000045;

		public int Result
		{
			get
			{
				return f00001f;
			}
			set
			{
				f00001f = value;
			}
		}

		public c000044 GameSession
		{
			get
			{
				return f000013;
			}
			set
			{
				f000013 = value;
			}
		}

		public RoomData.c000060 RoomDetails
		{
			get
			{
				return f000045;
			}
			set
			{
				f000045 = value;
			}
		}
	}

	public sealed class c000044
	{
		private long f00002c;

		private string f000003;

		private string f000035;

		private long f00000d;

		private long f000046;

		private string f00000f;

		private bool f000017;

		private string f000009;

		private long? f000047;

		private bool f000019;

		private bool f00001a;

		private int f000048;

		private bool f00001c;

		public long GameSessionId
		{
			get
			{
				return f00002c;
			}
			set
			{
				f00002c = value;
			}
		}

		public string PhotonRegionId { get; set; }

		public string PhotonRoomId
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

		public string Name
		{
			get
			{
				return f000035;
			}
			set
			{
				f000035 = value;
			}
		}

		public long RoomId
		{
			get
			{
				return f00000d;
			}
			set
			{
				f00000d = value;
			}
		}

		public long RoomSceneId
		{
			get
			{
				return f000046;
			}
			set
			{
				f000046 = value;
			}
		}

		public string RoomSceneLocationId
		{
			get
			{
				return f00000f;
			}
			set
			{
				f00000f = value;
			}
		}

		public bool IsSandbox
		{
			get
			{
				return f000017;
			}
			set
			{
				f000017 = value;
			}
		}

		public string DataBlobName
		{
			get
			{
				return f000009;
			}
			set
			{
				f000009 = value;
			}
		}

		public long? PlayerEventId
		{
			get
			{
				return f000047;
			}
			set
			{
				f000047 = value;
			}
		}

		public bool Private
		{
			get
			{
				return f000019;
			}
			set
			{
				f000019 = value;
			}
		}

		public bool GameInProgress
		{
			get
			{
				return f00001a;
			}
			set
			{
				f00001a = value;
			}
		}

		public int MaxCapacity
		{
			get
			{
				return f000048;
			}
			set
			{
				f000048 = value;
			}
		}

		public bool IsFull
		{
			get
			{
				return f00001c;
			}
			set
			{
				f00001c = value;
			}
		}
	}

	public static RoomData.c000060 f000043;

	public static c000044 f000013;

	public static c000044 m00002f()
	{
		return new c000044
		{
			GameSessionId = 20182L,
			PhotonRegionId = "us",
			PhotonRoomId = "1",
			Name = "DormRoom",
			RoomId = 1L,
			RoomSceneId = 1L,
			RoomSceneLocationId = "76d98498-60a1-430c-ab76-b54a29b7a163",
			IsSandbox = false,
			DataBlobName = "",
			PlayerEventId = null,
			Private = false,
			GameInProgress = false,
			MaxCapacity = 20,
			IsFull = false
		};
	}

	public static c000042 m000030(string p0)
	{
		c00006b.c00006c c00006c = JsonConvert.DeserializeObject<c00006b.c00006c>(p0);
		if (RoomData.f000050.TryGetValue(c00006c.RoomName, out var value))
		{
			f000043 = value;
		}
		else if (c00006c.RoomName == "dormroom")
		{
			f000043 = RoomData.f000050["DormRoom"];
		}
		else if (RoomData.m00003a().ContainsKey(c00006c.RoomName))
		{
			f000043 = RoomData.m00003a()[c00006c.RoomName];
		}
		else if (APIServer.LastRoom != null && c00006c.RoomName == APIServer.LastRoom.Room.Name)
		{
			f000043 = APIServer.LastRoom;
		}
		else
		{
			foreach (RoomData.c000061 communityRoom in APIServer.CommunityRooms)
			{
				if (communityRoom.Name == c00006c.RoomName)
				{
					f000043 = JsonConvert.DeserializeObject<RoomData.c000060>(new WebClient().DownloadString("https://raw.githubusercontent.com/aqquad/RebornRec/main/data/" + communityRoom.RoomId));
					break;
				}
			}
		}
		int num = 0;
		for (int i = 0; i < f000043.Scenes.Count; i++)
		{
			if (f000043.Scenes[i].Name == c00006c.SceneName)
			{
				num = i;
			}
		}
		string text = f000043.Scenes[num].RoomId.ToString();
		if (f000013 != null && text + GameConfig.PhotonRoomId == f000013.PhotonRoomId)
		{
			text += "Inst2";
		}
		text += GameConfig.PhotonRoomId;
		bool @private = c00006c.Private;
		if (@private)
		{
			text += new Random().Next(9999999, 99999999);
		}
		else if (File.ReadAllText("SaveData/App/privaterooms.txt") != "")
		{
			text += File.ReadAllText("SaveData/App/privaterooms.txt");
		}
		if (Program.flag)
		{
			text += "BANNED";
		}
		f000013 = new c000044
		{
			GameSessionId = long.Parse(Program.version + "2"),
			PhotonRegionId = "us",
			PhotonRoomId = text,
			Name = f000043.Room.Name,
			RoomId = (long)f000043.Room.RoomId,
			RoomSceneId = num + 1,
			RoomSceneLocationId = f000043.Scenes[num].RoomSceneLocationId,
			IsSandbox = f000043.Scenes[num].IsSandbox,
			DataBlobName = f000043.Scenes[num].DataBlobName,
			PlayerEventId = null,
			Private = @private,
			GameInProgress = false,
			MaxCapacity = 20,
			IsFull = false
		};
		return new c000042
		{
			Result = 0,
			GameSession = f000013,
			RoomDetails = f000043
		};
	}
}

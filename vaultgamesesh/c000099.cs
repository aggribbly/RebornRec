using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using server;

namespace vaultgamesesh;

internal sealed class c000099
{
	public sealed class c00009a
	{
		private string f00000a;

		private ulong f000023;

		public string Name
		{
			get
			{
				return f00000a;
			}
			set
			{
				f00000a = value;
			}
		}

		public ulong RoomId
		{
			get
			{
				return f000023;
			}
			set
			{
				f000023 = value;
			}
		}
	}

	public sealed class c00009b
	{
		private int f000042;

		private RoomData.c000060 f00004f;

		public int Result
		{
			get
			{
				return f000042;
			}
			set
			{
				f000042 = value;
			}
		}

		public RoomData.c000060 RoomDetails
		{
			get
			{
				return f00004f;
			}
			set
			{
				f00004f = value;
			}
		}
	}

	public static List<RoomData.c000061> m000055()
	{
		List<RoomData.c000061> list = new List<RoomData.c000061>();
		foreach (KeyValuePair<string, RoomData.c000060> item in RoomData.m00003a())
		{
			list.Add(item.Value.Room);
		}
		return list;
	}

	public static RoomData.c000060 m000057(ulong p0)
	{
		foreach (KeyValuePair<string, RoomData.c000060> item in RoomData.f000024)
		{
			if (item.Value.Room.RoomId == p0)
			{
				return item.Value;
			}
		}
		foreach (KeyValuePair<string, RoomData.c000060> item2 in RoomData.f000050)
		{
			if (item2.Value.Room.RoomId == p0)
			{
				return item2.Value;
			}
		}
		foreach (KeyValuePair<string, RoomData.c000060> item3 in RoomData.m00003a())
		{
			if (item3.Value.Room.RoomId == p0)
			{
				return item3.Value;
			}
		}
		foreach (RoomData.c000061 communityRoom in APIServer.CommunityRooms)
		{
			if (communityRoom.RoomId == p0)
			{
				return JsonConvert.DeserializeObject<RoomData.c000060>(new WebClient().DownloadString("https://raw.githubusercontent.com/aqquad/RebornRec/main/data/" + communityRoom.RoomId));
			}
		}
		return null;
	}

	public static c00009b m00000a(string p0)
	{
		c00009b c00009b = new c00009b();
		c00009a c00009a = JsonConvert.DeserializeObject<c00009a>(p0);
		RoomData.c000060 c100 = m000057(c00009a.RoomId);
		if (c100 == null)
		{
			c00009b.Result = 2;
			c00009b.RoomDetails = new RoomData.c000060();
		}
		else
		{
			c00009b.Result = 0;
			c00009b.RoomDetails = c100;
			ulong roomId = (ulong)new Random().Next(100, 9999999);
			c00009b.RoomDetails.Room.RoomId = roomId;
			c00009b.RoomDetails.Room.Name = c00009a.Name;
			c00009b.RoomDetails.Room.CreatorPlayerId = APIServer.CachedPlayerID;
			c00009b.RoomDetails.Room.SupportsLevelVoting = false;
			c00009b.RoomDetails.Room.IsAGRoom = false;
			c00009b.RoomDetails.Scenes[0].RoomId = roomId;
			c00009b.RoomDetails.Scenes[0].IsSandbox = true;
		}
		string text = "SaveData/Rooms/" + c00009a.Name;
		Directory.CreateDirectory(text);
		File.WriteAllText(text + "/RoomDetails.json", JsonConvert.SerializeObject(c00009b.RoomDetails));
		return c00009b;
	}
}

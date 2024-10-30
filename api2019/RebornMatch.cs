using System;
using System.IO;
using start;
using vaultgamesesh;

namespace api2019;

internal class RebornMatch
{
	public class MatchmakingResponse
	{
		public int errorCode;

		public RoomInstance roomInstance;
	}

	public class RoomInstance
	{
		public long roomInstanceId;

		public ulong roomId;

		public long subRoomId;

		public string location;

		public string photonRegionId;

		public string photonRoomId;

		public string name;

		public int maxCapacity;

		public string dataBlob;

		public bool isFull;

		public bool isPrivate;

		public bool isInProgress;
	}

	public static RoomInstance currentRoomInstance;

	public static MatchmakingResponse GotoRoom(string room, string subroom, bool @private)
	{
		RoomData.c000060 c = RoomData.m000023((int)RoomData.m000024(room).RoomId);
		string text = c.Room.RoomId.ToString();
		if (c000041.f000013 != null && text + GameConfig.PhotonRoomId == c000041.f000013.PhotonRoomId)
		{
			text += "Inst2";
		}
		text += GameConfig.PhotonRoomId;
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
		MatchmakingResponse matchmakingResponse = new MatchmakingResponse
		{
			errorCode = 0,
			roomInstance = new RoomInstance
			{
				roomInstanceId = new Random().Next(100000000, 1000000000),
				roomId = c.Room.RoomId,
				subRoomId = 1L,
				location = c.Scenes[0].RoomSceneLocationId,
				photonRegionId = "us",
				photonRoomId = text,
				name = c.Room.Name,
				maxCapacity = c.Scenes[0].MaxPlayers,
				dataBlob = c.Scenes[0].DataBlobName,
				isFull = false,
				isPrivate = @private,
				isInProgress = false
			}
		};
		if (subroom != "")
		{
			foreach (RoomData.c00005f scene in c.Scenes)
			{
				if (scene.Name == subroom)
				{
					matchmakingResponse.roomInstance.subRoomId = scene.RoomSceneId;
					matchmakingResponse.roomInstance.location = scene.RoomSceneLocationId;
					matchmakingResponse.roomInstance.maxCapacity = scene.MaxPlayers;
					matchmakingResponse.roomInstance.dataBlob = scene.DataBlobName;
				}
			}
		}
		currentRoomInstance = matchmakingResponse.roomInstance;
		c000041.f000043 = c;
		return matchmakingResponse;
	}
}

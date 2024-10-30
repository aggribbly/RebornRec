using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using api2018;
using Newtonsoft.Json;

namespace api2017;

internal class getorcreate
{
	public static string GetOrCreate(int userid)
	{
		string text = File.ReadAllText("SaveData/Profile/username.txt");
		Profiles obj = new Profiles
		{
			Id = userid,
			Username = text,
			DisplayName = text,
			XP = 48,
			Level = int.Parse(File.ReadAllText("SaveData/Profile/level.txt")),
			Reputation = 0,
			Verified = true,
			Developer = true,
			HasEmail = true,
			CanReceiveInvites = false,
			ProfileImageName = text,
			HasBirthday = true,
			PhoneLastFour = "RebornRec",
			EmailEnteredAt = DateTime.UtcNow,
			PlayerReputation = new PlayerReputation
			{
				Noteriety = 0,
				CheerGeneral = 1,
				CheerHelpful = 1,
				CheerGreatHost = 1,
				CheerSportsman = 1,
				CheerCreative = 1,
				CheerCredit = 77,
				SubscriberCount = 2,
				SubscribedCount = 0,
				SelectedCheer = int.Parse(File.ReadAllText("SaveData/Profile/cheer.txt"))
			}
		};
		List<mPlatformID> list = new List<mPlatformID>();
		CollectionsMarshal.SetCount(list, 1);
		Span<mPlatformID> span = CollectionsMarshal.AsSpan(list);
		int num = 0;
		span[num] = new mPlatformID
		{
			Platform = 0,
			PlatformId = 1uL
		};
		num++;
		obj.PlatformIds = list;
		return JsonConvert.SerializeObject(obj);
	}

	public static string GetOrCreateArray(int userid)
	{
		string text = File.ReadAllText("SaveData/Profile/username.txt");
		Profiles[] array = new Profiles[1];
		Profiles obj = new Profiles
		{
			Id = userid,
			Username = text,
			DisplayName = text,
			XP = 48,
			Level = int.Parse(File.ReadAllText("SaveData/Profile/level.txt")),
			Reputation = 0,
			Verified = true,
			Developer = true,
			HasEmail = true,
			CanReceiveInvites = false,
			ProfileImageName = text,
			HasBirthday = true,
			EmailEnteredAt = DateTime.UtcNow,
			PlayerReputation = new PlayerReputation
			{
				Noteriety = 0,
				CheerGeneral = 1,
				CheerHelpful = 1,
				CheerGreatHost = 1,
				CheerSportsman = 1,
				CheerCreative = 1,
				CheerCredit = 77,
				SubscriberCount = 2,
				SubscribedCount = 0,
				SelectedCheer = int.Parse(File.ReadAllText("SaveData/Profile/cheer.txt"))
			}
		};
		List<mPlatformID> list = new List<mPlatformID>();
		CollectionsMarshal.SetCount(list, 1);
		Span<mPlatformID> span = CollectionsMarshal.AsSpan(list);
		int num = 0;
		span[num] = new mPlatformID
		{
			Platform = 0,
			PlatformId = 1uL
		};
		num++;
		obj.PlatformIds = list;
		array[0] = obj;
		return JsonConvert.SerializeObject(array);
	}
}

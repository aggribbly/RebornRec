using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace api2018;

public class getcachedlogins
{
	public int Id { get; set; }

	public string Username { get; set; }

	public string DisplayName { get; set; }

	public int XP { get; set; }

	public int Level { get; set; }

	public int RegistrationStatus { get; set; }

	public bool Developer { get; set; }

	public bool CanReceiveInvites { get; set; }

	public string ProfileImageName { get; set; }

	public bool JuniorProfile { get; set; }

	public bool ForceJuniorImages { get; set; }

	public bool PendingJunior { get; set; }

	public bool HasBirthday { get; set; }

	public bool AvoidJuniors { get; set; }

	public PlayerReputation PlayerReputation { get; set; }

	public List<mPlatformID> PlatformIds { get; set; }

	public static string GetDebugLogin(int userid)
	{
		string text = File.ReadAllText("SaveData/Profile/username.txt");
		List<getcachedlogins> list = new List<getcachedlogins>();
		getcachedlogins obj = new getcachedlogins
		{
			Id = userid,
			Username = text,
			DisplayName = text,
			XP = 48,
			Level = int.Parse(File.ReadAllText("SaveData/Profile/level.txt")),
			RegistrationStatus = 2,
			Developer = true,
			CanReceiveInvites = false,
			ProfileImageName = text,
			JuniorProfile = false,
			ForceJuniorImages = false,
			PendingJunior = false,
			HasBirthday = true,
			AvoidJuniors = true,
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
		List<mPlatformID> list2 = new List<mPlatformID>();
		CollectionsMarshal.SetCount(list2, 1);
		Span<mPlatformID> span = CollectionsMarshal.AsSpan(list2);
		int num = 0;
		span[num] = new mPlatformID
		{
			Platform = 0,
			PlatformId = 1uL
		};
		num++;
		obj.PlatformIds = list2;
		list.Add(obj);
		return JsonConvert.SerializeObject(list);
	}
}

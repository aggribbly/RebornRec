using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace api2018;

public class logincached
{
	public string Error { get; set; }

	public getcachedlogins Player { get; set; }

	public string Token { get; set; }

	public bool FirstLoginOfTheDay { get; set; }

	public int AnalyticsSessionId { get; set; }

	public bool CanUseScreenMode { get; set; }

	public int CachedPlatformMask { get; set; }

	public static string loginCache(int userid)
	{
		string text = File.ReadAllText("SaveData/Profile/username.txt");
		return JsonConvert.SerializeObject(new logincached
		{
			Error = "",
			Player = new getcachedlogins
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
				},
				PlatformIds = new List<mPlatformID>
				{
					new mPlatformID
					{
						Platform = 0,
						PlatformId = 1uL
					}
				}
			},
			Token = "CuteRebornRecToken",
			FirstLoginOfTheDay = true,
			AnalyticsSessionId = 0,
			CanUseScreenMode = true,
			CachedPlatformMask = 0
		});
	}
}

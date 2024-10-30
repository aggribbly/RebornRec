using System;
using System.Collections.Generic;
using System.IO;
using api2018;
using Newtonsoft.Json;

namespace api2019;

internal class CachedLogin
{
	public DateTime LastLoginTime { get; set; }

	public getcachedlogins Player { get; set; }

	public bool RequirePassword { get; set; }

	public static string loginCache(int userid)
	{
		string text = File.ReadAllText("SaveData/Profile/username.txt");
		return JsonConvert.SerializeObject(new List<CachedLogin>
		{
			new CachedLogin
			{
				LastLoginTime = DateTime.MinValue,
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
				RequirePassword = false
			}
		});
	}
}

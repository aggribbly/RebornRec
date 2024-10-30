using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace api2019;

internal class CachedLogin20202
{
	public int accountId { get; set; }

	public string displayName { get; set; }

	public string bannerImage { get; set; }

	public DateTime createdAt { get; set; }

	public bool isJunior { get; set; }

	public int platforms { get; set; }

	public string profileImage { get; set; }

	public string username { get; set; }

	public static string loginCache(int userid)
	{
		string text = File.ReadAllText("SaveData/Profile/username.txt");
		return JsonConvert.SerializeObject(new List<CachedLogin20202>
		{
			new CachedLogin20202
			{
				accountId = userid,
				displayName = text,
				bannerImage = text,
				createdAt = DateTime.MinValue,
				isJunior = false,
				platforms = 0,
				profileImage = text,
				username = text
			}
		});
	}
}

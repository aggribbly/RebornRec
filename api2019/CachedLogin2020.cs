using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace api2019;

internal class CachedLogin2020
{
	public int platform { get; set; }

	public string platformId { get; set; }

	public int accountId { get; set; }

	public DateTime lastLoginTime { get; set; }

	public bool requirePassword { get; set; }

	public static string loginCache(int userid)
	{
		return JsonConvert.SerializeObject(new List<CachedLogin2020>
		{
			new CachedLogin2020
			{
				platform = 0,
				platformId = "0",
				accountId = userid,
				lastLoginTime = DateTime.MinValue,
				requirePassword = false
			}
		});
	}
}

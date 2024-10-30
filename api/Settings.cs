using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace api;

internal class Settings
{
	private static List<Setting> playerSettings;

	public static string SettingsPath = "SaveData/settings.txt";

	public static void SetPlayerSetting(string jsonData)
	{
		Setting setting = JsonConvert.DeserializeObject<Setting>(jsonData);
		playerSettings = JsonConvert.DeserializeObject<List<Setting>>(File.ReadAllText(SettingsPath));
		bool flag = false;
		foreach (Setting playerSetting in playerSettings)
		{
			if (playerSetting.Key == setting.Key)
			{
				playerSetting.Value = setting.Value;
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			playerSettings.Add(new Setting
			{
				Key = setting.Key,
				Value = setting.Value
			});
		}
		File.WriteAllText(SettingsPath, JsonConvert.SerializeObject(playerSettings));
	}

	public static void SetPlayerSettings(string data)
	{
		List<Setting>? list = JsonConvert.DeserializeObject<List<Setting>>(data);
		playerSettings = JsonConvert.DeserializeObject<List<Setting>>(File.ReadAllText(SettingsPath));
		foreach (Setting item in list)
		{
			bool flag = false;
			foreach (Setting playerSetting in playerSettings)
			{
				if (playerSetting.Key == item.Key)
				{
					playerSetting.Value = item.Value;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				playerSettings.Add(new Setting
				{
					Key = item.Key,
					Value = item.Value
				});
			}
		}
		File.WriteAllText(SettingsPath, JsonConvert.SerializeObject(playerSettings));
	}

	public static List<Setting> CreateDefaultSettings()
	{
		List<Setting> list = new List<Setting>();
		CollectionsMarshal.SetCount(list, 20);
		Span<Setting> span = CollectionsMarshal.AsSpan(list);
		int num = 0;
		span[num] = new Setting
		{
			Key = "MOD_BLOCKED_TIME",
			Value = "0"
		};
		num++;
		span[num] = new Setting
		{
			Key = "MOD_BLOCKED_DURATION",
			Value = "0"
		};
		num++;
		span[num] = new Setting
		{
			Key = "PlayerSessionCount",
			Value = "0"
		};
		num++;
		span[num] = new Setting
		{
			Key = "ShowRoomCenter",
			Value = "0"
		};
		num++;
		span[num] = new Setting
		{
			Key = "QualitySettings",
			Value = "2"
		};
		num++;
		span[num] = new Setting
		{
			Key = "Recroom.OOBE",
			Value = "100"
		};
		num++;
		span[num] = new Setting
		{
			Key = "VoiceFilter2",
			Value = "1"
		};
		num++;
		span[num] = new Setting
		{
			Key = "VIGNETTED_TELEPORT_ENABLED",
			Value = "0"
		};
		num++;
		span[num] = new Setting
		{
			Key = "CONTINUOUS_ROTATION_MODE",
			Value = "0"
		};
		num++;
		span[num] = new Setting
		{
			Key = "ROTATION_INCREMENT",
			Value = "0"
		};
		num++;
		span[num] = new Setting
		{
			Key = "ROTATE_IN_PLACE_ENABLED",
			Value = "0"
		};
		num++;
		span[num] = new Setting
		{
			Key = "FIRST_TIME_IN_RECCENTER",
			Value = "1"
		};
		num++;
		span[num] = new Setting
		{
			Key = "OOBE_OBJECTIVES_GRANTED",
			Value = "1"
		};
		num++;
		span[num] = new Setting
		{
			Key = "TeleportBuffer",
			Value = "0"
		};
		num++;
		span[num] = new Setting
		{
			Key = "VoiceChat",
			Value = "1"
		};
		num++;
		span[num] = new Setting
		{
			Key = "PersonalBubble",
			Value = "0"
		};
		num++;
		span[num] = new Setting
		{
			Key = "IgnoreBuffer",
			Value = "0"
		};
		num++;
		span[num] = new Setting
		{
			Key = "ShowNames",
			Value = "1"
		};
		num++;
		span[num] = new Setting
		{
			Key = "H.264 plugin",
			Value = "1"
		};
		num++;
		span[num] = new Setting
		{
			Key = "USER_TRACKING",
			Value = "54"
		};
		num++;
		return list;
	}
}

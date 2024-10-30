using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace api;

internal class Consumables
{
	internal class Consumable
	{
		public int Id { get; set; }

		public string ConsumableItemDesc { get; set; }

		public int PlatformMask { get; set; }

		public DateTime CreatedAt { get; set; }

		public int Count { get; set; }

		public int InitialCount { get; set; }

		public int ActiveDurationMinutes { get; set; }

		public int UnlockedLevel { get; set; }

		public bool IsActive { get; set; }

		public int Category { get; set; }
	}

	private static List<Consumable> playerConsumables;

	public static string ConsumablesPath = "SaveData/consumables.txt";

	public static void SetPlayerConsumables(string jsonData, bool type)
	{
		playerConsumables = JsonConvert.DeserializeObject<List<Consumable>>(File.ReadAllText(ConsumablesPath));
		if (type)
		{
			foreach (JObject item in JArray.Parse(jsonData))
			{
				Consumable consumable = JsonConvert.DeserializeObject<Consumable>(item.ToString());
				foreach (Consumable playerConsumable in playerConsumables)
				{
					if (playerConsumable.ConsumableItemDesc == consumable.ConsumableItemDesc)
					{
						playerConsumable.IsActive = consumable.IsActive;
					}
				}
			}
		}
		else
		{
			Consumable consumable2 = JsonConvert.DeserializeObject<Consumable>(jsonData);
			foreach (Consumable playerConsumable2 in playerConsumables)
			{
				if (playerConsumable2.Id != consumable2.Id)
				{
					continue;
				}
				if (consumable2.Id > 24 && consumable2.Id < 47)
				{
					foreach (Consumable playerConsumable3 in playerConsumables)
					{
						if (playerConsumable3.Id > 24 && playerConsumable3.Id < 47)
						{
							playerConsumable3.IsActive = false;
						}
					}
				}
				playerConsumable2.IsActive = consumable2.IsActive;
				break;
			}
		}
		File.WriteAllText(ConsumablesPath, JsonConvert.SerializeObject(playerConsumables));
	}
}

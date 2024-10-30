using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using start;

namespace api;

internal class Equipment
{
	internal class Skin
	{
		public string PrefabName { get; set; }

		public string ModificationGuid { get; set; }

		public int UnlockedLevel { get; set; }

		public int PlatformMask { get; set; }

		public bool Favorited { get; set; }
	}

	private static List<Skin> playerEquipment;

	public static string EquipmentPath = "SaveData/equipment.txt";

	public static string someSkins = "[{\"PrefabName\":\"[PaintballAssaultRifle]\",\"ModificationGuid\":\"357fe573-fee7-467f-93a7-5e61afb024b8\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[QuestShield]\",\"ModificationGuid\":\"affbab2d-3200-4512-a140-685fdc5570c6\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[QuestShield]\",\"ModificationGuid\":\"735b06c6-1b78-4f60-9291-a414a96cd228\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[QuestShield]\",\"ModificationGuid\":\"93f5418e-a03d-4074-804c-daa0e374dd9f\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[QuestShield]\",\"ModificationGuid\":\"2389fce4-3ab2-4e05-918c-845eb8538bed\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[QuestShield]\",\"ModificationGuid\":\"a9a3292c-8ccf-4564-aeb1-124c52057ef2\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[PaintballShield]\",\"ModificationGuid\":\"fd367329-b8b2-4d44-825a-da16092751e3\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[PaintballShield]\",\"ModificationGuid\":\"174adb53-bc6e-4fcf-b03d-a00fc3deeb49\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[Basketball]\",\"ModificationGuid\":\"e6899422-ab2f-4bd9-8e98-aef950ec27b6\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[Basketball]\",\"ModificationGuid\":\"5dcf8a2e-6fa6-4007-ac1e-73dd53c4c247\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[PaintballShotgun]\",\"ModificationGuid\":\"61e49c13-b414-425f-8e8b-bdcf3d12a5bf\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[PaintballGun]\",\"ModificationGuid\":\"4aff20ee-0b20-434b-a030-d3e1764fe4e7\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[PaintballGun]\",\"ModificationGuid\":\"7ef5d1d9-24db-428c-85e0-107c1bfcc026\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[PaintballGun]\",\"ModificationGuid\":\"33c84c50-7c2e-4a80-ad06-79c4f20f829e\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[PaintballGun]\",\"ModificationGuid\":\"bc4254be-60e0-4cc5-a233-6a0bd4137118\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[DiscGolfDisc]\",\"ModificationGuid\":\"5d3c3b16-713e-43d8-88e0-7633063091da\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[DiscGolfDisc]\",\"ModificationGuid\":\"bd3f6aa5-c6e0-4e06-901d-1176accf1003\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[DiscGolfDisc]\",\"ModificationGuid\":\"7877964e-3a2b-4818-8513-0e26a707bd7c\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[DiscGolfDisc]\",\"ModificationGuid\":\"9d2a3618-12b3-4ca0-be59-ed15d7926d77\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[DiscGolfDisc]\",\"ModificationGuid\":\"2b70a76e-6f48-402e-90ff-40b06aa23eb8\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[DiscGolfDisc]\",\"ModificationGuid\":\"19ef59c7-f74b-4c63-935a-1d4b1abd8518\",\"UnlockedLevel\":0,\"Favorited\":false}]";

	public static string sumMoreSkins = "[{\"PrefabName\":\"[Basketball]\",\"ModificationGuid\":\"d6d22997-fe39-4ffa-b1b3-4955368c829a\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[QuestShield]\",\"ModificationGuid\":\"a363ba1b-2f70-4c5f-943a-f45cfa59122b\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[Crossbow_Hunter]\",\"ModificationGuid\":\"d217ee4c-22f3-4f33-bf7c-9d4ee9c30e29\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[Crossbow]\",\"ModificationGuid\":\"c4d70545-cdf1-4fb1-924b-613de0327faf\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[PaintballGun]\",\"ModificationGuid\":\"b8d5612b-2c6f-46d6-9412-decddac7d4c1\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[PaintballGun]\",\"ModificationGuid\":\"ec5ef0f3-c072-45ec-bb8f-3781fb16e067\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[PaintballGun]\",\"ModificationGuid\":\"36751c4a-86a9-40e1-bef2-84f962ab678d\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[PaintballShotgun]\",\"ModificationGuid\":\"f27af5d7-c741-4457-8c98-8e8791f1a41c\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[PaintballShield]\",\"ModificationGuid\":\"a6c869d9-8f30-4ce6-a7ea-cb7ea9f9d492\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[Grenade]\",\"ModificationGuid\":\"993f8b81-cb2e-44e4-88a1-b841af1f0e69\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[Longbow]\",\"ModificationGuid\":\"f5901f11-b315-4261-9474-2da207e4a229\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[PaintballRifleScoped]\",\"ModificationGuid\":\"6a6b0ecf-286d-4361-92ff-7027c440dc3c\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[QuestSword]\",\"ModificationGuid\":\"0ee04d78-5a17-4a38-ae67-b576a41fc200\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[QuestSword]\",\"ModificationGuid\":\"431567d2-4df2-43eb-b632-3d79aa7c013c\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[QuestSword]\",\"ModificationGuid\":\"f03dee6a-79b8-4906-9abb-a821748d97a9\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[QuestSword]\",\"ModificationGuid\":\"3e46fb2d-bb3f-42ed-83ef-f5716860725c\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[Quest_SciFi_AutomaticGun]\",\"ModificationGuid\":\"546b3a57-13d4-4c35-ab3a-bbb7d466f0b8\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[Quest_SciFi_Pistol]\",\"ModificationGuid\":\"33a7a3dc-5266-4075-b56f-5eaa2c400e9f\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[Quest_SciFi_Pistol]\",\"ModificationGuid\":\"89b1fbbc-e7be-440b-8b22-8fd379c1a568\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[Quest_SciFi_Pistol]\",\"ModificationGuid\":\"db91b61b-ab32-4895-8f5a-0212c1283cbb\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[Quest_SciFi_RailGun]\",\"ModificationGuid\":\"63a867d7-ccea-4905-b6e0-e6dcfba06f9e\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[Quest_SciFi_RailGun]\",\"ModificationGuid\":\"46977ca7-ee75-4e2a-b8aa-0763879f8a96\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[Quest_SciFi_Shotgun]\",\"ModificationGuid\":\"55a9c1e8-07e2-4457-86f2-75fd5e67b1f3\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[Quest_SciFi_Shotgun]\",\"ModificationGuid\":\"83d7cca0-2c5d-41b2-a5b2-f79fd89f3037\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[PaintballAssaultRifle]\",\"ModificationGuid\":\"c458a6ae-a1ea-468a-89b8-4c9a85cd3cde\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[PaintballAssaultRifle]\",\"ModificationGuid\":\"996662ad-631d-4a81-8a8b-74ace4833279\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[PaintballAssaultRifle]\",\"ModificationGuid\":\"3aaef60d-142f-4a0a-bea3-f5d99ab62dd5\",\"UnlockedLevel\":0,\"Favorited\":false},{\"PrefabName\":\"[Chair_Moveable]\",\"ModificationGuid\":\"\",\"UnlockedLevel\":0,\"Favorited\":false}]";

	public static void SetPlayerEquipment(string jsonData)
	{
		playerEquipment = LoadEquipment(skip: true);
		foreach (JObject item in JArray.Parse(jsonData))
		{
			Skin skin = JsonConvert.DeserializeObject<Skin>(item.ToString());
			foreach (Skin item2 in playerEquipment)
			{
				if (item2.ModificationGuid == skin.ModificationGuid)
				{
					item2.Favorited = skin.Favorited;
				}
			}
		}
		File.WriteAllText(EquipmentPath, JsonConvert.SerializeObject(playerEquipment));
	}

	public static List<Skin> LoadEquipment(bool skip)
	{
		if (Program.buildversion < 20180927 && !skip)
		{
			List<Skin> list = JsonConvert.DeserializeObject<List<Skin>>(someSkins);
			if (Program.buildversion > 20170913)
			{
				list.AddRange(JsonConvert.DeserializeObject<List<Skin>>(sumMoreSkins));
			}
			List<Skin> list2 = JsonConvert.DeserializeObject<List<Skin>>(File.ReadAllText(EquipmentPath));
			{
				foreach (Skin item in list.ToList())
				{
					foreach (Skin item2 in list2)
					{
						if (item.ModificationGuid == item2.ModificationGuid && item.PrefabName == item2.PrefabName)
						{
							item.Favorited = item2.Favorited;
						}
					}
				}
				return list;
			}
		}
		return JsonConvert.DeserializeObject<List<Skin>>(File.ReadAllText(EquipmentPath));
	}
}

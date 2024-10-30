using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace api2019;

internal class Inventions
{
	public sealed class InventionRequest
	{
		public string name { get; set; }

		public string description { get; set; }

		public string imageName { get; set; }

		public int instantiationCost { get; set; }
	}

	public sealed class InventionResponse
	{
		public int Status { get; set; }

		public Invention Invention { get; set; }

		public InventionVersion InventionVersion { get; set; }
	}

	public sealed class Invention
	{
		public long InventionId { get; set; }

		public int CreatorPlayerId { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public string ImageName { get; set; }

		public int CurrentVersionNumber { get; set; }

		public bool IsPublished { get; set; }

		public DateTime ModifiedAt { get; set; }
	}

	public sealed class InventionVersion
	{
		public long InventionId { get; set; }

		public int VersionNumber { get; set; }

		public int InstantiationCost { get; set; }

		public string BlobName { get; set; }
	}

	public static Dictionary<string, InventionResponse> m00003a()
	{
		Dictionary<string, InventionResponse> dictionary = new Dictionary<string, InventionResponse>();
		string[] directories = Directory.GetDirectories("SaveData/Inventions");
		for (int i = 0; i < directories.Length; i++)
		{
			InventionResponse inventionResponse = JsonConvert.DeserializeObject<InventionResponse>(File.ReadAllText(directories[i] + "/InventionDetails.json"));
			dictionary.Add(inventionResponse.Invention.Name, inventionResponse);
		}
		return dictionary;
	}

	public static List<Invention> m000055()
	{
		List<Invention> list = new List<Invention>();
		foreach (KeyValuePair<string, InventionResponse> item in m00003a())
		{
			list.Add(item.Value.Invention);
		}
		return list;
	}
}

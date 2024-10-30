using System.Collections.Generic;
using api2019;
using Newtonsoft.Json;
using start;

namespace api;

internal class Config2
{
	public string MessageOfTheDay { get; set; }

	public string CdnBaseUri { get; set; }

	public string ShareBaseUrl { get; set; }

	public List<LevelProgressionEntry> LevelProgressionMaps { get; set; }

	public MatchmakingConfigParams MatchmakingParams { get; set; }

	public Objective[][] DailyObjectives { get; set; }

	public List<ConfigTableEntry> ConfigTable { get; set; }

	public photonConfig PhotonConfig { get; set; }

	public AutoMicMutingConfig AutoMicMutingConfig { get; set; }

	public ServerMaintenance ServerMaintenance { get; set; }

	public static string GetDebugConfig()
	{
		return JsonConvert.SerializeObject(new Config2
		{
			MessageOfTheDay = Program.webClient.DownloadString("https://raw.githubusercontent.com/aqquad/RebornRec/main/motd.txt"),
			CdnBaseUri = "http://localhost:2058/",
			ShareBaseUrl = "http://localhost:2056/",
			LevelProgressionMaps = new List<LevelProgressionEntry>
			{
				new LevelProgressionEntry
				{
					Level = 0,
					RequiredXp = 1
				},
				new LevelProgressionEntry
				{
					Level = 1,
					RequiredXp = 2
				},
				new LevelProgressionEntry
				{
					Level = 2,
					RequiredXp = 3
				},
				new LevelProgressionEntry
				{
					Level = 3,
					RequiredXp = 4
				},
				new LevelProgressionEntry
				{
					Level = 4,
					RequiredXp = 5
				},
				new LevelProgressionEntry
				{
					Level = 5,
					RequiredXp = 6
				},
				new LevelProgressionEntry
				{
					Level = 6,
					RequiredXp = 7
				},
				new LevelProgressionEntry
				{
					Level = 7,
					RequiredXp = 8
				},
				new LevelProgressionEntry
				{
					Level = 8,
					RequiredXp = 9
				},
				new LevelProgressionEntry
				{
					Level = 9,
					RequiredXp = 10
				},
				new LevelProgressionEntry
				{
					Level = 10,
					RequiredXp = 11
				},
				new LevelProgressionEntry
				{
					Level = 11,
					RequiredXp = 12
				},
				new LevelProgressionEntry
				{
					Level = 12,
					RequiredXp = 13
				},
				new LevelProgressionEntry
				{
					Level = 13,
					RequiredXp = 14
				},
				new LevelProgressionEntry
				{
					Level = 14,
					RequiredXp = 15
				},
				new LevelProgressionEntry
				{
					Level = 15,
					RequiredXp = 16
				},
				new LevelProgressionEntry
				{
					Level = 16,
					RequiredXp = 17
				},
				new LevelProgressionEntry
				{
					Level = 17,
					RequiredXp = 18
				},
				new LevelProgressionEntry
				{
					Level = 18,
					RequiredXp = 19
				},
				new LevelProgressionEntry
				{
					Level = 19,
					RequiredXp = 20
				},
				new LevelProgressionEntry
				{
					Level = 20,
					RequiredXp = 21
				}
			},
			MatchmakingParams = new MatchmakingConfigParams
			{
				PreferEmptyRoomsFrequency = 0f,
				PreferFullRoomsFrequency = 1f
			},
			DailyObjectives = Config.dailyObjectives,
			ConfigTable = new List<ConfigTableEntry>
			{
				new ConfigTableEntry
				{
					Key = "Gift.DropChance",
					Value = "0.5"
				},
				new ConfigTableEntry
				{
					Key = "Gift.XP",
					Value = "0.5"
				}
			},
			PhotonConfig = new photonConfig
			{
				CloudRegion = "us",
				CrcCheckEnabled = false,
				EnableServerTracingAfterDisconnect = false
			},
			AutoMicMutingConfig = new AutoMicMutingConfig(),
			ServerMaintenance = new ServerMaintenance()
		});
	}
}

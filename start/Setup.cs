using System;
using System.IO;
using api;
using Newtonsoft.Json;

namespace start;

internal class Setup
{
	public static bool firsttime;

	public static void setup()
	{
		Console.Title = "RebornRec - Setting Up";
		Console.ForegroundColor = ConsoleColor.Yellow;
		Console.WriteLine("Setting up... (May take a minute to download everything.)");
		Directory.CreateDirectory("SaveData/App");
		Directory.CreateDirectory("SaveData/Profile");
		Directory.CreateDirectory("SaveData/Photos");
		Directory.CreateDirectory("SaveData/Rooms");
		Directory.CreateDirectory("SaveData/Inventions");
		if (!File.Exists("SaveData/App/firsttime.txt"))
		{
			File.WriteAllText("SaveData/App/firsttime.txt", "this text file has no use other than to tell the program whether to bring up the intro or not, so i can just write random shit here. among us balls, you suck mad dick you big fat tr----");
			firsttime = true;
		}
		if (!File.Exists("SaveData/avatar.txt") || File.ReadAllText("SaveData/avatar.txt") == "")
		{
			File.WriteAllText("SaveData/avatar.txt", Program.webClient.DownloadString("https://raw.githubusercontent.com/aqquad/RebornRec/main/avatar.txt"));
		}
		if (!File.Exists("SaveData/avataritems.txt"))
		{
			File.WriteAllText("SaveData/avataritems.txt", Program.webClient.DownloadString("https://raw.githubusercontent.com/aqquad/RebornRec/main/avataritems.txt"));
		}
		if (!File.Exists("SaveData/equipment.txt"))
		{
			File.WriteAllText("SaveData/equipment.txt", Program.webClient.DownloadString("https://raw.githubusercontent.com/aqquad/RebornRec/main/equipment.txt"));
		}
		if (!File.Exists("SaveData/consumables.txt"))
		{
			File.WriteAllText("SaveData/consumables.txt", Program.webClient.DownloadString("https://raw.githubusercontent.com/aqquad/RebornRec/main/consumables.txt"));
		}
		if (!File.Exists("SaveData/gameconfigs.txt"))
		{
			File.WriteAllText("SaveData/gameconfigs.txt", Program.webClient.DownloadString("https://raw.githubusercontent.com/aqquad/RebornRec/main/gameconfigs.txt"));
		}
		if (!File.Exists("SaveData/baserooms.txt"))
		{
			File.WriteAllText("SaveData/baserooms.txt", Program.webClient.DownloadString("https://raw.githubusercontent.com/aqquad/RebornRec/main/baserooms.txt"));
		}
		if (!File.Exists("SaveData/profileimage.png"))
		{
			File.WriteAllBytes("SaveData/profileimage.png", Program.webClient.DownloadData("https://raw.githubusercontent.com/aqquad/RebornRec/main/profileimage.png"));
		}
		if (!File.Exists("SaveData/App/privaterooms.txt"))
		{
			File.WriteAllText("SaveData/App/privaterooms.txt", "");
		}
		if (!File.Exists("SaveData/Profile/userid.txt"))
		{
			File.WriteAllText("SaveData/Profile/userid.txt", new Random().Next(1000000, 10000000).ToString());
		}
		if (!File.Exists("SaveData/Profile/username.txt"))
		{
			File.WriteAllText("SaveData/Profile/username.txt", "RebornRec User#" + File.ReadAllText("SaveData/Profile/userid.txt"));
		}
		if (!File.Exists("SaveData/Profile/cheer.txt"))
		{
			File.WriteAllText("SaveData/Profile/cheer.txt", new Random().Next(1, 6) + "0");
		}
		if (!File.Exists("SaveData/Profile/level.txt"))
		{
			File.WriteAllText("SaveData/Profile/level.txt", new Random().Next(10, 51).ToString());
		}
		if (!File.Exists("SaveData/settings.txt"))
		{
			File.WriteAllText("SaveData/settings.txt", JsonConvert.SerializeObject(Settings.CreateDefaultSettings()));
		}
		if (!File.Exists("SaveData/bookmarks.txt"))
		{
			File.WriteAllText("SaveData/bookmarks.txt", "[]");
		}
		if (!File.Exists("SaveData/outfits.txt"))
		{
			File.WriteAllText("SaveData/outfits.txt", "");
		}
		Console.Clear();
	}
}

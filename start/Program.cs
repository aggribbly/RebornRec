using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Principal;
using System.Threading;
using api;
using server;

namespace start;

internal class Program
{
	public static int version = 0;

	public static int buildversion = 0;

	public static string appversion = "0.5.1";

	public static bool flag = false;

	public static bool admin = new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);

	public static HttpListener apiserver = null;

	public static WebClient webClient = new WebClient();

	private static void Main()
	{
		Setup.setup();
		while (Setup.firsttime)
		{
			Console.Title = "RebornRec - Intro";
			Console.WriteLine("Welcome to RebornRec 0.5.1!" + Environment.NewLine + "Is this your first time using RebornRec?" + Environment.NewLine + "Yes or No (Y, N)");
			ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
			Console.Clear();
			if (consoleKeyInfo.Key == ConsoleKey.Y)
			{
				Console.Title = "RebornRec - Tutorial";
				Console.WriteLine("In that case, welcome to RebornRec!" + Environment.NewLine + "RebornRec is server software that emulates the servers of previous Rec Room versions." + Environment.NewLine + "To use RebornRec, you'll need to have builds aswell!" + Environment.NewLine + "To download builds, go to any of the builds channels inside the Discord server." + Environment.NewLine + Environment.NewLine + "Download a build and press any key to continue:");
				Console.ReadKey();
				Console.Clear();
				Console.WriteLine("Now that you have a build, what you're going to do is as follows:" + Environment.NewLine + Environment.NewLine + "1. Unzip the build into its own folder" + Environment.NewLine + "2. Start the server by pressing 5 on the main menu" + Environment.NewLine + "3. Run Recroom_Release.exe from the folder of the build you downloaded" + Environment.NewLine + Environment.NewLine + "And that's it! Press any key to go to the main menu, where you will be able to start the server!");
				Console.ReadKey();
				Console.Clear();
				break;
			}
			if (consoleKeyInfo.Key == ConsoleKey.N)
			{
				break;
			}
		}
		while (true)
		{
			Console.Title = "RebornRec - Main Menu";
			Console.WriteLine("RebornRec - Old RecRoom Server Software. (Version: Public Release 0.5.1)" + Environment.NewLine + "Discord Server: https://discord.gg/yWBNpcAQTf" + Environment.NewLine + "Made and provided by @june_x3 on Discord." + Environment.NewLine);
			if (webClient.DownloadString("https://raw.githubusercontent.com/aqquad/RebornRec/main/banned.txt").Contains(File.ReadAllText("SaveData/Profile/userid.txt")))
			{
				break;
			}
			if (webClient.DownloadString("https://raw.githubusercontent.com/aqquad/RebornRec/main/version.txt") != appversion)
			{
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine("This version of RebornRec is outdated. We recommend you install the latest version, RebornRec " + new WebClient().DownloadString("https://raw.githubusercontent.com/aqquad/RebornRec/main/version.txt") + Environment.NewLine);
				Console.ForegroundColor = ConsoleColor.Yellow;
			}
			if (File.ReadAllText("SaveData/Profile/username.txt").StartsWith("RebornRec User#"))
			{
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine("It is recommended that you setup your profile before playing a build. Do this by pressing 3." + Environment.NewLine);
				Console.ForegroundColor = ConsoleColor.Yellow;
			}
			if (admin)
			{
				Console.ForegroundColor = ConsoleColor.Magenta;
				Console.WriteLine("Quest Mode Activated! This mode is for using RebornRec with Quest builds. If you did not mean to activate this mode, stop running RebornRec as admin." + Environment.NewLine);
				Console.ForegroundColor = ConsoleColor.Yellow;
			}
			Console.WriteLine("(1) What's New" + Environment.NewLine + "(2) Settings Menu" + Environment.NewLine + "(3) Modify Profile" + Environment.NewLine + "(4) Build Download Links" + Environment.NewLine + "(5) Start Server");
			while (true)
			{
				ConsoleKeyInfo consoleKeyInfo2 = Console.ReadKey();
				if (consoleKeyInfo2.Key == ConsoleKey.D1 || consoleKeyInfo2.Key == ConsoleKey.NumPad1)
				{
					Console.Clear();
					Console.Title = "RebornRec - What's New";
					Console.WriteLine(webClient.DownloadString("https://raw.githubusercontent.com/aqquad/RebornRec/main/changelog.txt") + Environment.NewLine + "Press any key to continue:");
					Console.ReadKey();
					Console.Clear();
					break;
				}
				int i;
				if (consoleKeyInfo2.Key == ConsoleKey.D2 || consoleKeyInfo2.Key == ConsoleKey.NumPad2)
				{
					Console.Clear();
					while (true)
					{
						Console.Title = "RebornRec - Settings Menu";
						Console.WriteLine("(1) Private Room ID: " + File.ReadAllText("SaveData/App/privaterooms.txt") + Environment.NewLine + "(2) Delete SaveData" + Environment.NewLine + "(3) Transfer OpenRec Data To RebornRec" + Environment.NewLine + "(4) Update Your SaveData" + Environment.NewLine + "(5) Go Back");
						ConsoleKeyInfo consoleKeyInfo3 = Console.ReadKey();
						if (consoleKeyInfo3.Key == ConsoleKey.D1 || consoleKeyInfo3.Key == ConsoleKey.NumPad1)
						{
							Console.Clear();
							while (true)
							{
								Console.Title = "RebornRec - Private Rooms";
								Console.ForegroundColor = ConsoleColor.Cyan;
								Console.WriteLine("Current ID: " + File.ReadAllText("SaveData/App/privaterooms.txt"));
								Console.ForegroundColor = ConsoleColor.Yellow;
								Console.WriteLine("(1) Clear Private Rooms ID" + Environment.NewLine + "(2) Change Private Rooms ID" + Environment.NewLine + "(3) Go Back");
								ConsoleKeyInfo consoleKeyInfo4 = Console.ReadKey();
								if (consoleKeyInfo4.Key == ConsoleKey.D1 || consoleKeyInfo4.Key == ConsoleKey.NumPad1)
								{
									File.WriteAllText("SaveData/App/privaterooms.txt", "");
									Console.Clear();
								}
								else if (consoleKeyInfo4.Key == ConsoleKey.D2 || consoleKeyInfo4.Key == ConsoleKey.NumPad2)
								{
									Console.Clear();
									Console.WriteLine("Current ID: " + File.ReadAllText("SaveData/App/privaterooms.txt") + Environment.NewLine + "New ID:");
									string contents = Console.ReadLine();
									File.WriteAllText("SaveData/App/privaterooms.txt", contents);
									Console.Clear();
									Console.ForegroundColor = ConsoleColor.Green;
									Console.WriteLine("Success! Your new Private Rooms ID is: " + File.ReadAllText("SaveData/App/privaterooms.txt"));
									Console.ForegroundColor = ConsoleColor.Yellow;
								}
								else
								{
									if (consoleKeyInfo4.Key == ConsoleKey.D3 || consoleKeyInfo4.Key == ConsoleKey.NumPad3)
									{
										break;
									}
									Console.Clear();
								}
							}
							Console.Clear();
						}
						else if (consoleKeyInfo3.Key == ConsoleKey.D2 || consoleKeyInfo3.Key == ConsoleKey.NumPad2)
						{
							Console.Clear();
							Console.Title = "RebornRec - Delete SaveData";
							Console.WriteLine("Are you sure you want to PERMANENTLY delete your save data?" + Environment.NewLine + "(1) Yes" + Environment.NewLine + "(2) No" + Environment.NewLine + "(Press enter to ensure your choice.)");
							if (Console.ReadLine() == "1")
							{
								Console.Clear();
								Console.WriteLine("Deleting save data...");
								File.Delete("SaveData/avatar.txt");
								File.Delete("SaveData/avataritems.txt");
								File.Delete("SaveData/equipment.txt");
								File.Delete("SaveData/consumables.txt");
								File.Delete("SaveData/gameconfigs.txt");
								File.Delete("SaveData/settings.txt");
								File.Delete("SaveData/baserooms.txt");
								File.Delete("SaveData/outfits.txt");
								File.Delete("SaveData/profileimage.png");
								File.Delete("SaveData/App/firsttime.txt");
								File.Delete("SaveData/App/privaterooms.txt");
								string[] files = Directory.GetFiles("SaveData/Photos");
								for (i = 0; i < files.Length; i++)
								{
									File.Delete(files[i]);
								}
								File.Delete("SaveData/Profile/username.txt");
								File.Delete("SaveData/Profile/cheer.txt");
								File.Delete("SaveData/Profile/level.txt");
								File.Delete("SaveData/Profile/userid.txt");
								files = Directory.GetDirectories("SaveData/Rooms");
								for (i = 0; i < files.Length; i++)
								{
									string obj = files[i];
									File.Delete(obj + "/RoomDetails.json");
									Directory.Delete(obj + "/room", recursive: true);
									Directory.Delete(obj + "/data", recursive: true);
									Directory.Delete(obj);
								}
								Console.ForegroundColor = ConsoleColor.Green;
								Console.WriteLine("Success!");
								Thread.Sleep(269);
								Setup.setup();
							}
							else
							{
								Console.Clear();
							}
						}
						else if (consoleKeyInfo3.Key == ConsoleKey.D3 || consoleKeyInfo3.Key == ConsoleKey.NumPad3)
						{
							Console.Clear();
							Console.Title = "RebornRec - Transfer OpenRec Data";
							Console.WriteLine("Drag any OpenRec folder onto this window and press enter to transfer your OpenRec data to RebornRec:");
							string text = Console.ReadLine();
							if (text.StartsWith('"'))
							{
								text = text.Substring(1, text.Length - 2);
							}
							if (text.EndsWith("SaveData"))
							{
								text = text.Substring(0, text.Length - 10);
							}
							if (Directory.Exists(text + "/SaveData"))
							{
								File.WriteAllText("SaveData/Profile/username.txt", File.ReadAllText(text + "/SaveData/Profile/username.txt"));
								File.WriteAllText("SaveData/Profile/level.txt", File.ReadAllText(text + "/SaveData/Profile/level.txt"));
								if (File.ReadAllText(text + "/SaveData/App/privaterooms.txt") == "Enabled")
								{
									i = new Random().Next(1000000, 10000000);
									File.WriteAllText("SaveData/App/privaterooms.txt", i.ToString());
								}
								File.WriteAllText("SaveData/avatar.txt", File.ReadAllText(text + "/SaveData/avatar.txt"));
								Settings.SetPlayerSettings(File.ReadAllText(text + "/SaveData/settings.txt"));
								File.WriteAllBytes("SaveData/profileimage.png", File.ReadAllBytes(text + "/SaveData/profileimage.png"));
								Console.Clear();
								Console.ForegroundColor = ConsoleColor.Green;
								Console.WriteLine("Success!");
								Console.ForegroundColor = ConsoleColor.Yellow;
							}
							else
							{
								Console.Clear();
								Console.ForegroundColor = ConsoleColor.Red;
								Console.WriteLine("Invalid folder, make sure you're dragging the OpenRec or SaveData folder!");
								Console.ForegroundColor = ConsoleColor.Yellow;
							}
						}
						else if (consoleKeyInfo3.Key == ConsoleKey.D4 || consoleKeyInfo3.Key == ConsoleKey.NumPad4)
						{
							Console.Clear();
							while (true)
							{
								Console.Title = "RebornRec - Update SaveData";
								Console.WriteLine("This will update your SaveData to ensure you have the latest avatar items, skins, consumables and base rooms available.");
								Console.WriteLine("(1) Yes" + Environment.NewLine + "(2) No");
								ConsoleKeyInfo consoleKeyInfo5 = Console.ReadKey();
								if (consoleKeyInfo5.Key == ConsoleKey.D1 || consoleKeyInfo5.Key == ConsoleKey.NumPad1)
								{
									Console.Clear();
									Console.WriteLine("Updating SaveData... (May take a minute to download everything.)");
									File.WriteAllText("SaveData/avataritems.txt", webClient.DownloadString("https://raw.githubusercontent.com/aqquad/RebornRec/main/avataritems.txt"));
									string playerEquipment = File.ReadAllText("SaveData/equipment.txt");
									File.WriteAllText("SaveData/equipment.txt", webClient.DownloadString("https://raw.githubusercontent.com/aqquad/RebornRec/main/equipment.txt"));
									Equipment.SetPlayerEquipment(playerEquipment);
									string jsonData = File.ReadAllText("SaveData/consumables.txt");
									File.WriteAllText("SaveData/consumables.txt", webClient.DownloadString("https://raw.githubusercontent.com/aqquad/RebornRec/main/consumables.txt"));
									Consumables.SetPlayerConsumables(jsonData, type: true);
									File.WriteAllText("SaveData/baserooms.txt", webClient.DownloadString("https://raw.githubusercontent.com/aqquad/RebornRec/main/baserooms.txt"));
									File.WriteAllText("SaveData/gameconfigs.txt", webClient.DownloadString("https://raw.githubusercontent.com/aqquad/RebornRec/main/gameconfigs.txt"));
									Console.Clear();
									Console.ForegroundColor = ConsoleColor.Green;
									Console.WriteLine("Success!");
									Console.ForegroundColor = ConsoleColor.Yellow;
									break;
								}
								if (consoleKeyInfo5.Key == ConsoleKey.D2 || consoleKeyInfo5.Key == ConsoleKey.NumPad2)
								{
									Console.Clear();
									break;
								}
								Console.Clear();
							}
						}
						else
						{
							if (consoleKeyInfo3.Key == ConsoleKey.D5 || consoleKeyInfo3.Key == ConsoleKey.NumPad5)
							{
								break;
							}
							Console.Clear();
						}
					}
					Console.Clear();
					break;
				}
				if (consoleKeyInfo2.Key == ConsoleKey.D3 || consoleKeyInfo2.Key == ConsoleKey.NumPad3)
				{
					Console.Clear();
					while (true)
					{
						Console.Title = "RebornRec - Profile Menu";
						Console.WriteLine("(1) Change Username" + Environment.NewLine + "(2) Change Profile Image" + Environment.NewLine + "(3) Change Level" + Environment.NewLine + "(4) Change Cheer Badge" + Environment.NewLine + "(5) Go Back");
						ConsoleKeyInfo consoleKeyInfo6 = Console.ReadKey();
						Console.Clear();
						if (consoleKeyInfo6.Key == ConsoleKey.D1 || consoleKeyInfo6.Key == ConsoleKey.NumPad1)
						{
							Console.WriteLine("Current Username: " + File.ReadAllText("SaveData/Profile/username.txt") + Environment.NewLine + "New Username:");
							string contents2 = Console.ReadLine();
							File.WriteAllText("SaveData/Profile/username.txt", contents2);
							Console.Clear();
							Console.ForegroundColor = ConsoleColor.Green;
							Console.WriteLine("Success!");
							Console.ForegroundColor = ConsoleColor.Yellow;
						}
						else if (consoleKeyInfo6.Key == ConsoleKey.D2 || consoleKeyInfo6.Key == ConsoleKey.NumPad2)
						{
							ConsoleKeyInfo consoleKeyInfo7;
							do
							{
								IL_0b66:
								Console.WriteLine("(1) Upload Media Link" + Environment.NewLine + "(2) Drag Image Onto This Window" + Environment.NewLine + "(3) Go Back");
								consoleKeyInfo7 = Console.ReadKey();
								Console.Clear();
								if (consoleKeyInfo7.Key == ConsoleKey.D1 || consoleKeyInfo7.Key == ConsoleKey.NumPad1)
								{
									Console.WriteLine("Paste the media link and press enter:");
									string address = Console.ReadLine();
									try
									{
										File.WriteAllBytes("SaveData/profileimage.png", webClient.DownloadData(address));
									}
									catch
									{
										Console.Clear();
										Console.ForegroundColor = ConsoleColor.Red;
										Console.WriteLine("Invalid media link!");
										Console.ForegroundColor = ConsoleColor.Yellow;
										goto IL_0b66;
									}
									Console.Clear();
									Console.ForegroundColor = ConsoleColor.Green;
									Console.WriteLine("Success!");
									Console.ForegroundColor = ConsoleColor.Yellow;
									break;
								}
								if (consoleKeyInfo7.Key == ConsoleKey.D2 || consoleKeyInfo7.Key == ConsoleKey.NumPad2)
								{
									Console.WriteLine("Drag any image onto this window and press enter:");
									string text2 = Console.ReadLine();
									if (text2.StartsWith('"'))
									{
										text2 = text2.Substring(1, text2.Length - 2);
									}
									try
									{
										File.WriteAllBytes("SaveData/profileimage.png", File.ReadAllBytes(text2));
									}
									catch
									{
										Console.Clear();
										Console.ForegroundColor = ConsoleColor.Red;
										Console.WriteLine("Invalid image!");
										Console.ForegroundColor = ConsoleColor.Yellow;
										goto IL_0b66;
									}
									Console.Clear();
									Console.ForegroundColor = ConsoleColor.Green;
									Console.WriteLine("Success!");
									Console.ForegroundColor = ConsoleColor.Yellow;
									break;
								}
							}
							while (consoleKeyInfo7.Key != ConsoleKey.D3 && consoleKeyInfo7.Key != ConsoleKey.NumPad3);
						}
						else if (consoleKeyInfo6.Key == ConsoleKey.D3 || consoleKeyInfo6.Key == ConsoleKey.NumPad3)
						{
							Console.WriteLine("Current Level: " + File.ReadAllText("SaveData/Profile/level.txt") + Environment.NewLine + "New Level:");
							string text3 = Console.ReadLine();
							if (int.TryParse(text3, out i))
							{
								File.WriteAllText("SaveData/Profile/level.txt", text3);
								Console.Clear();
								Console.ForegroundColor = ConsoleColor.Green;
								Console.WriteLine("Success!");
								Console.ForegroundColor = ConsoleColor.Yellow;
							}
							else
							{
								Console.Clear();
								Console.ForegroundColor = ConsoleColor.Red;
								Console.WriteLine("Must be a vaild number!");
								Console.ForegroundColor = ConsoleColor.Yellow;
							}
						}
						else if (consoleKeyInfo6.Key == ConsoleKey.D4 || consoleKeyInfo6.Key == ConsoleKey.NumPad4)
						{
							Console.WriteLine("Cheers: 0, Helpful: 10, Good Sport: 20, Great Host: 30, Creative: 40" + Environment.NewLine + "Current Cheer Badge: " + File.ReadAllText("SaveData/Profile/cheer.txt") + Environment.NewLine + "New Cheer Badge (type in the cheer's number):");
							string text4 = Console.ReadLine();
							if (int.TryParse(text4, out i))
							{
								File.WriteAllText("SaveData/Profile/cheer.txt", text4);
								Console.Clear();
								Console.ForegroundColor = ConsoleColor.Green;
								Console.WriteLine("Success!");
								Console.ForegroundColor = ConsoleColor.Yellow;
							}
							else
							{
								Console.Clear();
								Console.ForegroundColor = ConsoleColor.Red;
								Console.WriteLine("Must be a vaild number!");
								Console.ForegroundColor = ConsoleColor.Yellow;
							}
						}
						else if (consoleKeyInfo6.Key == ConsoleKey.D5 || consoleKeyInfo6.Key == ConsoleKey.NumPad5)
						{
							break;
						}
					}
					break;
				}
				if (consoleKeyInfo2.Key == ConsoleKey.D4 || consoleKeyInfo2.Key == ConsoleKey.NumPad4)
				{
					Console.Clear();
					Console.Title = "RebornRec - Build Downloads";
					Console.WriteLine("To download builds, go to any of the builds channels inside the Discord server." + Environment.NewLine + Environment.NewLine + "Download a build and press any key to continue:");
					Console.ReadKey();
					Console.Clear();
					break;
				}
				if (consoleKeyInfo2.Key == ConsoleKey.D5 || consoleKeyInfo2.Key == ConsoleKey.NumPad5)
				{
					Console.Clear();
					Console.Title = "RebornRec - Waiting for build...";
					new NameServer();
					new APIServer();
					while (!apiserver.IsListening)
					{
					}
					Thread.Sleep(10);
					if (admin)
					{
						Console.ForegroundColor = ConsoleColor.Magenta;
						Console.WriteLine("Address: " + GetMyHost());
					}
					Console.ForegroundColor = ConsoleColor.Cyan;
					Console.WriteLine("Please start up the build you want now.");
					Console.ForegroundColor = ConsoleColor.Yellow;
					return;
				}
			}
		}
		Console.ForegroundColor = ConsoleColor.Red;
		Console.WriteLine("You are banned. Go use OpenRec instead.");
		flag = true;
		while (true)
		{
			Console.ReadLine();
		}
	}

	public static string GetMyHost()
	{
		IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
		foreach (IPAddress iPAddress in addressList)
		{
			if (iPAddress.AddressFamily == AddressFamily.InterNetwork)
			{
				return iPAddress.ToString();
			}
		}
		return "";
	}
}

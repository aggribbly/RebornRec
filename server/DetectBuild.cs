using System;
using start;
using vaultgamesesh;
using ws;

namespace server;

internal class DetectBuild
{
	public static string CurrentVersion = "";

	public static void DetectVersion(string Version)
	{
		if (Version.StartsWith("2020"))
		{
			if (CurrentVersion != "2020")
			{
				Console.Title = "RebornRec - 2020";
				Program.version = 2019;
				CurrentVersion = "2020";
				Program.buildversion = int.Parse(Version.Substring(0, 8));
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine("Version Detected: 2020.");
				Console.ForegroundColor = ConsoleColor.Yellow;
				if (ImageServer.instance == null)
				{
					new ImageServer();
				}
				if (Program.apiserver == null)
				{
					new APIServer();
				}
				if (WebSocket.instance != null)
				{
					WebSocket.instance.WebSock.Stop();
				}
				if (Late2018WebSock.instance != null)
				{
					Late2018WebSock.instance.WebSock.Stop();
					Late2018WebSock.instance = null;
				}
				if (WebSocketYamaka.instance == null)
				{
					new WebSocketYamaka();
				}
			}
		}
		else if (Version.StartsWith("2019"))
		{
			if (CurrentVersion != "2019")
			{
				Console.Title = "RebornRec - 2019";
				Program.version = 2019;
				CurrentVersion = "2019";
				Program.buildversion = int.Parse(Version.Substring(0, 8));
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine("Version Detected: 2019.");
				Console.ForegroundColor = ConsoleColor.Yellow;
				if (ImageServer.instance == null)
				{
					new ImageServer();
				}
				if (Program.apiserver == null)
				{
					new APIServer();
				}
				if (WebSocket.instance != null)
				{
					WebSocket.instance.WebSock.Stop();
				}
				if (Late2018WebSock.instance != null)
				{
					Late2018WebSock.instance.WebSock.Stop();
					Late2018WebSock.instance = null;
				}
				if (WebSocketYamaka.instance == null)
				{
					new WebSocketYamaka();
				}
			}
		}
		else if (Version.StartsWith("20181") || Version.StartsWith("201809"))
		{
			if (CurrentVersion != "20182")
			{
				Console.Title = "RebornRec - Late 2018";
				Program.version = 2018;
				CurrentVersion = "20182";
				Program.buildversion = int.Parse(Version.Substring(0, 8));
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine("Version Detected: Late 2018.");
				Console.ForegroundColor = ConsoleColor.Yellow;
				if (ImageServer.instance == null)
				{
					new ImageServer();
				}
				if (Program.apiserver == null)
				{
					new APIServer();
				}
				if (WebSocketYamaka.instance != null)
				{
					WebSocketYamaka.instance.listener.Prefixes.Clear();
					WebSocketYamaka.instance = null;
				}
				if (Late2018WebSock.instance == null)
				{
					new Late2018WebSock();
				}
			}
		}
		else if (Version.StartsWith("2018"))
		{
			if (CurrentVersion != "2018")
			{
				Console.Title = "RebornRec - 2018";
				Program.version = 2018;
				CurrentVersion = "2018";
				Program.buildversion = int.Parse(Version.Substring(0, 8));
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine("Version Detected: 2018.");
				Console.ForegroundColor = ConsoleColor.Yellow;
				if (ImageServer.instance == null)
				{
					new ImageServer();
				}
				if (Program.apiserver == null)
				{
					new APIServer();
				}
				if (WebSocketYamaka.instance != null)
				{
					WebSocketYamaka.instance.listener.Prefixes.Clear();
					WebSocketYamaka.instance = null;
				}
				if (WebSocket.instance == null)
				{
					new WebSocket();
				}
			}
		}
		else if (Version.StartsWith("2017"))
		{
			if (CurrentVersion != "2017")
			{
				Console.Title = "RebornRec - 2017";
				Program.version = 2017;
				CurrentVersion = "2017";
				if (Version != "2017")
				{
					Program.buildversion = int.Parse(Version.Substring(0, 8));
				}
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine("Version Detected: 2017.");
				Console.ForegroundColor = ConsoleColor.Yellow;
				if (ImageServer.instance == null)
				{
					new ImageServer();
				}
				if (Program.apiserver == null)
				{
					new APIServer();
				}
				if (WebSocketYamaka.instance != null)
				{
					WebSocketYamaka.instance.listener.Prefixes.Clear();
					WebSocketYamaka.instance = null;
				}
				if (WebSocket.instance == null)
				{
					new WebSocket();
				}
			}
		}
		else if (Version == "2016/2017")
		{
			if (CurrentVersion != "2016/2017")
			{
				Console.Title = "RebornRec - 2016/2017";
				Program.version = 2016;
				CurrentVersion = "2016/2017";
				Program.buildversion = 0;
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine("Version Detected: 2016/2017.");
				Console.ForegroundColor = ConsoleColor.Yellow;
				if (Program.apiserver == null)
				{
					new APIServer();
				}
				if (WebSocketYamaka.instance != null)
				{
					WebSocketYamaka.instance.listener.Prefixes.Clear();
					WebSocketYamaka.instance = null;
				}
				if (WebSocket.instance == null)
				{
					new WebSocket();
				}
			}
		}
		else if (CurrentVersion != "2019")
		{
			Console.Title = "RebornRec - Unknown Version";
			Program.version = 2019;
			CurrentVersion = "2019";
			Program.buildversion = 0;
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("Unknown Version Detected! Be prepared for issues!");
			Console.ForegroundColor = ConsoleColor.Yellow;
			if (ImageServer.instance == null)
			{
				new ImageServer();
			}
			if (Program.apiserver == null)
			{
				new APIServer();
			}
			if (WebSocket.instance != null)
			{
				WebSocket.instance.WebSock.Stop();
			}
			if (Late2018WebSock.instance != null)
			{
				Late2018WebSock.instance.WebSock.Stop();
				Late2018WebSock.instance = null;
			}
			if (WebSocketYamaka.instance == null)
			{
				new WebSocketYamaka();
			}
		}
	}
}

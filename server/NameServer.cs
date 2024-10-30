using System;
using System.Net;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using start;

namespace server;

internal class NameServer
{
	public class NSData
	{
		public string API { get; set; }

		public string Notifications { get; set; }

		public string Images { get; set; }
	}

	public class NSData2
	{
		public string Auth { get; set; }

		public string API { get; set; }

		public string WWW { get; set; }

		public string Notifications { get; set; }

		public string Images { get; set; }

		public string CDN { get; set; }

		public string Commerce { get; set; }

		public string Matchmaking { get; set; }

		public string Storage { get; set; }

		public string Chat { get; set; }

		public string Leaderboard { get; set; }

		public string Accounts { get; set; }

		public string Link { get; set; }
	}

	private readonly HttpListener listener = new HttpListener();

	public NameServer()
	{
		try
		{
			Console.WriteLine("[NameServer.cs] has started.");
			new Thread(StartListen).Start();
		}
		catch (Exception ex)
		{
			Console.WriteLine("An exception occurred while listening!: " + ex.ToString());
		}
	}

	private void StartListen()
	{
		if (Program.admin)
		{
			listener.Prefixes.Add("http://" + Program.GetMyHost() + ":2059/");
		}
		else
		{
			listener.Prefixes.Add("http://localhost:2059/");
		}
		listener.Start();
		while (true)
		{
			Console.WriteLine("[NameServer.cs] is listening.");
			HttpListenerContext context = listener.GetContext();
			HttpListenerResponse response = context.Response;
			string text = ((!context.Request.RawUrl.EndsWith('2')) ? JsonConvert.SerializeObject(new NSData
			{
				API = "http://localhost:2056",
				Notifications = "ws://localhost:2057",
				Images = "http://localhost:2058"
			}) : ((!Program.admin) ? JsonConvert.SerializeObject(new NSData2
			{
				Auth = "http://localhost:2056",
				API = "http://localhost:2056",
				WWW = "http://localhost:2056",
				Notifications = "http://localhost:2057",
				Images = "http://localhost:2058",
				CDN = "http://localhost:2058",
				Commerce = "http://localhost:2056",
				Matchmaking = "http://localhost:2056",
				Storage = "http://localhost:2058",
				Chat = "http://localhost:2056",
				Leaderboard = "http://localhost:2056",
				Accounts = "http://localhost:2056",
				Link = "http://localhost:2056"
			}) : JsonConvert.SerializeObject(new NSData2
			{
				Auth = "http://" + Program.GetMyHost() + ":2056",
				API = "http://" + Program.GetMyHost() + ":2056",
				WWW = "http://" + Program.GetMyHost() + ":2056",
				Notifications = "http://" + Program.GetMyHost() + ":2057",
				Images = "http://" + Program.GetMyHost() + ":2058",
				CDN = "http://" + Program.GetMyHost() + ":2058",
				Commerce = "http://" + Program.GetMyHost() + ":2056",
				Matchmaking = "http://" + Program.GetMyHost() + ":2056"
			})));
			Console.WriteLine("NameServer Response: " + text);
			byte[] bytes = Encoding.UTF8.GetBytes(text);
			response.ContentLength64 = bytes.Length;
			response.OutputStream.Write(bytes, 0, bytes.Length);
			response.OutputStream.Flush();
		}
	}
}

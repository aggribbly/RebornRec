using System;
using System.Collections.Generic;
using System.Text;
using api2018;
using Newtonsoft.Json;
using start;
using WebSocketSharp;
using WebSocketSharp.Server;
using ws;

namespace vaultgamesesh;

public class Late2018WebSock
{
	public class HubWS : WebSocketBehavior
	{
		protected override void OnMessage(MessageEventArgs e)
		{
			Console.WriteLine("[LateWebSocket.cs] hub requested.");
			if (Encoding.ASCII.GetString(e.RawData).Contains("SubscribeToPlayers"))
			{
				Send(JsonConvert.SerializeObject(new SignalR
				{
					type = 1,
					result = "200 OK",
					nonblocking = true,
					target = "Notification",
					arguments = new object[1] { JsonConvert.SerializeObject(Notification.Reponse.CreateResponse(12, c000020.m000027())) },
					error = "",
					invocationId = "uwu",
					item = ""
				}) + "\u001e");
			}
			else
			{
				Send(JsonConvert.SerializeObject(new SignalR
				{
					type = 1,
					result = "200 OK",
					nonblocking = true,
					target = "HubConnection",
					arguments = new object[1] { JsonConvert.SerializeObject(new Hub()) },
					error = "",
					invocationId = "owo",
					item = ""
				}) + "\u001e");
			}
		}
	}

	public class Hub : WebSocketBehavior
	{
		public Uri url { get; set; }

		public string ConnectionId { get; set; }

		public List<string> SupportedTransports { get; set; }

		public int negotiateVersion { get; set; }

		public Hub()
		{
			ConnectionId = "RebornConnect";
			url = new Uri("ws://localhost:2057");
			SupportedTransports = new List<string>();
			negotiateVersion = 0;
		}
	}

	public class NotificationWS : WebSocketBehavior
	{
		protected override void OnMessage(MessageEventArgs p0)
		{
			if (Program.flag)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("You are banned.");
				Console.ForegroundColor = ConsoleColor.Yellow;
				instance.Broadcast(Notification2018.Reponse.createResponse2());
			}
			else
			{
				Console.WriteLine("[LateWebSocket.cs] notification requested.");
				Send(Notification2018.ProcessRequest(p0.Data));
			}
		}
	}

	public static Late2018WebSock instance;

	public WebSocketServer WebSock = new WebSocketServer("ws://localhost:2057");

	public Late2018WebSock()
	{
		instance = this;
		WebSock.AddWebSocketService<NotificationWS>("/api/notification/v2");
		WebSock.AddWebSocketService<HubWS>("/hub/v1");
		WebSock.Start();
		Console.WriteLine("[LateWebSocket.cs] has started and is listening.");
	}

	public void Broadcast(Notification2018.Reponse res)
	{
		WebSock.WebSocketServices["/api/notification/v2"].Sessions.Broadcast(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(res)));
		Console.WriteLine(string.Concat(new string[2]
		{
			"[LateWebSocket.cs] broadcasted ",
			JsonConvert.SerializeObject(res)
		}));
	}
}

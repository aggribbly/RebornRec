using System;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using server;
using start;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace ws;

internal class WebSocket
{
	public class NotificationV2 : WebSocketBehavior
	{
		protected override void OnMessage(MessageEventArgs e)
		{
			if (Program.flag)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("You are banned.");
				Console.ForegroundColor = ConsoleColor.Yellow;
				return;
			}
			Console.WriteLine("[WebSocket.cs] called for.");
			if (Program.version == 2017 && Program.buildversion == 0)
			{
				Send(Notification.ProcessRequest(string.Concat(e.Data.AsSpan(0, e.Data.Length - 1), ",\"SessionId\":\"1\"}")));
			}
			else if (DetectBuild.CurrentVersion == "2016/2017")
			{
				if (e.Data.Contains("n\":\"2017"))
				{
					DetectBuild.DetectVersion("2017");
					Send(Notification.ProcessRequest(string.Concat(e.Data.AsSpan(0, e.Data.Length - 1), ",\"SessionId\":\"1\"}")));
				}
				else if (e.Data.Contains("\"L"))
				{
					DetectBuild.DetectVersion("2018");
					Send(Notification.ProcessRequest(e.Data));
				}
				else
				{
					Send(Notification.ProcessRequest(e.Data));
				}
			}
			else
			{
				Send(Notification.ProcessRequest(e.Data));
			}
		}
	}

	public static WebSocket instance;

	public WebSocketServer WebSock = new WebSocketServer(IPAddress.Loopback, 2057);

	public WebSocket()
	{
		instance = this;
		WebSock.AddWebSocketService<NotificationV2>("/api/notification/v2");
		WebSock.AddWebSocketService<NotificationV2>("/hub/v1");
		WebSock.Start();
		Console.WriteLine("[WebSocket.cs] has started and is listening.");
	}

	public void Broadcast(Notification.Reponse res)
	{
		WebSock.WebSocketServices["/api/notification/v2"].Sessions.Broadcast(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(res)));
		Console.WriteLine(string.Concat(new string[2]
		{
			"[WebSocket.cs] broadcasted ",
			JsonConvert.SerializeObject(res)
		}));
	}
}

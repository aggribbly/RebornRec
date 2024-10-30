using System;
using System.IO;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using api;
using api2018;
using Newtonsoft.Json;
using start;

namespace vaultgamesesh;

public class WebSocketYamaka
{
	private static WebSocket ws;

	public readonly HttpListener listener = new HttpListener();

	public static WebSocketYamaka instance;

	public static bool flag;

	public WebSocketYamaka()
	{
		try
		{
			Console.WriteLine("[WebSocket.cs] has started.");
			new Thread(StartListen).Start();
			instance = this;
		}
		catch (Exception ex)
		{
			Console.WriteLine("An exception occurred while listening!: " + ex.ToString());
		}
	}

	private void StartListen()
	{
		try
		{
			if (Program.admin)
			{
				listener.Prefixes.Add("http://" + Program.GetMyHost() + ":2057/");
			}
			else
			{
				listener.Prefixes.Add("http://localhost:2057/");
			}
			listener.Start();
			while (true)
			{
				Console.WriteLine("[WebSocket.cs] is listening.");
				HttpListenerContext context = listener.GetContext();
				string text = "";
				if (context.Request.IsWebSocketRequest)
				{
					SetWebSocket(context);
					if (!flag)
					{
						ProcessRequest(context);
					}
					else
					{
						HeartbeatEvents.OnRoomChangeEvent();
					}
				}
				else
				{
					text = ((!(context.Request.RawUrl == "/hub/v1/negotiate")) ? "{\"negotiateVersion\":0,\"connectionId\":\"uwu\",\"availableTransports\":[{\"transport\":\"WebSockets\",\"transferFormats\":[\"Text\",\"Binary\"]}]}" : ((!Program.admin) ? JsonConvert.SerializeObject(new Late2018WebSock.Hub()) : JsonConvert.SerializeObject(new Late2018WebSock.Hub
					{
						url = new Uri("http://" + Program.GetMyHost() + ":2057")
					})));
					byte[] bytes = Encoding.UTF8.GetBytes(text);
					context.Response.ContentLength64 = bytes.Length;
					context.Response.OutputStream.Write(bytes, 0, bytes.Length);
					context.Response.OutputStream.Flush();
				}
			}
		}
		catch (Exception ex)
		{
			File.WriteAllText("WebSocketPrismError.txt", ex.ToString());
			Console.WriteLine(ex);
			new WebSocketYamaka();
		}
	}

	private static async void SetWebSocket(HttpListenerContext ctx)
	{
		ws = (await ctx.AcceptWebSocketAsync(null)).WebSocket;
	}

	private static async void ProcessRequest(HttpListenerContext ctx)
	{
		CancellationTokenSource src = new CancellationTokenSource();
		flag = true;
		byte[] respond = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(new SignalR
		{
			type = 1,
			result = "200 OK",
			nonblocking = true,
			target = "Notification",
			arguments = new object[1] { JsonConvert.SerializeObject(Notification2018.Reponse.createResponse(12, c000020.m000027())) },
			error = "",
			invocationId = "uwu",
			item = ""
		}) + "\u001e");
		await ws.SendAsync(new ArraySegment<byte>(respond, 0, respond.Length), WebSocketMessageType.Text, endOfMessage: true, src.Token);
		HeartbeatEvents.RoomChangeEvent += delegate
		{
			ws.SendAsync(new ArraySegment<byte>(respond, 0, respond.Length), WebSocketMessageType.Text, endOfMessage: true, src.Token);
		};
		HeartbeatEvents.MatchChangeEvent += delegate
		{
			byte[] bytes = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(new SignalR
			{
				type = 1,
				result = "200 OK",
				nonblocking = true,
				target = "Notification",
				arguments = new object[1] { JsonConvert.SerializeObject(Notification2018.MatchReponse.createResponse("PresenceUpdate", c000020.m000028())) },
				error = "",
				invocationId = "uwu",
				item = ""
			}) + "\u001e");
			ws.SendAsync(new ArraySegment<byte>(bytes, 0, bytes.Length), WebSocketMessageType.Text, endOfMessage: true, src.Token);
		};
		await Task.Delay(-1);
	}
}

using System;
using System.Collections.Generic;
using gamesesh;
using Newtonsoft.Json;
using start;

namespace ws;

public class Notification
{
	public class Reponse
	{
		public int Id { get; set; }

		public object Msg { get; set; }

		public static Reponse CreateResponse(int id, object msg)
		{
			return new Reponse
			{
				Id = id,
				Msg = msg
			};
		}
	}

	public static string ProcessRequest(string jsonData)
	{
		Dictionary<string, object> dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonData);
		if (dictionary.ContainsKey("api"))
		{
			string text = (string)dictionary["api"];
			switch (text)
			{
			case "playerSubscriptions/v1/update":
				Console.WriteLine("[WSS] Game client sent presence update.");
				return JsonConvert.SerializeObject(Reponse.CreateResponse(12, GameSessions.StatusSession()));
			case "heartbeat":
			case "heartbeat2":
				Console.WriteLine("[WSS] Heartbeat sent by game client.");
				return JsonConvert.SerializeObject(Reponse.CreateResponse(4, GameSessions.StatusSession()));
			default:
				Console.WriteLine("[WSS] Unknown API call: " + text);
				return jsonData;
			}
		}
		if (Program.version == 2016 && !jsonData.Contains("0161222"))
		{
			return "OK";
		}
		return string.Concat(jsonData.AsSpan(0, jsonData.Length - 1), ",\"SessionId\":\"1\"}");
	}
}

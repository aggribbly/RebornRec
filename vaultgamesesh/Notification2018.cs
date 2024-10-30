using System;
using System.Collections.Generic;
using api;
using Newtonsoft.Json;
using ws;

namespace vaultgamesesh;

public class Notification2018
{
	public class Reponse
	{
		public int Id { get; set; }

		public object Msg { get; set; }

		public static Reponse createResponse(int id, object msg)
		{
			return new Reponse
			{
				Id = id,
				Msg = msg
			};
		}

		public static Reponse createResponse2()
		{
			return new Reponse
			{
				Id = 22,
				Msg = new ModerationBlockDetails
				{
					ReportCategory = 3,
					Duration = int.MaxValue,
					GameSessionId = 666L,
					Message = "You have been banned. You are probably a little kid and are now whining at your VR headset. If you aren't a little kid, DM me to appeal."
				}
			};
		}
	}

	public class MatchReponse
	{
		public string Id { get; set; }

		public object Msg { get; set; }

		public static MatchReponse createResponse(string id, object msg)
		{
			return new MatchReponse
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
			if (text == "playerSubscriptions/v1/update")
			{
				Console.WriteLine("[WSS] Game client sent presence update.");
				return JsonConvert.SerializeObject(Notification.Reponse.CreateResponse(12, c000020.m000027()));
			}
			if (text == "heartbeat2")
			{
				Console.WriteLine("[WSS] Heartbeat sent by game client.");
				return JsonConvert.SerializeObject(Notification.Reponse.CreateResponse(4, c000020.m000027()));
			}
			Console.WriteLine("[WSS] Unknown API call: " + text);
			return jsonData;
		}
		return jsonData;
	}
}

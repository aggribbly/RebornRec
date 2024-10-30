using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using api;
using api2018;
using api2019;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using start;
using vaultgamesesh;

namespace server;

internal class APIServer
{
	public static int CachedPlayerID = int.Parse(File.ReadAllText("SaveData/Profile/userid.txt"));

	public static int CachedVersionMonth = 0;

	public static string BracketResponse = "[]";

	public static string PlayerEventsResponse = "{\"Created\":[],\"Responses\":[]}";

	public static string VersionCheckResponse = "{\"ValidVersion\":true}";

	public static string GiftGenerate = "{\"Id\":1,\"AvatarItemDesc\":\"21caa68e-c3fa-474c-af5e-af1e742b7a60,5864d23d-1a86-40a6-a52c-46ee670e4508,,\",\"Xp\":2,\"Message\":\"Welcome to RebornRec!\",\"EquipmentModificationGuid\":1000}";

	public static string ModerationBlockDetails = "{\"ReportCategory\":0,\"Duration\":0,\"GameSessionId\":0,\"Message\":\"\"}";

	public static string SuccessMessage = "{\"Success\":true,\"Message\":\"RebornRec\"}";

	public static string ChecklistCurrent = "[{\"Order\":0,\"Objective\":400,\"Count\":3,\"CreditAmount\":200},{\"Order\":1,\"Objective\":1003,\"Count\":40,\"CreditAmount\":200},{\"Order\":2,\"Objective\":603,\"Count\":50,\"CreditAmount\":500},{\"Order\":3,\"Objective\":802,\"Count\":10,\"CreditAmount\":100},{\"Order\":4,\"Objective\":38,\"Count\":1,\"CreditAmount\":500},{\"Order\":5,\"Objective\":502,\"Count\":300,\"CreditAmount\":150},{\"Order\":6,\"Objective\":35,\"Count\":20,\"CreditAmount\":100}]";

	public static string ChallengeGetCurrent = "{\"Success\":true,\"Message\":\"{\\\"ChallengeMapId\\\":0,\\\"StartAt\\\":\\\"2021-12-27T21:27:38.188Z\\\",\\\"EndAt\\\":\\\"2025-12-27T21:27:38.188Z\\\",\\\"ServerTime\\\":\\\"2023-12-27T21:27:38.188Z\\\",\\\"Challenges\\\":[],\\\"Gifts\\\":[{\\\"GiftDropId\\\":1,\\\"AvatarItemDesc\\\":\\\"\\\",\\\"Xp\\\":2,\\\"Level\\\":0,\\\"EquipmentPrefabName\\\":\\\"[WaterBottle]\\\"}],\\\"ChallengeThemeString\\\":\\\"RebornRec Water\\\",\\\"ChallengeThemeId\\\":0}\"}";

	public static string ModerationBlockDetaiIs = "{\"ReportCategory\":3,\"Duration\":2147483647,\"GameSessionId\":666,\"Message\":\"You have been banned. You are probably a little kid and are now whining at your VR headset. If you aren't a little kid, DM me to appeal.\"}";

	public static string PlayersObjective = "{\"deltaXp\":0,\"currentLevel\":1,\"currentXp\":48,\"xpRequiredToLevelUp\":0}";

	public static RoomData.c000060 LastRoom;

	public static List<RoomData.c000061> CommunityRooms;

	private readonly HttpListener listener = new HttpListener();

	public APIServer()
	{
		try
		{
			Console.WriteLine("[APIServer.cs] has started.");
			new Thread(StartListen).Start();
			Program.apiserver = listener;
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
				listener.Prefixes.Add("http://" + Program.GetMyHost() + ":2056/");
			}
			else
			{
				listener.Prefixes.Add("http://localhost:2056/");
			}
			listener.Start();
			while (true)
			{
				Console.WriteLine("[APIServer.cs] is listening.");
				HttpListenerContext context = listener.GetContext();
				HttpListenerRequest request = context.Request;
				HttpListenerResponse response = context.Response;
				string rawUrl = request.RawUrl;
				string text = "";
				byte[] array = null;
				if (rawUrl.StartsWith("/api"))
				{
					text = rawUrl.Substring(5);
				}
				if (!(text == ""))
				{
					Console.WriteLine("API Requested: " + text);
				}
				else
				{
					Console.WriteLine("API Requested (rawUrl): " + rawUrl);
				}
				string text2 = "";
				byte[] array2;
				string @string;
				using (MemoryStream memoryStream = new MemoryStream())
				{
					request.InputStream.CopyTo(memoryStream);
					array2 = memoryStream.ToArray();
					@string = Encoding.ASCII.GetString(array2);
				}
				if (@string.EndsWith('\n'))
				{
					Console.WriteLine("API Data cannot be displayed.");
				}
				else
				{
					Console.WriteLine("API Data: " + @string);
				}
				while (true)
				{
					if (text.StartsWith("version"))
					{
						if (text.Length > 16)
						{
							Program.buildversion = int.Parse(text.Substring(18, 8));
							DetectBuild.DetectVersion(text.Substring(18));
						}
						else
						{
							DetectBuild.DetectVersion("2016/2017");
						}
						text2 = "{\"VersionStatus\":0}";
						break;
					}
					switch (text)
					{
					case "config/v2":
						text2 = Config2.GetDebugConfig();
						break;
					case "platformlogin/v1/getcachedlogins":
						CachedPlayerID = @string.Substring(32).Reverse().Aggregate(0, (int b, char x) => 10 * b + x - 48);
						File.WriteAllText("SaveData/Profile/userid.txt", CachedPlayerID.ToString());
						text2 = getcachedlogins.GetDebugLogin(CachedPlayerID);
						break;
					case "platformlogin/v2/getcachedlogins":
						CachedPlayerID = @string.Substring(32).Reverse().Aggregate(0, (int b, char x) => 10 * b + x - 48);
						File.WriteAllText("SaveData/Profile/userid.txt", CachedPlayerID.ToString());
						text2 = CachedLogin.loginCache(CachedPlayerID);
						break;
					default:
						if (rawUrl.StartsWith("/cachedlogin/forplatformid/"))
						{
							CachedPlayerID = rawUrl.Substring(39).Reverse().Aggregate(0, (int b, char x) => 10 * b + x - 48);
							File.WriteAllText("SaveData/Profile/userid.txt", CachedPlayerID.ToString());
							text2 = CachedLogin2020.loginCache(CachedPlayerID);
							break;
						}
						if (rawUrl.StartsWith("/account/bulk"))
						{
							text2 = CachedLogin20202.loginCache(CachedPlayerID);
							break;
						}
						if (rawUrl == "/connect/token")
						{
							text2 = JsonConvert.SerializeObject(new TokenCached
							{
								access_token = "eyJhbGciOiJSUzI1NiIsImtpZCI6IkREU2F1d2dZdkE1S1NEcVFQWHJRbk1ZeXhMbyIsInR5cCI6ImF0K2p3dCIsIng1dCI6IkREU2F1d2dZdkE1S1NEcVFQWHJRbk1ZeXhMbyJ9.eyJuYmYiOjE2Njk1NzUzOTksImV4cCI6MTY2OTU3ODk5OSwiaXNzIjoiaHR0cHM6Ly9hdXRoLnJlYy5uZXQiLCJjbGllbnRfaWQiOiJyZWNuZXQiLCJyb2xlIjoid2ViQ2xpZW50Iiwic3ViIjoiNjIyNjgwNyIsImF1dGhfdGltZSI6MTY1Nzc3Mzk1NSwiaWRwIjoibG9jYWwiLCJqdGkiOiJEOUUwNTY2QjU2NTE4QkNEMjBBNjRDMkQ2MzUwQzRFMyIsInNpZCI6IjU2NEY5QUFGQzNBRjQxREQwQTQzOENDMTlFODk5NzYzIiwiaWF0IjoxNjY5NTc1Mzk5LCJzY29wZSI6WyJvcGVuaWQiLCJybi5hcGkiLCJybi5jb21tZXJjZSIsInJuLm5vdGlmeSIsInJuLm1hdGNoLnJlYWQiLCJybi5jaGF0Iiwicm4uYWNjb3VudHMiLCJybi5hdXRoIiwicm4ubGluayIsInJuLmNsdWJzIiwicm4ucm9vbXMiLCJybi5kaXNjb3ZlcnkiXSwiYW1yIjpbIm1mYSJdfQ.TVkpz8Nbmz_8fFdbf3xI0CHwjogaIR45TmhK4NXSgx__e85M0xNO8UDSbGJaUMeSN7rn_I1obrzvqqJhDjqOAyQs39rtKJ-lyMq_oFDf1DOjFhB_KWCQ3V_N1SIOpoTnzoD7kr3voixtB4VrTo1HkUQPK_6a2FvUfg3sNwBBAxVvSv7jRPF5_BLGLRACfT3vIHfM7baSOFYkgijnGu9Okd4XKCSolb0hBO14vRMSUZ_gzdm2YubWEF5PK4kiIKMLnnvqUIAXt37sn0m7SjFK_7CI5K7TcSGJcnO-r63PaKsH3UfPqkTq6QWJKUh9X59mQcUJ6iClkY6Pv8LZWjqpkg",
								error = "",
								error_description = "",
								refresh_token = "eyJhbGciOiJSUzI1NiIsImtpZCI6IkREU2F1d2dZdkE1S1NEcVFQWHJRbk1ZeXhMbyIsInR5cCI6ImF0K2p3dCIsIng1dCI6IkREU2F1d2dZdkE1S1NEcVFQWHJRbk1ZeXhMbyJ9.eyJuYmYiOjE2Njk1NzUzOTksImV4cCI6MTY2OTU3ODk5OSwiaXNzIjoiaHR0cHM6Ly9hdXRoLnJlYy5uZXQiLCJjbGllbnRfaWQiOiJyZWNuZXQiLCJyb2xlIjoid2ViQ2xpZW50Iiwic3ViIjoiNjIyNjgwNyIsImF1dGhfdGltZSI6MTY1Nzc3Mzk1NSwiaWRwIjoibG9jYWwiLCJqdGkiOiJEOUUwNTY2QjU2NTE4QkNEMjBBNjRDMkQ2MzUwQzRFMyIsInNpZCI6IjU2NEY5QUFGQzNBRjQxREQwQTQzOENDMTlFODk5NzYzIiwiaWF0IjoxNjY5NTc1Mzk5LCJzY29wZSI6WyJvcGVuaWQiLCJybi5hcGkiLCJybi5jb21tZXJjZSIsInJuLm5vdGlmeSIsInJuLm1hdGNoLnJlYWQiLCJybi5jaGF0Iiwicm4uYWNjb3VudHMiLCJybi5hdXRoIiwicm4ubGluayIsInJuLmNsdWJzIiwicm4ucm9vbXMiLCJybi5kaXNjb3ZlcnkiXSwiYW1yIjpbIm1mYSJdfQ.TVkpz8Nbmz_8fFdbf3xI0CHwjogaIR45TmhK4NXSgx__e85M0xNO8UDSbGJaUMeSN7rn_I1obrzvqqJhDjqOAyQs39rtKJ-lyMq_oFDf1DOjFhB_KWCQ3V_N1SIOpoTnzoD7kr3voixtB4VrTo1HkUQPK_6a2FvUfg3sNwBBAxVvSv7jRPF5_BLGLRACfT3vIHfM7baSOFYkgijnGu9Okd4XKCSolb0hBO14vRMSUZ_gzdm2YubWEF5PK4kiIKMLnnvqUIAXt37sn0m7SjFK_7CI5K7TcSGJcnO-r63PaKsH3UfPqkTq6QWJKUh9X59mQcUJ6iClkY6Pv8LZWjqpkg"
							});
							break;
						}
						if (rawUrl == "/account/me")
						{
							text2 = JsonConvert.SerializeObject(JsonConvert.DeserializeObject<List<CachedLogin20202>>(CachedLogin20202.loginCache(CachedPlayerID))[0]);
							break;
						}
						switch (text)
						{
						case "platformlogin/v1/loginaccount":
						case "platformlogin/v1/createaccount":
						case "platformlogin/v1/logincached":
						case "platformlogin/v2/logincached":
						case "platformlogin/v3/logincached":
							text2 = logincached.loginCache(CachedPlayerID);
							break;
						default:
						{
							if (text.StartsWith("players"))
							{
								switch (text)
								{
								case "players/v1/phonelastfour":
									text2 = "{\"PhoneNumber\":\"RebornRec\"}";
									break;
								case "players/v1/bio":
									text2 = ((new Random().Next(1, 33) != 9) ? "{\"Success\":false,\"Message\":\"Setting bio is not supported.\"}" : "{\"Success\":false,\"Message\":\"Setting bio is not supported :3\"}");
									break;
								case "players/v2/displayname":
									text2 = ((new Random().Next(1, 33) != 9) ? "{\"Success\":false,\"Message\":\"Setting display name is not supported.\"}" : "{\"Success\":false,\"Message\":\"Setting display name is not supported :3\"}");
									break;
								case "players/v2/phone":
									text2 = ((new Random().Next(1, 33) != 9) ? "{\"Success\":false,\"Message\":\"Phone numbers are not supported.\"}" : "{\"Success\":false,\"Message\":\"Phone numbers are not supported :3\"}");
									break;
								case "players/v1/disallowInAppPurchases":
									text2 = "true";
									break;
								default:
									if (text.StartsWith("players/v1/pro"))
									{
										text2 = JsonConvert.SerializeObject(new Progression
										{
											PlayerId = CachedPlayerID,
											Level = int.Parse(File.ReadAllText("SaveData/Profile/level.txt")),
											XP = 48
										});
									}
									else
									{
										if (text.Contains("?p"))
										{
											goto IL_04ef;
										}
										text2 = BracketResponse;
									}
									break;
								}
								break;
							}
							if (text == "config/v1/amplitude")
							{
								text2 = Amplitude.amplitude();
								break;
							}
							if (text == "images/v2/named")
							{
								text2 = Images.Named();
								break;
							}
							if (rawUrl.Contains("images/v4/uploadsaved"))
							{
								text2 = Images.SaveImage(array2, flag: false);
								break;
							}
							List<AvatarItem2020>? list3;
							List<AvatarItem2020> list4;
							switch (text)
							{
							case "images/v3/profile":
								Images.SaveImage(array2, flag: true);
								break;
							case "PlayerReporting/v1/moderationBlockDetails":
								text2 = ModerationBlockDetails;
								if (Program.flag)
								{
									text2 = ModerationBlockDetaiIs;
								}
								break;
							case "PlayerReporting/v1/hile":
								text2 = "false";
								break;
							case "messages/v2/get":
								text2 = BracketResponse;
								break;
							case "relationships/v2/get":
								text2 = BracketResponse;
								break;
							case "gameconfigs/v1/all":
								text2 = File.ReadAllText("SaveData/gameconfigs.txt");
								break;
							case "avatar/v2":
								text2 = File.ReadAllText("SaveData/avatar.txt");
								break;
							case "avatar/v3/saved":
								text2 = Outfits.m000009();
								break;
							case "avatar/v2/set":
								File.WriteAllText("SaveData/avatar.txt", @string);
								break;
							case "avatar/v2/gifts/generate":
								text2 = GiftGenerate;
								break;
							case "avatar/v3/saved/set":
								Outfits.m00003f(@string);
								break;
							case "settings/v2/":
								text2 = File.ReadAllText("SaveData/settings.txt");
								break;
							case "settings/v2/set":
								Settings.SetPlayerSetting(@string);
								break;
							default:
								{
									if (!(rawUrl == "//api/chat/v2/myChats?mode=0&count=50"))
									{
										switch (text)
										{
										case "chat/v2/myChats?mode=0&count=50":
											break;
										case "quickPlay/v1/getandclear":
											goto IL_06f7;
										case "playersubscriptions/v1/my":
											goto IL_0710;
										case "avatar/v3/items":
											goto IL_0729;
										case "avatar/v4/items":
											goto IL_0747;
										case "equipment/v1/getUnlocked":
											goto IL_07be;
										case "equipment/v2/getUnlocked":
											goto IL_07dd;
										case "equipment/v1/update":
											goto IL_0806;
										case "consumables/v1/getUnlocked":
											goto IL_081f;
										case "consumables/v1/updateActive":
											goto IL_083d;
										case "avatar/v2/gifts":
											goto IL_0857;
										case "inventions/v1/mine":
											goto IL_0870;
										default:
											goto IL_0881;
										}
									}
									text2 = BracketResponse;
									break;
								}
								IL_0881:
								if (text.StartsWith("inventions/v1?"))
								{
									foreach (KeyValuePair<string, Inventions.InventionResponse> item in Inventions.m00003a())
									{
										if (item.Value.Invention.InventionId == int.Parse(text.Substring(26)))
										{
											text2 = JsonConvert.SerializeObject(item.Value.Invention);
											break;
										}
									}
									break;
								}
								if (text.StartsWith("inventions/v1/delete"))
								{
									foreach (KeyValuePair<string, Inventions.InventionResponse> item2 in Inventions.m00003a())
									{
										if (item2.Value.Invention.InventionId == int.Parse(text.Substring(33)))
										{
											Directory.Delete("SaveData/Inventions/" + item2.Key, recursive: true);
											text2 = JsonConvert.SerializeObject(item2.Value);
											break;
										}
									}
									break;
								}
								if (text.StartsWith("inventions/v1/update"))
								{
									foreach (KeyValuePair<string, Inventions.InventionResponse> item3 in Inventions.m00003a())
									{
										if (item3.Value.Invention.InventionId == int.Parse(text.Substring(33).Substring(text.IndexOf('&') - 33)))
										{
											if (text.Contains("&name"))
											{
												item3.Value.Invention.Name = text.Substring(text.IndexOf("&name=") + 6);
												Directory.CreateDirectory("SaveData/Inventions/" + item3.Value.Invention.Name);
												File.Move("SaveData/Inventions/" + item3.Key + "/InventionDetails.json", "SaveData/Inventions/" + item3.Value.Invention.Name + "/InventionDetails.json");
												File.Move("SaveData/Inventions/" + item3.Key + "/" + item3.Value.InventionVersion.BlobName, "SaveData/Inventions/" + item3.Value.Invention.Name + "/" + item3.Value.InventionVersion.BlobName);
												Directory.Delete("SaveData/Inventions/" + item3.Key, recursive: true);
											}
											else if (text.Contains("&description"))
											{
												item3.Value.Invention.Description = text.Substring(text.IndexOf("&description=") + 13);
											}
											else if (text.Contains("&imgName"))
											{
												item3.Value.Invention.ImageName = text.Substring(text.IndexOf("&imgName=") + 9);
											}
											string text3 = JsonConvert.SerializeObject(item3.Value);
											File.WriteAllText("SaveData/Inventions/" + item3.Value.Invention.Name + "/InventionDetails.json", text3);
											text2 = text3;
											break;
										}
									}
									break;
								}
								if (text.StartsWith("inventions/v1/version"))
								{
									foreach (KeyValuePair<string, Inventions.InventionResponse> item4 in Inventions.m00003a())
									{
										if (item4.Value.Invention.InventionId == int.Parse(text.Substring(34, text.IndexOf('&') - 34)))
										{
											text2 = JsonConvert.SerializeObject(item4.Value.InventionVersion);
											break;
										}
									}
									break;
								}
								switch (text)
								{
								case "inventions/v1/save":
								{
									Inventions.InventionRequest inventionRequest = JsonConvert.DeserializeObject<Inventions.InventionRequest>(@string.Substring(@string.IndexOf("{\""), @string.LastIndexOf('}') - @string.IndexOf("{\"") + 1));
									string text11 = "SaveData/Inventions/" + inventionRequest.name;
									string text12 = Guid.NewGuid().ToString("N");
									Inventions.Invention invention = new Inventions.Invention
									{
										InventionId = new Random().Next(100, 9999999),
										CreatorPlayerId = CachedPlayerID,
										Name = inventionRequest.name,
										Description = inventionRequest.description,
										ImageName = inventionRequest.imageName,
										CurrentVersionNumber = 1,
										IsPublished = false,
										ModifiedAt = DateTime.UtcNow
									};
									Inventions.InventionVersion inventionVersion = new Inventions.InventionVersion
									{
										InventionId = invention.InventionId,
										VersionNumber = invention.CurrentVersionNumber,
										InstantiationCost = inventionRequest.instantiationCost,
										BlobName = text12
									};
									if (!Directory.Exists(text11))
									{
										Directory.CreateDirectory(text11);
										File.WriteAllBytes(string.Concat(new string[3] { text11, "/", text12 }), PartParser.ParseData(array2, "data.dat"));
										string text13 = JsonConvert.SerializeObject(new Inventions.InventionResponse
										{
											Status = 0,
											Invention = invention,
											InventionVersion = inventionVersion
										});
										File.WriteAllText(text11 + "/InventionDetails.json", text13);
										text2 = text13;
									}
									else
									{
										text2 = JsonConvert.SerializeObject(new Inventions.InventionResponse
										{
											Status = 3,
											Invention = invention,
											InventionVersion = inventionVersion
										});
									}
									break;
								}
								case "avatar/v2/gifts/generate":
									text2 = GiftGenerate;
									break;
								case "objectives/v1/myprogress":
									text2 = JsonConvert.SerializeObject(new Objective2018());
									break;
								case "rooms/v2/myrooms":
									text2 = JsonConvert.SerializeObject(c000099.m000055());
									break;
								case "rooms/v2/baserooms":
									text2 = JsonConvert.SerializeObject(JsonConvert.DeserializeObject<List<RoomData.c000061>>(File.ReadAllText("SaveData/baserooms.txt")));
									break;
								case "rooms/v2/mybookmarkedrooms":
								{
									List<RoomData.c000061> list2 = new List<RoomData.c000061>();
									foreach (JToken item5 in JArray.Parse(File.ReadAllText("SaveData/bookmarks.txt")))
									{
										int p = (int)item5;
										list2.Add(RoomData.m000023(p).Room);
									}
									text2 = JsonConvert.SerializeObject(list2);
									break;
								}
								default:
									if (text.StartsWith("rooms/v2/search"))
									{
										List<RoomData.c000061> list = new List<RoomData.c000061>();
										string text4 = text.Substring(22).ToLower();
										if (text4.StartsWith("%23"))
										{
											text4 = text4.Substring(3);
											foreach (KeyValuePair<string, RoomData.c000060> item6 in RoomData.f000050)
											{
												foreach (RoomData.c000063 tag in item6.Value.Tags)
												{
													if (tag.Tag == text4)
													{
														list.Add(item6.Value.Room);
													}
												}
											}
										}
										else
										{
											foreach (KeyValuePair<string, RoomData.c000060> item7 in RoomData.f000050)
											{
												if (item7.Key.Contains(text4))
												{
													list.Add(item7.Value.Room);
												}
											}
											foreach (RoomData.c000061 communityRoom in CommunityRooms)
											{
												if (communityRoom.Name.Contains(text4))
												{
													list.Add(communityRoom);
												}
											}
										}
										text2 = JsonConvert.SerializeObject(list);
										break;
									}
									if (text == "rooms/v2/mySubscriptions?skip=0&take=40")
									{
										text2 = BracketResponse;
										break;
									}
									if (text.StartsWith("groups/v1/member"))
									{
										text2 = BracketResponse;
										break;
									}
									switch (text)
									{
									case "events/v3/list":
										text2 = Events.list();
										break;
									case "playerevents/v1/all":
										text2 = PlayerEventsResponse;
										break;
									case "rooms/v1/filters":
										text2 = "{\"PinnedFilters\":[\"recroomoriginal\",\"community\"],\"PopularFilters\":[\"uwu\",\"uwu\",\"uwu\",\"uwu\",\"uwu\",\"uwu\",\"goat\",\"uwu\",\"uwu\",\"uwu\"]}";
										break;
									case "rooms/v1/report":
										text2 = ((new Random().Next(1, 33) != 9) ? "{\"Success\":false,\"Message\":\"Nuh uh\"}" : "{\"Success\":false,\"Message\":\"Nuh uh :3\"}");
										break;
									case "activities/charades/v1/words":
										text2 = Activities.Charades.Words();
										break;
									case "gamesessions/v4/joinroom":
										text2 = JsonConvert.SerializeObject(c000041.m000030(@string));
										HeartbeatEvents.OnRoomChangeEvent();
										break;
									default:
										{
											if (rawUrl.StartsWith("/goto/room"))
											{
												string text5 = rawUrl.Substring(11);
												string subroom = "";
												bool @private = false;
												if (text5.Contains('/'))
												{
													subroom = text5.Substring(text5.IndexOf('/'));
													text5 = text5.Replace(subroom, "");
													subroom = subroom.Substring(1);
												}
												if (@string.StartsWith('C'))
												{
													@private = true;
												}
												text2 = JsonConvert.SerializeObject(RebornMatch.GotoRoom(text5, subroom, @private));
												HeartbeatEvents.OnMatchChangeEvent();
												break;
											}
											if (rawUrl == "/player/heartbeat")
											{
												text2 = JsonConvert.SerializeObject(c000020.m000028());
												break;
											}
											if (!(rawUrl == "//api/sanitize/v1/isPure"))
											{
												switch (text)
												{
												case "sanitize/v1/isPure":
													break;
												case "testcasemanagement/v1/testpasssummary":
													goto IL_11fb;
												case "PlayerCheer/v1/SetSelectedCheer":
													goto IL_1214;
												default:
													goto IL_122c;
												}
											}
											text2 = "{\"IsPure\":true}";
											break;
										}
										IL_122c:
										if (text.StartsWith("playerRep"))
										{
											text2 = JsonConvert.SerializeObject(new Reputation
											{
												AccountId = CachedPlayerID,
												Noteriety = 0,
												CheerGeneral = 1,
												CheerHelpful = 1,
												CheerGreatHost = 1,
												CheerSportsman = 1,
												CheerCreative = 1,
												CheerCredit = 77,
												SubscriberCount = 2,
												SubscribedCount = 0,
												SelectedCheer = int.Parse(File.ReadAllText("SaveData/Profile/cheer.txt"))
											});
											break;
										}
										switch (text)
										{
										case "checklist/v1/current":
											text2 = ChecklistCurrent;
											break;
										case "challenge/v1/getCurrent":
										case "challenge/v2/getCurrent":
											text2 = ChallengeGetCurrent;
											break;
										case "rooms/v1/clone":
											text2 = JsonConvert.SerializeObject(c000099.m00000a(@string));
											break;
										case "rooms/v2/modify":
										{
											RoomData.c000061 c69 = JsonConvert.DeserializeObject<RoomData.c000061>(@string);
											RoomData.c000060 c70 = RoomData.m000023((int)c69.RoomId);
											if (c69.Description != null)
											{
												c70.Room.Description = c69.Description;
											}
											if (c69.ImageName != null)
											{
												c70.Room.ImageName = c69.ImageName;
											}
											File.WriteAllText("SaveData/Rooms/" + c70.Room.Name + "/RoomDetails.json", JsonConvert.SerializeObject(c70));
											text2 = JsonConvert.SerializeObject(new c000099.c00009b
											{
												Result = 0,
												RoomDetails = c70
											});
											break;
										}
										default:
										{
											int result;
											if (text.StartsWith("rooms/v2/save") || text.StartsWith("rooms/v3/save"))
											{
												string name = c000041.f000043.Room.Name;
												string text6 = "SaveData/Rooms/" + name + "/room/";
												string text7 = Guid.NewGuid().ToString("N");
												if (!Directory.Exists(text6))
												{
													Directory.CreateDirectory(text6);
												}
												else
												{
													File.Delete(Directory.GetFiles(text6)[0]);
												}
												File.WriteAllBytes(string.Concat(new string[2] { text6, text7 }), PartParser.ParseData(array2, "data.dat"));
												c000041.f000043.Scenes[0].DataBlobName = text7;
												c000041.f000043.Scenes[0].DataModifiedAt = DateTime.UtcNow;
												File.WriteAllText("SaveData/Rooms/" + name + "/RoomDetails.json", JsonConvert.SerializeObject(c000041.f000043));
												text2 = JsonConvert.SerializeObject(c000041.f000043.Scenes[0]);
											}
											else if (text.StartsWith("rooms/v1/datahistory"))
											{
												text2 = BracketResponse;
											}
											else if (rawUrl.StartsWith("//api/datablob"))
											{
												string name2 = c000041.f000043.Room.Name;
												string text8 = Guid.NewGuid().ToString("N");
												if (Directory.Exists("SaveData/Rooms/" + name2))
												{
													string text9 = "SaveData/Rooms/" + name2 + "/data/";
													Directory.CreateDirectory(text9);
													File.WriteAllBytes(text9 + text8, PartParser.ParseData(array2, "data.dat"));
													text2 = JsonConvert.SerializeObject(new c00007r.c00007g(text8));
												}
												else
												{
													File.WriteAllBytes("SaveData/Rooms/" + text8 + "looseblob", PartParser.ParseData(array2, "data.dat"));
												}
											}
											else if (rawUrl.Contains("uploadtransient"))
											{
												text2 = Images.SaveImage(array2, flag: false);
											}
											else if (text.StartsWith("presence/v3/heartbeat"))
											{
												if (Program.version == 0)
												{
													if (@string == "")
													{
														DetectBuild.DetectVersion("20190128");
													}
													else
													{
														DetectBuild.DetectVersion("20181012");
													}
												}
												text2 = JsonConvert.SerializeObject(Notification2018.Reponse.createResponse(4, c000020.m000027()));
											}
											else if (text.StartsWith("rooms/v1/hot"))
											{
												if (text.Contains("community"))
												{
													text2 = new WebClient().DownloadString("https://raw.githubusercontent.com/aqquad/RebornRec/main/communityrooms.txt");
													CommunityRooms = JsonConvert.DeserializeObject<List<RoomData.c000061>>(text2);
													text2 = JsonConvert.SerializeObject(CommunityRooms);
													if (text.Contains("rec"))
													{
														string text10 = JsonConvert.SerializeObject(JsonConvert.DeserializeObject<List<RoomData.c000061>>(new WebClient().DownloadString("https://raw.githubusercontent.com/aqquad/RebornRec/main/hotrooms.txt")));
														text2 = string.Concat(text10.AsSpan(0, text10.Length - 1), ",", text2.AsSpan(1));
													}
												}
												else
												{
													text2 = JsonConvert.SerializeObject(JsonConvert.DeserializeObject<List<RoomData.c000061>>(new WebClient().DownloadString("https://raw.githubusercontent.com/aqquad/RebornRec/main/hotrooms.txt")));
												}
											}
											else if (text == "rooms/v1/bookmark")
											{
												RoomData.c000065 c000065 = JsonConvert.DeserializeObject<RoomData.c000065>(@string);
												JArray jArray = JArray.Parse(File.ReadAllText("SaveData/bookmarks.txt"));
												if (c000065.Bookmark)
												{
													jArray.AddFirst(c000065.RoomId);
												}
												else
												{
													jArray.Remove(jArray.Where((JToken x) => x.Value<int>() == c000065.RoomId).FirstOrDefault());
												}
												File.WriteAllText("SaveData/bookmarks.txt", JsonConvert.SerializeObject(jArray));
												text2 = SuccessMessage;
											}
											else if (text == "rooms/v1/cheer")
											{
												text2 = ((new Random().Next(1, 33) != 9) ? "{\"Success\":false,\"Message\":\"Cheers are not supported.\"}" : "{\"Success\":false,\"Message\":\"Cheers are not supported :3\"}");
											}
											else if (text.StartsWith("rooms/v2/personal"))
											{
												RoomData.c000064 c66 = new RoomData.c000064();
												int num = int.Parse(text.Substring(25));
												foreach (JToken item8 in JArray.Parse(File.ReadAllText("SaveData/bookmarks.txt")))
												{
													if ((int)item8 == num)
													{
														c66.IsBookmarked = true;
														break;
													}
												}
												text2 = JsonConvert.SerializeObject(c66);
											}
											else if (text.StartsWith("rooms/v4/details"))
											{
												RoomData.c000060 c67 = RoomData.m000023(int.Parse(text.Substring(17)));
												text2 = JsonConvert.SerializeObject(c67);
												LastRoom = c67;
											}
											else if (text.StartsWith("rooms/v2/name"))
											{
												RoomData.c000061 c68 = RoomData.m000024(text.Substring(14));
												if (c68 != null)
												{
													text2 = JsonConvert.SerializeObject(c68);
												}
											}
											else if (text.StartsWith("rooms/v2") && int.TryParse(text.AsSpan(9), out result))
											{
												foreach (RoomData.c000061 communityRoom2 in CommunityRooms)
												{
													if (communityRoom2.RoomId == ulong.Parse(text.Substring(9)))
													{
														text2 = JsonConvert.SerializeObject(communityRoom2);
														break;
													}
												}
											}
											else if (text == "images/v1/slideshow")
											{
												text2 = new WebClient().DownloadString("https://raw.githubusercontent.com/aqquad/RebornRec/main/rcslideshow.txt");
											}
											break;
										}
										}
										break;
										IL_1214:
										File.WriteAllText("SaveData/Profile/cheer.txt", @string.Substring(14));
										break;
										IL_11fb:
										text2 = BracketResponse;
										break;
									}
									break;
								}
								break;
								IL_0870:
								text2 = JsonConvert.SerializeObject(Inventions.m000055());
								break;
								IL_0857:
								text2 = BracketResponse;
								break;
								IL_083d:
								Consumables.SetPlayerConsumables(@string, type: false);
								break;
								IL_081f:
								text2 = File.ReadAllText("SaveData/consumables.txt");
								break;
								IL_0806:
								Equipment.SetPlayerEquipment(@string);
								break;
								IL_07dd:
								text2 = JsonConvert.SerializeObject(JsonConvert.DeserializeObject<List<Equipment2020>>(JsonConvert.SerializeObject(Equipment.LoadEquipment(skip: false))));
								break;
								IL_07be:
								text2 = JsonConvert.SerializeObject(Equipment.LoadEquipment(skip: false));
								break;
								IL_0747:
								list3 = JsonConvert.DeserializeObject<List<AvatarItem2020>>(File.ReadAllText("SaveData/avataritems.txt"));
								list4 = list3.ToList();
								foreach (AvatarItem2020 item9 in list3)
								{
									if (item9.AvatarItemDesc.Length > 59)
									{
										list4.Remove(item9);
									}
								}
								text2 = JsonConvert.SerializeObject(list4);
								break;
								IL_0729:
								text2 = File.ReadAllText("SaveData/avataritems.txt");
								break;
								IL_0710:
								text2 = BracketResponse;
								break;
								IL_06f7:
								text2 = "{}";
								break;
							}
							break;
						}
						}
						break;
					}
					break;
					IL_04ef:
					DetectBuild.DetectVersion("2016/2017");
				}
				Console.WriteLine("API Response: " + text2);
				if (array == null)
				{
					array = Encoding.UTF8.GetBytes(text2);
				}
				response.ContentLength64 = array.Length;
				response.OutputStream.Write(array, 0, array.Length);
				response.OutputStream.Flush();
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex);
			File.WriteAllText("APIServerError.txt", ex.ToString());
			listener.Close();
			new APIServer();
		}
	}
}

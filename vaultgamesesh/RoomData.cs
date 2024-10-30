using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using server;

namespace vaultgamesesh;

internal sealed class RoomData
{
	public sealed class c00005f
	{
		private long f00002c;

		private ulong f000023;

		private string f000003;

		private string f000035;

		private bool f000073;

		private string f00000e;

		private int f000007;

		private bool f000017;

		private DateTime f000074;

		public long RoomSceneId
		{
			get
			{
				return f00002c;
			}
			set
			{
				f00002c = value;
			}
		}

		public ulong RoomId
		{
			get
			{
				return f000023;
			}
			set
			{
				f000023 = value;
			}
		}

		public string RoomSceneLocationId
		{
			get
			{
				return f000003;
			}
			set
			{
				f000003 = value;
			}
		}

		public string Name
		{
			get
			{
				return f000035;
			}
			set
			{
				f000035 = value;
			}
		}

		public bool IsSandbox
		{
			get
			{
				return f000073;
			}
			set
			{
				f000073 = value;
			}
		}

		public string DataBlobName
		{
			get
			{
				return f00000e;
			}
			set
			{
				f00000e = value;
			}
		}

		public int MaxPlayers
		{
			get
			{
				return f000007;
			}
			set
			{
				f000007 = value;
			}
		}

		public bool CanMatchmakeInto
		{
			get
			{
				return f000017;
			}
			set
			{
				f000017 = value;
			}
		}

		public DateTime DataModifiedAt
		{
			get
			{
				return f000074;
			}
			set
			{
				f000074 = value;
			}
		}
	}

	public sealed class c000060
	{
		private c000061 f00002d;

		private List<c00005f> f000031;

		private List<int> f000034;

		private int f000005;

		private int f000006;

		private int f000007;

		private List<c000063> f000075;

		public c000061 Room
		{
			get
			{
				return f00002d;
			}
			set
			{
				f00002d = value;
			}
		}

		public List<c00005f> Scenes
		{
			get
			{
				return f000031;
			}
			set
			{
				f000031 = value;
			}
		}

		public List<int> CoOwners
		{
			get
			{
				return f000034;
			}
			set
			{
				f000034 = value;
			}
		}

		public List<int> InvitedCoOwners
		{
			get
			{
				return f000034;
			}
			set
			{
				f000034 = value;
			}
		}

		public List<int> Moderators
		{
			get
			{
				return f000034;
			}
			set
			{
				f000034 = value;
			}
		}

		public List<int> InvitedModerators
		{
			get
			{
				return f000034;
			}
			set
			{
				f000034 = value;
			}
		}

		public List<int> Hosts
		{
			get
			{
				return f000034;
			}
			set
			{
				f000034 = value;
			}
		}

		public List<int> InvitedHosts
		{
			get
			{
				return f000034;
			}
			set
			{
				f000034 = value;
			}
		}

		public int CheerCount
		{
			get
			{
				return f000005;
			}
			set
			{
				f000005 = value;
			}
		}

		public int FavoriteCount
		{
			get
			{
				return f000006;
			}
			set
			{
				f000006 = value;
			}
		}

		public int VisitCount
		{
			get
			{
				return f000007;
			}
			set
			{
				f000007 = value;
			}
		}

		public List<c000063> Tags
		{
			get
			{
				return f000075;
			}
			set
			{
				f000075 = value;
			}
		}
	}

	public sealed class c000061
	{
		private ulong f000001;

		private string f000002;

		private string f000003;

		private int f000076;

		private string f000036;

		private int f000006;

		private int f000007;

		private bool f000017;

		private bool f000077;

		private bool f000018;

		private bool f000019;

		private bool f00001a;

		private bool f00001b;

		public ulong RoomId
		{
			get
			{
				return f000001;
			}
			set
			{
				f000001 = value;
			}
		}

		public string Name
		{
			get
			{
				return f000002;
			}
			set
			{
				f000002 = value;
			}
		}

		public string Description
		{
			get
			{
				return f000003;
			}
			set
			{
				f000003 = value;
			}
		}

		public int CreatorPlayerId
		{
			get
			{
				return f000076;
			}
			set
			{
				f000076 = value;
			}
		}

		public string ImageName
		{
			get
			{
				return f000036;
			}
			set
			{
				f000036 = value;
			}
		}

		public int State
		{
			get
			{
				return f000006;
			}
			set
			{
				f000006 = value;
			}
		}

		public int Accessibility
		{
			get
			{
				return f000007;
			}
			set
			{
				f000007 = value;
			}
		}

		public bool SupportsLevelVoting
		{
			get
			{
				return f000017;
			}
			set
			{
				f000017 = value;
			}
		}

		public bool IsAGRoom
		{
			get
			{
				return f000077;
			}
			set
			{
				f000077 = value;
			}
		}

		public bool IsDormRoom => f000002 == "DormRoom";

		public bool CloningAllowed
		{
			get
			{
				return f000018;
			}
			set
			{
				f000018 = value;
			}
		}

		public bool SupportsScreens
		{
			get
			{
				return f000019;
			}
			set
			{
				f000019 = value;
			}
		}

		public bool SupportsWalkVR
		{
			get
			{
				return f00001a;
			}
			set
			{
				f00001a = value;
			}
		}

		public bool SupportsTeleportVR
		{
			get
			{
				return f00001b;
			}
			set
			{
				f00001b = value;
			}
		}

		public bool AllowsJuniors => true;

		public int RoomWarningMask => 0;

		public string CustomRoomWarning => "";

		public bool DisableMicAutoMute => true;
	}

	public sealed class c000062
	{
		private string f00000a;

		private long f00002e;

		private string f000003;

		public string RoomName
		{
			get
			{
				return f00000a;
			}
			set
			{
				f00000a = value;
			}
		}

		public long RoomId
		{
			get
			{
				return f00002e;
			}
			set
			{
				f00002e = value;
			}
		}

		public string ImageName
		{
			get
			{
				return f000003;
			}
			set
			{
				f000003 = value;
			}
		}
	}

	public sealed class c000063
	{
		private string f00000a;

		private int f00000b;

		public string Tag
		{
			get
			{
				return f00000a;
			}
			set
			{
				f00000a = value;
			}
		}

		public int Type
		{
			get
			{
				return f00000b;
			}
			set
			{
				f00000b = value;
			}
		}
	}

	public sealed class c000064
	{
		private bool f00000a;

		private bool f00000b;

		public bool IsCheering
		{
			get
			{
				return f00000a;
			}
			set
			{
				f00000a = value;
			}
		}

		public bool IsBookmarked
		{
			get
			{
				return f00000b;
			}
			set
			{
				f00000b = value;
			}
		}
	}

	public sealed class c000065
	{
		private long f00000d;

		private bool f00000c;

		public long RoomId
		{
			get
			{
				return f00000d;
			}
			set
			{
				f00000d = value;
			}
		}

		public bool Bookmark
		{
			get
			{
				return f00000c;
			}
			set
			{
				f00000c = value;
			}
		}
	}

	public static Dictionary<string, c000060> f000024 = new Dictionary<string, c000060>
	{
		{
			"MakerRoom",
			new c000060
			{
				Room = new c000061
				{
					RoomId = 24uL,
					Name = "MakerRoom",
					Description = "This room is a blank canvas. Make it into whatever you like!",
					CreatorPlayerId = 0,
					ImageName = "TE4HqcYfvEyd30tWPteUYQ",
					State = 0,
					Accessibility = 1,
					SupportsLevelVoting = false,
					IsAGRoom = false,
					CloningAllowed = false,
					SupportsScreens = true,
					SupportsTeleportVR = true,
					SupportsWalkVR = true
				},
				Scenes = new List<c00005f>
				{
					new c00005f
					{
						RoomSceneId = 1L,
						RoomId = 24uL,
						RoomSceneLocationId = "a75f7547-79eb-47c6-8986-6767abcb4f92",
						Name = "Home",
						IsSandbox = true,
						DataBlobName = string.Empty,
						MaxPlayers = 20,
						CanMatchmakeInto = true,
						DataModifiedAt = DateTime.UtcNow
					}
				},
				CoOwners = new List<int>(),
				Hosts = new List<int>(),
				CheerCount = 1,
				FavoriteCount = 1,
				VisitCount = 1,
				Tags = new List<c000063>
				{
					new c000063
					{
						Tag = "community",
						Type = 1
					}
				}
			}
		},
		{
			"Park",
			new c000060
			{
				Room = new c000061
				{
					RoomId = 25uL,
					Name = "Park",
					Description = "A sprawling park with amphitheater, play fields, and a Ass.",
					CreatorPlayerId = 0,
					ImageName = "79ee7af2532247f397867e48daa9d264.png",
					State = 0,
					Accessibility = 1,
					SupportsLevelVoting = false,
					IsAGRoom = false,
					CloningAllowed = false,
					SupportsScreens = true,
					SupportsTeleportVR = true,
					SupportsWalkVR = true
				},
				Scenes = new List<c00005f>
				{
					new c00005f
					{
						RoomSceneId = 1L,
						RoomId = 25uL,
						RoomSceneLocationId = "0a864c86-5a71-4e18-8041-8124e4dc9d98",
						Name = "Home",
						IsSandbox = true,
						DataBlobName = string.Empty,
						MaxPlayers = 20,
						CanMatchmakeInto = true,
						DataModifiedAt = DateTime.UtcNow
					}
				},
				CoOwners = new List<int>(),
				Hosts = new List<int>(),
				CheerCount = 1,
				FavoriteCount = 1,
				VisitCount = 1,
				Tags = new List<c000063>
				{
					new c000063
					{
						Tag = "community",
						Type = 1
					}
				}
			}
		},
		{
			"Lounge",
			new c000060
			{
				Room = new c000061
				{
					RoomId = 22uL,
					Name = "Lounge",
					Description = "A low-key lounge to chill with your friends. Great for private parties!",
					CreatorPlayerId = 0,
					ImageName = "3e8c2458f1e542ab8aa275e4083ee47a",
					State = 0,
					Accessibility = 1,
					SupportsLevelVoting = false,
					IsAGRoom = false,
					CloningAllowed = false,
					SupportsScreens = true,
					SupportsTeleportVR = true,
					SupportsWalkVR = true
				},
				Scenes = new List<c00005f>
				{
					new c00005f
					{
						RoomSceneId = 1L,
						RoomId = 22uL,
						RoomSceneLocationId = "a067557f-ca32-43e6-b6e5-daaec60b4f5a",
						Name = "Home",
						IsSandbox = true,
						DataBlobName = string.Empty,
						MaxPlayers = 20,
						CanMatchmakeInto = true,
						DataModifiedAt = DateTime.UtcNow
					}
				},
				CoOwners = new List<int>(),
				Hosts = new List<int>(),
				CheerCount = 1,
				FavoriteCount = 1,
				VisitCount = 1,
				Tags = new List<c000063>
				{
					new c000063
					{
						Tag = "community",
						Type = 1
					}
				}
			}
		},
		{
			"PerformanceHall",
			new c000060
			{
				Room = new c000061
				{
					RoomId = 23uL,
					Name = "PerformanceHall",
					Description = "A theater for plays, music, comedy and other performances.",
					CreatorPlayerId = 0,
					ImageName = "57c0a08d2d074cd0ad499bb74cae197f.png",
					State = 0,
					Accessibility = 1,
					SupportsLevelVoting = false,
					IsAGRoom = false,
					CloningAllowed = false,
					SupportsScreens = true,
					SupportsTeleportVR = true,
					SupportsWalkVR = true
				},
				Scenes = new List<c00005f>
				{
					new c00005f
					{
						RoomSceneId = 1L,
						RoomId = 23uL,
						RoomSceneLocationId = "9932f88f-3929-43a0-a012-a40b5128e346",
						Name = "Home",
						IsSandbox = true,
						DataBlobName = string.Empty,
						MaxPlayers = 20,
						CanMatchmakeInto = true,
						DataModifiedAt = DateTime.UtcNow
					}
				},
				CoOwners = new List<int>(),
				Hosts = new List<int>(),
				CheerCount = 1,
				FavoriteCount = 1,
				VisitCount = 1,
				Tags = new List<c000063>
				{
					new c000063
					{
						Tag = "community",
						Type = 1
					}
				}
			}
		},
		{
			"Hangar",
			new c000060
			{
				Room = new c000061
				{
					RoomId = 18uL,
					Name = "Hangar",
					Description = "Teams battle each other and waves of robots. make mainframes yourself",
					CreatorPlayerId = 0,
					ImageName = "c5a72193d6904811b2d0195a6deb3125",
					State = 0,
					Accessibility = 1,
					SupportsLevelVoting = false,
					IsAGRoom = false,
					CloningAllowed = false,
					SupportsScreens = true,
					SupportsTeleportVR = true,
					SupportsWalkVR = true
				},
				Scenes = new List<c00005f>
				{
					new c00005f
					{
						RoomSceneId = 1L,
						RoomId = 18uL,
						RoomSceneLocationId = "239e676c-f12f-489f-bf3a-d4c383d692c3",
						Name = "Hangar",
						IsSandbox = false,
						DataBlobName = string.Empty,
						MaxPlayers = 20,
						CanMatchmakeInto = true,
						DataModifiedAt = DateTime.UtcNow
					}
				},
				CoOwners = new List<int>(),
				Hosts = new List<int>(),
				CheerCount = 1,
				FavoriteCount = 1,
				VisitCount = 1,
				Tags = new List<c000063>
				{
					new c000063
					{
						Tag = "community",
						Type = 1
					}
				}
			}
		},
		{
			"Lake",
			new c000060
			{
				Room = new c000061
				{
					RoomId = 4uL,
					Name = "Lake",
					Description = "A leisurely trail to the lake and beyond.",
					CreatorPlayerId = 0,
					ImageName = "52cf6c3271894ecd95fb0c9b2d2209a7",
					State = 0,
					Accessibility = 1,
					SupportsLevelVoting = false,
					IsAGRoom = false,
					CloningAllowed = false,
					SupportsScreens = true,
					SupportsTeleportVR = true,
					SupportsWalkVR = true
				},
				Scenes = new List<c00005f>
				{
					new c00005f
					{
						RoomSceneId = 1L,
						RoomId = 4uL,
						RoomSceneLocationId = "f6f7256c-e438-4299-b99e-d20bef8cf7e0",
						Name = "Home",
						IsSandbox = false,
						DataBlobName = string.Empty,
						MaxPlayers = 20,
						CanMatchmakeInto = true,
						DataModifiedAt = DateTime.UtcNow
					}
				},
				CoOwners = new List<int>(),
				Hosts = new List<int>(),
				CheerCount = 1,
				FavoriteCount = 1,
				VisitCount = 1,
				Tags = new List<c000063>
				{
					new c000063
					{
						Tag = "community",
						Type = 1
					}
				}
			}
		},
		{
			"River",
			new c000060
			{
				Room = new c000061
				{
					RoomId = 8uL,
					Name = "River",
					Description = "The original outdoor paintball course. Simple, balanced, classic.",
					CreatorPlayerId = 0,
					ImageName = "93a53ced93a04f658795a87f4a4aab85",
					State = 0,
					Accessibility = 1,
					SupportsLevelVoting = false,
					IsAGRoom = false,
					CloningAllowed = false,
					SupportsScreens = true,
					SupportsTeleportVR = true,
					SupportsWalkVR = true
				},
				Scenes = new List<c00005f>
				{
					new c00005f
					{
						RoomSceneId = 1L,
						RoomId = 8uL,
						RoomSceneLocationId = "e122fe98-e7db-49e8-a1b1-105424b6e1f0",
						Name = "Home",
						IsSandbox = true,
						DataBlobName = string.Empty,
						MaxPlayers = 20,
						CanMatchmakeInto = true,
						DataModifiedAt = DateTime.UtcNow
					}
				},
				CoOwners = new List<int>(),
				Hosts = new List<int>(),
				CheerCount = 1,
				FavoriteCount = 1,
				VisitCount = 1,
				Tags = new List<c000063>
				{
					new c000063
					{
						Tag = "community",
						Type = 1
					}
				}
			}
		},
		{
			"Gym",
			new c000060
			{
				Room = new c000061
				{
					RoomId = 6uL,
					Name = "Gym",
					Description = "A school gymnasium for smaller sporting events.",
					CreatorPlayerId = 0,
					ImageName = "6d5c494668784816bbc41d9b870e5003",
					State = 0,
					Accessibility = 1,
					SupportsLevelVoting = false,
					IsAGRoom = false,
					CloningAllowed = false,
					SupportsScreens = true,
					SupportsTeleportVR = true,
					SupportsWalkVR = true
				},
				Scenes = new List<c00005f>
				{
					new c00005f
					{
						RoomSceneId = 1L,
						RoomId = 6uL,
						RoomSceneLocationId = "3d474b26-26f7-45e9-9a36-9b02847d5e6f",
						Name = "Home",
						IsSandbox = true,
						DataBlobName = string.Empty,
						MaxPlayers = 20,
						CanMatchmakeInto = true,
						DataModifiedAt = DateTime.UtcNow
					}
				},
				CoOwners = new List<int>(),
				Hosts = new List<int>(),
				CheerCount = 1,
				FavoriteCount = 1,
				VisitCount = 1,
				Tags = new List<c000063>
				{
					new c000063
					{
						Tag = "community",
						Type = 1
					}
				}
			}
		}
	};

	public static Dictionary<string, c000060> f000050 = new Dictionary<string, c000060>
	{
		{
			"DormRoom",
			new c000060
			{
				Room = new c000061
				{
					RoomId = 1uL,
					Name = "DormRoom",
					Description = "A private room. this is cool",
					CreatorPlayerId = APIServer.CachedPlayerID,
					ImageName = "ca673ff19c054158a15ff00f0b844ba7",
					State = 0,
					Accessibility = 1,
					SupportsLevelVoting = false,
					IsAGRoom = true,
					CloningAllowed = false,
					SupportsScreens = true,
					SupportsTeleportVR = true,
					SupportsWalkVR = true
				},
				Scenes = new List<c00005f>
				{
					new c00005f
					{
						RoomSceneId = 1L,
						RoomId = 1uL,
						RoomSceneLocationId = "76d98498-60a1-430c-ab76-b54a29b7a163",
						Name = "Home",
						IsSandbox = true,
						DataBlobName = string.Empty,
						MaxPlayers = 20,
						CanMatchmakeInto = true,
						DataModifiedAt = DateTime.UtcNow
					}
				},
				CoOwners = new List<int>(),
				Hosts = new List<int>(),
				CheerCount = 1,
				FavoriteCount = 1,
				VisitCount = 1,
				Tags = new List<c000063>
				{
					new c000063
					{
						Tag = "recroomoriginal",
						Type = 2
					}
				}
			}
		},
		{
			"RecCenter",
			new c000060
			{
				Room = new c000061
				{
					RoomId = 2uL,
					Name = "RecCenter",
					Description = "A social hub to meet and mingle with friends new and old.",
					CreatorPlayerId = APIServer.CachedPlayerID,
					ImageName = "22eefa3219f046fd9e2090814650ede3",
					State = 0,
					Accessibility = 1,
					SupportsLevelVoting = false,
					IsAGRoom = true,
					CloningAllowed = false,
					SupportsScreens = true,
					SupportsTeleportVR = true,
					SupportsWalkVR = true
				},
				Scenes = new List<c00005f>
				{
					new c00005f
					{
						RoomSceneId = 1L,
						RoomId = 2uL,
						RoomSceneLocationId = "cbad71af-0831-44d8-b8ef-69edafa841f6",
						Name = "Home",
						IsSandbox = false,
						DataBlobName = string.Empty,
						MaxPlayers = 20,
						CanMatchmakeInto = true,
						DataModifiedAt = DateTime.UtcNow
					}
				},
				CoOwners = new List<int>(),
				Hosts = new List<int>(),
				CheerCount = 1,
				FavoriteCount = 1,
				VisitCount = 1,
				Tags = new List<c000063>
				{
					new c000063
					{
						Tag = "recroomoriginal",
						Type = 2
					}
				}
			}
		},
		{
			"3DCharades",
			new c000060
			{
				Room = new c000061
				{
					RoomId = 3uL,
					Name = "3DCharades",
					Description = "Take turns drawing, acting, and guessing funny phrases with your friends!",
					CreatorPlayerId = APIServer.CachedPlayerID,
					ImageName = "57c0a08d2d074cd0ad499bb74cae197f.png",
					State = 0,
					Accessibility = 1,
					SupportsLevelVoting = false,
					IsAGRoom = true,
					CloningAllowed = false,
					SupportsScreens = true,
					SupportsTeleportVR = true,
					SupportsWalkVR = true
				},
				Scenes = new List<c00005f>
				{
					new c00005f
					{
						RoomSceneId = 1L,
						RoomId = 3uL,
						RoomSceneLocationId = "4078dfed-24bb-4db7-863f-578ba48d726b",
						Name = "Home",
						IsSandbox = false,
						DataBlobName = string.Empty,
						MaxPlayers = 20,
						CanMatchmakeInto = true,
						DataModifiedAt = DateTime.UtcNow
					}
				},
				CoOwners = new List<int>(),
				Hosts = new List<int>(),
				CheerCount = 1,
				FavoriteCount = 1,
				VisitCount = 1,
				Tags = new List<c000063>
				{
					new c000063
					{
						Tag = "recroomoriginal",
						Type = 2
					}
				}
			}
		},
		{
			"DiscGolfLake",
			new c000060
			{
				Room = new c000061
				{
					RoomId = 4uL,
					Name = "DiscGolfLake",
					Description = "Throw your friends into the lake. Sounds easy, right?",
					CreatorPlayerId = APIServer.CachedPlayerID,
					ImageName = "52cf6c3271894ecd95fb0c9b2d2209a7",
					State = 0,
					Accessibility = 1,
					SupportsLevelVoting = false,
					IsAGRoom = true,
					CloningAllowed = false,
					SupportsScreens = true,
					SupportsTeleportVR = true,
					SupportsWalkVR = true
				},
				Scenes = new List<c00005f>
				{
					new c00005f
					{
						RoomSceneId = 1L,
						RoomId = 4uL,
						RoomSceneLocationId = "f6f7256c-e438-4299-b99e-d20bef8cf7e0",
						Name = "Home",
						IsSandbox = false,
						DataBlobName = string.Empty,
						MaxPlayers = 4,
						CanMatchmakeInto = true,
						DataModifiedAt = DateTime.UtcNow
					}
				},
				CoOwners = new List<int>(),
				Hosts = new List<int>(),
				CheerCount = 1,
				FavoriteCount = 1,
				VisitCount = 1,
				Tags = new List<c000063>
				{
					new c000063
					{
						Tag = "recroomoriginal",
						Type = 2
					},
					new c000063
					{
						Tag = "sport",
						Type = 0
					}
				}
			}
		},
		{
			"DiscGolfPropulsion",
			new c000060
			{
				Room = new c000061
				{
					RoomId = 5uL,
					Name = "DiscGolfPropulsion",
					Description = "Throw your friends through hazards and around wind machines on this challenging course!",
					CreatorPlayerId = APIServer.CachedPlayerID,
					ImageName = "fc9a1acc47514b64a30d199d5ccdeca9",
					State = 0,
					Accessibility = 1,
					SupportsLevelVoting = false,
					IsAGRoom = true,
					CloningAllowed = false,
					SupportsScreens = true,
					SupportsTeleportVR = true,
					SupportsWalkVR = true
				},
				Scenes = new List<c00005f>
				{
					new c00005f
					{
						RoomSceneId = 1L,
						RoomId = 5uL,
						RoomSceneLocationId = "d9378c9f-80bc-46fb-ad1e-1bed8a674f55",
						Name = "Home",
						IsSandbox = false,
						DataBlobName = string.Empty,
						MaxPlayers = 20,
						CanMatchmakeInto = true,
						DataModifiedAt = DateTime.UtcNow
					}
				},
				CoOwners = new List<int>(),
				Hosts = new List<int>(),
				CheerCount = 1,
				FavoriteCount = 1,
				VisitCount = 1,
				Tags = new List<c000063>
				{
					new c000063
					{
						Tag = "recroomoriginal",
						Type = 2
					},
					new c000063
					{
						Tag = "sport",
						Type = 0
					}
				}
			}
		},
		{
			"Dodgeball",
			new c000060
			{
				Room = new c000061
				{
					RoomId = 6uL,
					Name = "Dodgeball",
					Description = "Throw dodgeballs to knock out your friends in this gym classic!",
					CreatorPlayerId = APIServer.CachedPlayerID,
					ImageName = "6d5c494668784816bbc41d9b870e5003",
					State = 0,
					Accessibility = 1,
					SupportsLevelVoting = false,
					IsAGRoom = true,
					CloningAllowed = false,
					SupportsScreens = true,
					SupportsTeleportVR = true,
					SupportsWalkVR = true
				},
				Scenes = new List<c00005f>
				{
					new c00005f
					{
						RoomSceneId = 1L,
						RoomId = 6uL,
						RoomSceneLocationId = "3d474b26-26f7-45e9-9a36-9b02847d5e6f",
						Name = "Home",
						IsSandbox = false,
						DataBlobName = string.Empty,
						MaxPlayers = 20,
						CanMatchmakeInto = true,
						DataModifiedAt = DateTime.UtcNow
					}
				},
				CoOwners = new List<int>(),
				Hosts = new List<int>(),
				CheerCount = 1,
				FavoriteCount = 1,
				VisitCount = 1,
				Tags = new List<c000063>
				{
					new c000063
					{
						Tag = "recroomoriginal",
						Type = 2
					},
					new c000063
					{
						Tag = "sport",
						Type = 0
					}
				}
			}
		},
		{
			"Paddleball",
			new c000060
			{
				Room = new c000061
				{
					RoomId = 7uL,
					Name = "Paddleball",
					Description = "A simple rally game between two players in a plexiglass tube with a zero-g ball.",
					CreatorPlayerId = APIServer.CachedPlayerID,
					ImageName = "ffdca6ed8bd94631ac15e3e894acb6c6",
					State = 0,
					Accessibility = 1,
					SupportsLevelVoting = false,
					IsAGRoom = true,
					CloningAllowed = false,
					SupportsScreens = true,
					SupportsTeleportVR = true,
					SupportsWalkVR = true
				},
				Scenes = new List<c00005f>
				{
					new c00005f
					{
						RoomSceneId = 1L,
						RoomId = 7uL,
						RoomSceneLocationId = "d89f74fa-d51e-477a-a425-025a891dd499",
						Name = "Home",
						IsSandbox = false,
						DataBlobName = string.Empty,
						MaxPlayers = 20,
						CanMatchmakeInto = true,
						DataModifiedAt = DateTime.UtcNow
					}
				},
				CoOwners = new List<int>(),
				Hosts = new List<int>(),
				CheerCount = 1,
				FavoriteCount = 1,
				VisitCount = 1,
				Tags = new List<c000063>
				{
					new c000063
					{
						Tag = "recroomoriginal",
						Type = 2
					},
					new c000063
					{
						Tag = "sport",
						Type = 0
					}
				}
			}
		},
		{
			"Paintball",
			new c000060
			{
				Room = new c000061
				{
					RoomId = 8uL,
					Name = "Paintball",
					Description = "Red and Blue teams splat each other in capture the flag and team battle.",
					CreatorPlayerId = APIServer.CachedPlayerID,
					ImageName = "93a53ced93a04f658795a87f4a4aab85",
					State = 0,
					Accessibility = 1,
					SupportsLevelVoting = true,
					IsAGRoom = true,
					CloningAllowed = false,
					SupportsScreens = true,
					SupportsTeleportVR = true,
					SupportsWalkVR = true
				},
				Scenes = new List<c00005f>
				{
					new c00005f
					{
						RoomSceneId = 1L,
						RoomId = 8uL,
						RoomSceneLocationId = "e122fe98-e7db-49e8-a1b1-105424b6e1f0",
						Name = "River",
						IsSandbox = false,
						DataBlobName = string.Empty,
						MaxPlayers = 20,
						CanMatchmakeInto = true,
						DataModifiedAt = DateTime.UtcNow
					},
					new c00005f
					{
						RoomSceneId = 2L,
						RoomId = 9uL,
						RoomSceneLocationId = "a785267d-c579-42ea-be43-fec1992d1ca7",
						Name = "Homestead",
						IsSandbox = false,
						DataBlobName = string.Empty,
						MaxPlayers = 20,
						CanMatchmakeInto = true,
						DataModifiedAt = DateTime.UtcNow
					},
					new c00005f
					{
						RoomSceneId = 3L,
						RoomId = 10uL,
						RoomSceneLocationId = "ff4c6427-7079-4f59-b22a-69b089420827",
						Name = "Quarry",
						IsSandbox = false,
						DataBlobName = string.Empty,
						MaxPlayers = 20,
						CanMatchmakeInto = true,
						DataModifiedAt = DateTime.UtcNow
					},
					new c00005f
					{
						RoomSceneId = 4L,
						RoomId = 11uL,
						RoomSceneLocationId = "380d18b5-de9c-49f3-80f7-f4a95c1de161",
						Name = "Clearcut",
						IsSandbox = false,
						DataBlobName = string.Empty,
						MaxPlayers = 20,
						CanMatchmakeInto = true,
						DataModifiedAt = DateTime.UtcNow
					},
					new c00005f
					{
						RoomSceneId = 5L,
						RoomId = 12uL,
						RoomSceneLocationId = "58763055-2dfb-4814-80b8-16fac5c85709",
						Name = "Spillway",
						IsSandbox = false,
						DataBlobName = string.Empty,
						MaxPlayers = 20,
						CanMatchmakeInto = true,
						DataModifiedAt = DateTime.UtcNow
					},
					new c00005f
					{
						RoomSceneId = 6L,
						RoomId = 33uL,
						RoomSceneLocationId = "65ddbb48-5a01-4e3e-972d-e5c7419e2bc3",
						Name = "Drive-in",
						IsSandbox = false,
						DataBlobName = string.Empty,
						MaxPlayers = 20,
						CanMatchmakeInto = true,
						DataModifiedAt = DateTime.UtcNow
					}
				},
				CoOwners = new List<int>(),
				Hosts = new List<int>(),
				CheerCount = 1,
				FavoriteCount = 1,
				VisitCount = 1,
				Tags = new List<c000063>
				{
					new c000063
					{
						Tag = "recroomoriginal",
						Type = 2
					},
					new c000063
					{
						Tag = "pvp",
						Type = 0
					}
				}
			}
		},
		{
			"GoldenTrophy",
			new c000060
			{
				Room = new c000061
				{
					RoomId = 13uL,
					Name = "GoldenTrophy",
					Description = "The goblin king stole Coach's Golden Trophy. Team up and embark on an epic quest to recover it!",
					CreatorPlayerId = APIServer.CachedPlayerID,
					ImageName = "38e9d0d4eff94556a0b106508249dcf9",
					State = 0,
					Accessibility = 1,
					SupportsLevelVoting = false,
					IsAGRoom = true,
					CloningAllowed = false,
					SupportsScreens = true,
					SupportsTeleportVR = true,
					SupportsWalkVR = true
				},
				Scenes = new List<c00005f>
				{
					new c00005f
					{
						RoomSceneId = 1L,
						RoomId = 13uL,
						RoomSceneLocationId = "91e16e35-f48f-4700-ab8a-a1b79e50e51b",
						Name = "Home",
						IsSandbox = false,
						DataBlobName = string.Empty,
						MaxPlayers = 20,
						CanMatchmakeInto = true,
						DataModifiedAt = DateTime.UtcNow
					}
				},
				CoOwners = new List<int>(),
				Hosts = new List<int>(),
				CheerCount = 1,
				FavoriteCount = 1,
				VisitCount = 1,
				Tags = new List<c000063>
				{
					new c000063
					{
						Tag = "recroomoriginal",
						Type = 2
					},
					new c000063
					{
						Tag = "quest",
						Type = 0
					}
				}
			}
		},
		{
			"TheRiseofJumbotron",
			new c000060
			{
				Room = new c000061
				{
					RoomId = 14uL,
					Name = "TheRiseofJumbotron",
					Description = "Robot invaders threaten the galaxy! Team up with your friends and bring the laser heat!",
					CreatorPlayerId = APIServer.CachedPlayerID,
					ImageName = "51296f28105b48178708e389b6daf057",
					State = 0,
					Accessibility = 1,
					SupportsLevelVoting = false,
					IsAGRoom = true,
					CloningAllowed = false,
					SupportsScreens = true,
					SupportsTeleportVR = true,
					SupportsWalkVR = true
				},
				Scenes = new List<c00005f>
				{
					new c00005f
					{
						RoomSceneId = 1L,
						RoomId = 14uL,
						RoomSceneLocationId = "acc06e66-c2d0-4361-b0cd-46246a4c455c",
						Name = "Home",
						IsSandbox = false,
						DataBlobName = string.Empty,
						MaxPlayers = 20,
						CanMatchmakeInto = true,
						DataModifiedAt = DateTime.UtcNow
					}
				},
				CoOwners = new List<int>(),
				Hosts = new List<int>(),
				CheerCount = 1,
				FavoriteCount = 1,
				VisitCount = 1,
				Tags = new List<c000063>
				{
					new c000063
					{
						Tag = "recroomoriginal",
						Type = 2
					},
					new c000063
					{
						Tag = "quest",
						Type = 0
					}
				}
			}
		},
		{
			"CrimsonCauldron",
			new c000060
			{
				Room = new c000061
				{
					RoomId = 15uL,
					Name = "CrimsonCauldron",
					Description = "Can your band of adventurers brave the enchanted wilds, and lift the curse of the crimson cauldron?",
					CreatorPlayerId = APIServer.CachedPlayerID,
					ImageName = "3ab82779dff94d11920ebf38df249395",
					State = 0,
					Accessibility = 1,
					SupportsLevelVoting = false,
					IsAGRoom = true,
					CloningAllowed = false,
					SupportsScreens = true,
					SupportsTeleportVR = true,
					SupportsWalkVR = true
				},
				Scenes = new List<c00005f>
				{
					new c00005f
					{
						RoomSceneId = 1L,
						RoomId = 15uL,
						RoomSceneLocationId = "949fa41f-4347-45c0-b7ac-489129174045",
						Name = "Home",
						IsSandbox = false,
						DataBlobName = string.Empty,
						MaxPlayers = 20,
						CanMatchmakeInto = true,
						DataModifiedAt = DateTime.UtcNow
					}
				},
				CoOwners = new List<int>(),
				Hosts = new List<int>(),
				CheerCount = 1,
				FavoriteCount = 1,
				VisitCount = 1,
				Tags = new List<c000063>
				{
					new c000063
					{
						Tag = "recroomoriginal",
						Type = 2
					},
					new c000063
					{
						Tag = "quest",
						Type = 0
					}
				}
			}
		},
		{
			"IsleOfLostSkulls",
			new c000060
			{
				Room = new c000061
				{
					RoomId = 16uL,
					Name = "IsleOfLostSkulls",
					Description = "Can your pirate crew get to the Isle, defeat its fearsome guardian, and escape with the gold? no",
					CreatorPlayerId = APIServer.CachedPlayerID,
					ImageName = "45ad53aa002646d0ab3eb509b9f260ef",
					State = 0,
					Accessibility = 1,
					SupportsLevelVoting = false,
					IsAGRoom = true,
					CloningAllowed = false,
					SupportsScreens = true,
					SupportsTeleportVR = true,
					SupportsWalkVR = true
				},
				Scenes = new List<c00005f>
				{
					new c00005f
					{
						RoomSceneId = 1L,
						RoomId = 16uL,
						RoomSceneLocationId = "7e01cfe0-820a-406f-b1b3-0a5bf575235c",
						Name = "Home",
						IsSandbox = false,
						DataBlobName = string.Empty,
						MaxPlayers = 20,
						CanMatchmakeInto = true,
						DataModifiedAt = DateTime.UtcNow
					}
				},
				CoOwners = new List<int>(),
				Hosts = new List<int>(),
				CheerCount = 1,
				FavoriteCount = 1,
				VisitCount = 1,
				Tags = new List<c000063>
				{
					new c000063
					{
						Tag = "recroomoriginal",
						Type = 2
					},
					new c000063
					{
						Tag = "quest",
						Type = 0
					}
				}
			}
		},
		{
			"Soccer",
			new c000060
			{
				Room = new c000061
				{
					RoomId = 17uL,
					Name = "Soccer",
					Description = "Teams of three run around slamming themselves into an over-sized soccer ball. Agonizing pain!",
					CreatorPlayerId = APIServer.CachedPlayerID,
					ImageName = "51c6f5ac5e6f4777b573e7e43f8a85ea",
					State = 0,
					Accessibility = 1,
					SupportsLevelVoting = false,
					IsAGRoom = true,
					CloningAllowed = false,
					SupportsScreens = true,
					SupportsTeleportVR = true,
					SupportsWalkVR = true
				},
				Scenes = new List<c00005f>
				{
					new c00005f
					{
						RoomSceneId = 1L,
						RoomId = 17uL,
						RoomSceneLocationId = "6d5eea4b-f069-4ed0-9916-0e2f07df0d03",
						Name = "Home",
						IsSandbox = false,
						DataBlobName = string.Empty,
						MaxPlayers = 20,
						CanMatchmakeInto = true,
						DataModifiedAt = DateTime.UtcNow
					}
				},
				CoOwners = new List<int>(),
				Hosts = new List<int>(),
				CheerCount = 1,
				FavoriteCount = 1,
				VisitCount = 1,
				Tags = new List<c000063>
				{
					new c000063
					{
						Tag = "recroomoriginal",
						Type = 2
					},
					new c000063
					{
						Tag = "sport",
						Type = 0
					}
				}
			}
		},
		{
			"LaserTag",
			new c000060
			{
				Room = new c000061
				{
					RoomId = 18uL,
					Name = "LaserTag",
					Description = "Teams battle each other and waves of robots. no mainframes cuz we lame LOL",
					CreatorPlayerId = APIServer.CachedPlayerID,
					ImageName = "c5a72193d6904811b2d0195a6deb3125",
					State = 0,
					Accessibility = 1,
					SupportsLevelVoting = true,
					IsAGRoom = true,
					CloningAllowed = false,
					SupportsScreens = true,
					SupportsTeleportVR = true,
					SupportsWalkVR = true
				},
				Scenes = new List<c00005f>
				{
					new c00005f
					{
						RoomSceneId = 1L,
						RoomId = 18uL,
						RoomSceneLocationId = "239e676c-f12f-489f-bf3a-d4c383d692c3",
						Name = "Hangar",
						IsSandbox = false,
						DataBlobName = string.Empty,
						MaxPlayers = 20,
						CanMatchmakeInto = true,
						DataModifiedAt = DateTime.UtcNow
					},
					new c00005f
					{
						RoomSceneId = 2L,
						RoomId = 19uL,
						RoomSceneLocationId = "9d6456ce-6264-48b4-808d-2d96b3d91038",
						Name = "CyberJunkCity",
						IsSandbox = false,
						DataBlobName = string.Empty,
						MaxPlayers = 20,
						CanMatchmakeInto = true,
						DataModifiedAt = DateTime.UtcNow
					}
				},
				CoOwners = new List<int>(),
				Hosts = new List<int>(),
				CheerCount = 1,
				FavoriteCount = 1,
				VisitCount = 1,
				Tags = new List<c000063>
				{
					new c000063
					{
						Tag = "recroomoriginal",
						Type = 2
					},
					new c000063
					{
						Tag = "pvp",
						Type = 0
					}
				}
			}
		},
		{
			"RecRoyaleSquads",
			new c000060
			{
				Room = new c000061
				{
					RoomId = 20uL,
					Name = "RecRoyaleSquads",
					Description = "Squads of three battle it out on Frontier Island. Last squad standing wins!",
					CreatorPlayerId = APIServer.CachedPlayerID,
					ImageName = "69fc525056014e39a435c4d2fdf2b887",
					State = 0,
					Accessibility = 1,
					SupportsLevelVoting = false,
					IsAGRoom = true,
					CloningAllowed = false,
					SupportsScreens = true,
					SupportsTeleportVR = true,
					SupportsWalkVR = true
				},
				Scenes = new List<c00005f>
				{
					new c00005f
					{
						RoomSceneId = 1L,
						RoomId = 20uL,
						RoomSceneLocationId = "253fa009-6e65-4c90-91a1-7137a56a267f",
						Name = "Home",
						IsSandbox = false,
						DataBlobName = string.Empty,
						MaxPlayers = 20,
						CanMatchmakeInto = true,
						DataModifiedAt = DateTime.UtcNow
					}
				},
				CoOwners = new List<int>(),
				Hosts = new List<int>(),
				CheerCount = 1,
				FavoriteCount = 1,
				VisitCount = 1,
				Tags = new List<c000063>
				{
					new c000063
					{
						Tag = "recroomoriginal",
						Type = 2
					},
					new c000063
					{
						Tag = "pvp",
						Type = 0
					}
				}
			}
		},
		{
			"RecRoyaleSolos",
			new c000060
			{
				Room = new c000061
				{
					RoomId = 21uL,
					Name = "RecRoyaleSolos",
					Description = "Battle it out on Frontier Island. Last person standing wins!",
					CreatorPlayerId = APIServer.CachedPlayerID,
					ImageName = "f9e112bb67fb430d979e5ad6c2c116d4",
					State = 0,
					Accessibility = 1,
					SupportsLevelVoting = false,
					IsAGRoom = true,
					CloningAllowed = false,
					SupportsScreens = true,
					SupportsTeleportVR = true,
					SupportsWalkVR = true
				},
				Scenes = new List<c00005f>
				{
					new c00005f
					{
						RoomSceneId = 1L,
						RoomId = 21uL,
						RoomSceneLocationId = "b010171f-4875-4e89-baba-61e878cd41e1",
						Name = "Home",
						IsSandbox = false,
						DataBlobName = string.Empty,
						MaxPlayers = 20,
						CanMatchmakeInto = true,
						DataModifiedAt = DateTime.UtcNow
					}
				},
				CoOwners = new List<int>(),
				Hosts = new List<int>(),
				CheerCount = 1,
				FavoriteCount = 1,
				VisitCount = 1,
				Tags = new List<c000063>
				{
					new c000063
					{
						Tag = "recroomoriginal",
						Type = 2
					},
					new c000063
					{
						Tag = "pvp",
						Type = 0
					}
				}
			}
		},
		{
			"Lounge",
			new c000060
			{
				Room = new c000061
				{
					RoomId = 22uL,
					Name = "Lounge",
					Description = "A low-key lounge to chill with your friends. Great for private parties!",
					CreatorPlayerId = APIServer.CachedPlayerID,
					ImageName = "3e8c2458f1e542ab8aa275e4083ee47a",
					State = 0,
					Accessibility = 1,
					SupportsLevelVoting = false,
					IsAGRoom = true,
					CloningAllowed = false,
					SupportsScreens = true,
					SupportsTeleportVR = true,
					SupportsWalkVR = true
				},
				Scenes = new List<c00005f>
				{
					new c00005f
					{
						RoomSceneId = 1L,
						RoomId = 22uL,
						RoomSceneLocationId = "a067557f-ca32-43e6-b6e5-daaec60b4f5a",
						Name = "Home",
						IsSandbox = true,
						DataBlobName = string.Empty,
						MaxPlayers = 20,
						CanMatchmakeInto = true,
						DataModifiedAt = DateTime.UtcNow
					}
				},
				CoOwners = new List<int>(),
				Hosts = new List<int>(),
				CheerCount = 1,
				FavoriteCount = 1,
				VisitCount = 1,
				Tags = new List<c000063>
				{
					new c000063
					{
						Tag = "recroomoriginal",
						Type = 2
					}
				}
			}
		},
		{
			"Park",
			new c000060
			{
				Room = new c000061
				{
					RoomId = 25uL,
					Name = "Park",
					Description = "A sprawling park with amphitheater, play fields, and a Ass.",
					CreatorPlayerId = APIServer.CachedPlayerID,
					ImageName = "79ee7af2532247f397867e48daa9d264.png",
					State = 0,
					Accessibility = 1,
					SupportsLevelVoting = false,
					IsAGRoom = true,
					CloningAllowed = false,
					SupportsScreens = true,
					SupportsTeleportVR = true,
					SupportsWalkVR = true
				},
				Scenes = new List<c00005f>
				{
					new c00005f
					{
						RoomSceneId = 1L,
						RoomId = 25uL,
						RoomSceneLocationId = "0a864c86-5a71-4e18-8041-8124e4dc9d98",
						Name = "Home",
						IsSandbox = true,
						DataBlobName = string.Empty,
						MaxPlayers = 20,
						CanMatchmakeInto = true,
						DataModifiedAt = DateTime.UtcNow
					}
				},
				CoOwners = new List<int>(),
				Hosts = new List<int>(),
				CheerCount = 1,
				FavoriteCount = 1,
				VisitCount = 1,
				Tags = new List<c000063>
				{
					new c000063
					{
						Tag = "recroomoriginal",
						Type = 2
					}
				}
			}
		},
		{
			"QuestForDracula",
			new c000060
			{
				Room = new c000061
				{
					RoomId = 27uL,
					Name = "QuestForDracula",
					Description = "Embark on a quest to murder some goblins and skeletons, then jump through an empty doorway to the voidlands or not depending on what version you're playing!",
					CreatorPlayerId = APIServer.CachedPlayerID,
					ImageName = "d0df003353914adfaecdd23f428208b6",
					State = 0,
					Accessibility = 1,
					SupportsLevelVoting = false,
					IsAGRoom = true,
					CloningAllowed = false,
					SupportsScreens = true,
					SupportsTeleportVR = true,
					SupportsWalkVR = true
				},
				Scenes = new List<c00005f>
				{
					new c00005f
					{
						RoomSceneId = 1L,
						RoomId = 27uL,
						RoomSceneLocationId = "49cb8993-a956-43e2-86f4-1318f279b22a",
						Name = "Home",
						IsSandbox = false,
						DataBlobName = string.Empty,
						MaxPlayers = 20,
						CanMatchmakeInto = true,
						DataModifiedAt = DateTime.UtcNow
					}
				},
				CoOwners = new List<int>(),
				Hosts = new List<int>(),
				CheerCount = int.MaxValue,
				FavoriteCount = 1,
				VisitCount = 1,
				Tags = new List<c000063>
				{
					new c000063
					{
						Tag = "recroomoriginal",
						Type = 2
					},
					new c000063
					{
						Tag = "quest",
						Type = 0
					}
				}
			}
		},
		{
			"Bowling",
			new c000060
			{
				Room = new c000061
				{
					RoomId = 28uL,
					Name = "Bowling",
					Description = "shut up coffeeman this bowling description was so annoying >:(",
					CreatorPlayerId = APIServer.CachedPlayerID,
					ImageName = "4d143a3359e8483e8d48116ab6cacecb",
					State = 0,
					Accessibility = 1,
					SupportsLevelVoting = false,
					IsAGRoom = true,
					CloningAllowed = false,
					SupportsScreens = true,
					SupportsTeleportVR = true,
					SupportsWalkVR = true
				},
				Scenes = new List<c00005f>
				{
					new c00005f
					{
						RoomSceneId = 1L,
						RoomId = 28uL,
						RoomSceneLocationId = "ae929543-9a07-41d5-8ee9-dbbee8c36800",
						Name = "Home",
						IsSandbox = false,
						DataBlobName = string.Empty,
						MaxPlayers = 20,
						CanMatchmakeInto = true,
						DataModifiedAt = DateTime.UtcNow
					}
				},
				CoOwners = new List<int>(),
				Hosts = new List<int>(),
				CheerCount = 1,
				FavoriteCount = 1,
				VisitCount = 1,
				Tags = new List<c000063>
				{
					new c000063
					{
						Tag = "recroomoriginal",
						Type = 2
					},
					new c000063
					{
						Tag = "sport",
						Type = 0
					}
				}
			}
		},
		{
			"PublicSandbox",
			new c000060
			{
				Room = new c000061
				{
					RoomId = 29uL,
					Name = "PublicSandbox",
					Description = "A room where everyone has sandbox permissions!",
					CreatorPlayerId = APIServer.CachedPlayerID,
					ImageName = "4sW4Tx-AhkWqgeDCB4v4Zw",
					State = 0,
					Accessibility = 1,
					SupportsLevelVoting = false,
					IsAGRoom = true,
					CloningAllowed = true,
					SupportsScreens = true,
					SupportsTeleportVR = true,
					SupportsWalkVR = true
				},
				Scenes = new List<c00005f>
				{
					new c00005f
					{
						RoomSceneId = 1L,
						RoomId = 29uL,
						RoomSceneLocationId = "0a864c86-5a71-4e18-8041-8124e4dc9d98",
						Name = "Park",
						IsSandbox = true,
						DataBlobName = string.Empty,
						MaxPlayers = 20,
						CanMatchmakeInto = true,
						DataModifiedAt = DateTime.UtcNow
					},
					new c00005f
					{
						RoomSceneId = 2L,
						RoomId = 30uL,
						RoomSceneLocationId = "a067557f-ca32-43e6-b6e5-daaec60b4f5a",
						Name = "Lounge",
						IsSandbox = true,
						DataBlobName = string.Empty,
						MaxPlayers = 20,
						CanMatchmakeInto = true,
						DataModifiedAt = DateTime.UtcNow
					}
				},
				CoOwners = new List<int>(),
				Hosts = new List<int>(),
				CheerCount = 1,
				FavoriteCount = 1,
				VisitCount = 1,
				Tags = new List<c000063>
				{
					new c000063
					{
						Tag = "recroomoriginal",
						Type = 2
					}
				}
			}
		},
		{
			"StuntRunner",
			new c000060
			{
				Room = new c000061
				{
					RoomId = 31uL,
					Name = "StuntRunner",
					Description = "Sprint, climb, and wall jump in this high-speed obstacle course where every second counts!",
					CreatorPlayerId = APIServer.CachedPlayerID,
					ImageName = "8j4f516axpnpjgnj342t85vkd.png",
					State = 0,
					Accessibility = 1,
					SupportsLevelVoting = false,
					IsAGRoom = true,
					CloningAllowed = true,
					SupportsScreens = true,
					SupportsTeleportVR = true,
					SupportsWalkVR = true
				},
				Scenes = new List<c00005f>
				{
					new c00005f
					{
						RoomSceneId = 1L,
						RoomId = 31uL,
						RoomSceneLocationId = "b7281665-a715-4051-826b-8e08e69c6172",
						Name = "StuntRunner",
						IsSandbox = false,
						DataBlobName = string.Empty,
						MaxPlayers = 20,
						CanMatchmakeInto = true,
						DataModifiedAt = DateTime.UtcNow
					},
					new c00005f
					{
						RoomSceneId = 2L,
						RoomId = 32uL,
						RoomSceneLocationId = "3a636bd2-f896-424c-9225-c184522c0d87",
						Name = "TheMainEvent",
						IsSandbox = false,
						DataBlobName = string.Empty,
						MaxPlayers = 20,
						CanMatchmakeInto = false,
						DataModifiedAt = DateTime.UtcNow
					}
				},
				CoOwners = new List<int>(),
				Hosts = new List<int>(),
				CheerCount = 1,
				FavoriteCount = 1,
				VisitCount = 1,
				Tags = new List<c000063>
				{
					new c000063
					{
						Tag = "recroomoriginal",
						Type = 2
					}
				}
			}
		}
	};

	public static Dictionary<string, c000060> m00003a()
	{
		Dictionary<string, c000060> dictionary = new Dictionary<string, c000060>();
		string[] directories = Directory.GetDirectories("SaveData/Rooms");
		for (int i = 0; i < directories.Length; i++)
		{
			c000060 c100 = JsonConvert.DeserializeObject<c000060>(File.ReadAllText(directories[i] + "/RoomDetails.json"));
			dictionary.Add(c100.Room.Name, c100);
		}
		return dictionary;
	}

	public static c000060 m000023(int p0)
	{
		foreach (KeyValuePair<string, c000060> item in f000050)
		{
			if (item.Value.Room.RoomId == (ulong)p0)
			{
				return item.Value;
			}
		}
		foreach (KeyValuePair<string, c000060> item2 in m00003a())
		{
			if (item2.Value.Room.RoomId == (ulong)p0)
			{
				return item2.Value;
			}
		}
		try
		{
			return JsonConvert.DeserializeObject<c000060>(new WebClient().DownloadString("https://raw.githubusercontent.com/aqquad/RebornRec/main/data/" + p0));
		}
		catch
		{
			return f000050["DormRoom"];
		}
	}

	public static c000061 m000024(string p0)
	{
		foreach (KeyValuePair<string, c000060> item in f000050)
		{
			if (item.Key == p0)
			{
				return item.Value.Room;
			}
		}
		foreach (KeyValuePair<string, c000060> item2 in m00003a())
		{
			if (item2.Key == p0)
			{
				return item2.Value.Room;
			}
		}
		if (APIServer.CommunityRooms == null)
		{
			APIServer.CommunityRooms = JsonConvert.DeserializeObject<List<c000061>>(new WebClient().DownloadString("https://raw.githubusercontent.com/aqquad/RebornRec/main/communityrooms.txt"));
		}
		foreach (c000061 communityRoom in APIServer.CommunityRooms)
		{
			if (communityRoom.Name == p0)
			{
				return communityRoom;
			}
		}
		return null;
	}
}

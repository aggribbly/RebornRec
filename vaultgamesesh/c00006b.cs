namespace vaultgamesesh;

internal sealed class c00006b
{
	public sealed class c00006c
	{
		private ulong[] f000001;

		private c00006d[] f00004f;

		private string[] f000003;

		private string f000035;

		private string f000036;

		private int f000006;

		private bool f000016;

		public ulong[] ExpectedPlayerIds
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

		public c00006d[] RegionPings
		{
			get
			{
				return f00004f;
			}
			set
			{
				f00004f = value;
			}
		}

		public string[] RoomTags
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

		public string RoomName
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

		public string SceneName
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

		public int AdditionalPlayerJoinMode
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

		public bool Private
		{
			get
			{
				return f000016;
			}
			set
			{
				f000016 = value;
			}
		}
	}

	public sealed class c00006d
	{
		private string f00000a;

		private int f00000b;

		public string Region
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

		public int Ping
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
}

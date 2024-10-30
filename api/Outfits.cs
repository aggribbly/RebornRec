using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace api;

public sealed class Outfits
{
	public sealed class c000073
	{
		private string f00000a;

		private string f000002;

		private string f000003;

		private string f000035;

		public string OutfitSelections
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

		public string HairColor
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

		public string SkinColor
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

		public string FaceFeatures
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
	}

	public sealed class Outfit
	{
		private string f00000a;

		private string f000002;

		private string f000003;

		private string f000035;

		private string f000036;

		private string f00000e;

		public string Slot
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

		public string PreviewImageName
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

		public string OutfitSelections
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

		public string HairColor
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

		public string SkinColor
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

		public string FaceFeatures
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
	}

	private static List<Outfit> f000031;

	public static string m000009()
	{
		if (f000031 == null)
		{
			m000033();
		}
		return JsonConvert.SerializeObject(f000031);
	}

	public static void m000024()
	{
		c000073 c = new c000073();
		if (c00008a.m00004c((c00008a.enum08b)1))
		{
			BinaryReader binaryReader = new BinaryReader(new MemoryStream(c00008a.m00004e((c00008a.enum08b)1)));
			try
			{
				c.OutfitSelections = binaryReader.ReadString();
				c.HairColor = binaryReader.ReadString();
				c.SkinColor = binaryReader.ReadString();
				c.FaceFeatures = binaryReader.ReadString();
				return;
			}
			finally
			{
				((IDisposable)binaryReader).Dispose();
			}
		}
		c = new c000073
		{
			OutfitSelections = string.Empty,
			HairColor = string.Empty,
			SkinColor = string.Empty,
			FaceFeatures = string.Empty
		};
	}

	public static void m000033()
	{
		f000031 = new List<Outfit>();
		if (!c00008a.m00004c((c00008a.enum08b)10))
		{
			return;
		}
		BinaryReader binaryReader = new BinaryReader(new MemoryStream(c00008a.m00004e((c00008a.enum08b)10)));
		try
		{
			while (binaryReader.BaseStream.Position != binaryReader.BaseStream.Length)
			{
				Outfit item = new Outfit
				{
					Slot = binaryReader.ReadString(),
					PreviewImageName = binaryReader.ReadString(),
					OutfitSelections = binaryReader.ReadString(),
					HairColor = binaryReader.ReadString(),
					SkinColor = binaryReader.ReadString(),
					FaceFeatures = binaryReader.ReadString()
				};
				f000031.Add(item);
			}
		}
		finally
		{
			((IDisposable)binaryReader).Dispose();
		}
	}

	public static void m00003e()
	{
		MemoryStream memoryStream = new MemoryStream();
		byte[] p;
		try
		{
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			try
			{
				foreach (Outfit item in f000031)
				{
					binaryWriter.Write(item.Slot);
					binaryWriter.Write(item.PreviewImageName);
					binaryWriter.Write(item.OutfitSelections);
					binaryWriter.Write(item.HairColor);
					binaryWriter.Write(item.SkinColor);
					if (item.FaceFeatures != null)
					{
						binaryWriter.Write(item.FaceFeatures);
					}
					else
					{
						binaryWriter.Write("");
					}
				}
			}
			finally
			{
				((IDisposable)binaryWriter).Dispose();
			}
			p = memoryStream.ToArray();
		}
		finally
		{
			((IDisposable)memoryStream).Dispose();
		}
		c00008a.m00004d((c00008a.enum08b)10, p);
	}

	public static void m00003f(string p0)
	{
		Outfit outfit = JsonConvert.DeserializeObject<Outfit>(p0);
		for (int i = 0; i < f000031.Count; i++)
		{
			if (outfit.Slot == f000031[i].Slot)
			{
				f000031.RemoveAt(i);
			}
		}
		f000031.Add(outfit);
		m00003e();
	}
}

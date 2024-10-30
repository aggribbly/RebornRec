using System;
using System.Collections.Generic;
using System.IO;

namespace api;

internal sealed class c00008a
{
	public enum enum08b
	{

	}

	public static List<string> f000026;

	public static string f000009 = "SaveData/outfits.txt";

	public static bool m00004c(enum08b p0)
	{
		if (f000026 == null)
		{
			m000024();
		}
		return f000026[(int)p0] != string.Empty;
	}

	public static void m000024()
	{
		f000026 = new List<string>();
		string path = f000009;
		if (File.Exists(path))
		{
			string[] array = File.ReadAllLines(path);
			foreach (string item in array)
			{
				f000026.Add(item);
			}
		}
		while (f000026.Count != 13)
		{
			f000026.Add(string.Empty);
		}
	}

	public static void m00004d(enum08b p0, byte[] p1)
	{
		bool num = f000026 == null;
		if (num)
		{
			m000024();
		}
		if (!num)
		{
			f000026[(int)p0] = Convert.ToBase64String(p1, 0, p1.Length, Base64FormattingOptions.None);
		}
		m000033();
	}

	public static byte[] m00004e(enum08b p0)
	{
		if (f000026 == null)
		{
			m000024();
		}
		return Convert.FromBase64String(f000026[(int)p0]);
	}

	public static void m000033()
	{
		if (f000026 == null)
		{
			m000024();
		}
		if (!File.Exists(f000009))
		{
			File.WriteAllText(f000009, "");
		}
		File.WriteAllLines(f000009, f000026);
	}
}

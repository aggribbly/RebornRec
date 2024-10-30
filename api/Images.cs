using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using start;
using vaultgamesesh;

namespace api;

public class Images
{
	public sealed class ImageNamed
	{
		public string FriendlyImageName { get; set; }

		public string ImageName { get; set; }

		public string StartTime { get; set; }

		public string EndTime { get; set; }
	}

	public static string SaveImage(byte[] bytes, bool flag)
	{
		if (Program.version == 2017 || Program.version == 2016)
		{
			byte[] bytes2 = PartParser.ParseData(bytes, "image.png");
			string text = "RebornRec-" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + ".png";
			if (flag)
			{
				File.WriteAllBytes("SaveData/profileimage.png", bytes2);
			}
			else
			{
				File.WriteAllBytes("SaveData/Photos/" + text, bytes2);
			}
			return JsonConvert.SerializeObject(new c00007e.c00007f(text));
		}
		byte[] bytes3 = PartParser.ParseData(bytes, "image.dat");
		string text2 = ((c000041.f000043 == null) ? "RebornRec" : c000041.f000043.Room.Name);
		string text3 = text2 + "-" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + ".png";
		if (flag)
		{
			File.WriteAllBytes("SaveData/profileimage.png", bytes3);
		}
		else
		{
			File.WriteAllBytes("SaveData/Photos/" + text3, bytes3);
		}
		return JsonConvert.SerializeObject(new c00007e.c00007f(text3));
	}

	public static string Named()
	{
		return JsonConvert.SerializeObject(new List<ImageNamed>
		{
			new ImageNamed
			{
				FriendlyImageName = "DormRoomBucket",
				ImageName = File.ReadAllText("SaveData/Profile/username.txt"),
				StartTime = "2021-12-27T21:27:38.188Z",
				EndTime = "2026-12-27T21:27:38.188Z"
			},
			new ImageNamed
			{
				FriendlyImageName = "Loft",
				ImageName = "cf863d3a013f4332abaac807324cb339.jpg",
				StartTime = "2021-12-27T21:27:38.188Z",
				EndTime = "2026-12-27T21:27:38.188Z"
			},
			new ImageNamed
			{
				FriendlyImageName = "BackStairs",
				ImageName = "b63bcfa3e16042f59e1b2ba40021b9b9.jpg",
				StartTime = "2021-12-27T21:27:38.188Z",
				EndTime = "2026-12-27T21:27:38.188Z"
			}
		});
	}
}

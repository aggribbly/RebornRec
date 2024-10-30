using System.Collections.Generic;
using Newtonsoft.Json;

namespace api;

internal class Activities
{
	public class Charades
	{
		public class Word
		{
			public string EN_US { get; set; }

			public int Difficulty { get; set; }
		}

		public static string Words()
		{
			return JsonConvert.SerializeObject(new List<Word>
			{
				new Word
				{
					EN_US = "grape",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "roblox",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "tree",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "nuclear acid",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "cloud",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "iphone",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "spaghetti",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "lean",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "bitcoin",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "Expo Dry Erase Marker",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "2016 door",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "carrot",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "punch up",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "nft",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "grass",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "recroom2016",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "ukulele",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "joker",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "lemon",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "go-kart",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "fortnite",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "Cheeseburga",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "woman",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "Beta Jumbotron Boss",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "spiderman",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "Rock",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "vr",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "Beta Crossbow",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "among us",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "beta laser shotgun",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "kitty",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "coach with a gun",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "Ford F150",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "Wehrlyball paddle",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "mirror couples",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "funny fish",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "legendary hockey shirt",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "Skinwalker",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "aquad",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "goat",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "christmas tree",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "PANCAKES!",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "ur mom",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "stick of ram",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "beta circuits v1",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "BONEWORKS",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "big mac",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "Discord",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "go-kart",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "ninetndo switch",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "beta crescendo rake",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "An Enemy from Epic Quest",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "cheese",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "boxing",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "garfield",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "[Arena_EMP]",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "fuel cell",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "Unity (the game engine)",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "horseshoe",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "coach",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "tuna",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "that clock behind you",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "Someone in this room",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "OpenRec",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "angry birds",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "pipebomb",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "green guitar",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "RebornRec",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "femboy",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "Raw Data",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "Dodgeball",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "your house",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "JumboTron",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "big balls",
					Difficulty = 0
				},
				new Word
				{
					EN_US = "[TutorialCamera]",
					Difficulty = 0
				}
			});
		}
	}
}

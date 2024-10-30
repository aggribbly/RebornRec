using gamesesh;

namespace api;

internal class Config
{
	public static GameSessions.SessionInstance localGameSession;

	public static Objective[][] dailyObjectives = new Objective[7][]
	{
		new Objective[3]
		{
			new Objective
			{
				type = 21,
				score = 1
			},
			new Objective
			{
				type = 802,
				score = 3
			},
			new Objective
			{
				type = 100,
				score = 2
			}
		},
		new Objective[3]
		{
			new Objective
			{
				type = 502,
				score = 5
			},
			new Objective
			{
				type = 400,
				score = 3
			},
			new Objective
			{
				type = 101,
				score = 2
			}
		},
		new Objective[3]
		{
			new Objective
			{
				type = 301,
				score = 3
			},
			new Objective
			{
				type = 202,
				score = 4
			},
			new Objective
			{
				type = 603,
				score = 2
			}
		},
		new Objective[3]
		{
			new Objective
			{
				type = 21,
				score = 1
			},
			new Objective
			{
				type = 802,
				score = 3
			},
			new Objective
			{
				type = 100,
				score = 2
			}
		},
		new Objective[3]
		{
			new Objective
			{
				type = 502,
				score = 5
			},
			new Objective
			{
				type = 400,
				score = 3
			},
			new Objective
			{
				type = 101,
				score = 2
			}
		},
		new Objective[3]
		{
			new Objective
			{
				type = 301,
				score = 3
			},
			new Objective
			{
				type = 202,
				score = 4
			},
			new Objective
			{
				type = 603,
				score = 2
			}
		},
		new Objective[3]
		{
			new Objective
			{
				type = 302,
				score = 3
			},
			new Objective
			{
				type = 401,
				score = 2
			},
			new Objective
			{
				type = 800,
				score = 1
			}
		}
	};
}

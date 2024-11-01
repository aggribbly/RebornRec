using System;
using System.Collections.Generic;
using api2018;

namespace api2017;

internal class Profiles
{
	public int Id { get; set; }

	public string Username { get; set; }

	public string DisplayName { get; set; }

	public int XP { get; set; }

	public int Level { get; set; }

	public int Reputation { get; set; }

	public bool Verified { get; set; }

	public bool Developer { get; set; }

	public bool HasEmail { get; set; }

	public bool CanReceiveInvites { get; set; }

	public string ProfileImageName { get; set; }

	public bool JuniorProfile { get; set; }

	public bool ForceJuniorImages { get; set; }

	public bool PendingJunior { get; set; }

	public bool HasBirthday { get; set; }

	public string PhoneLastFour { get; set; }

	public DateTime EmailEnteredAt { get; set; }

	public PlayerReputation PlayerReputation { get; set; }

	public List<mPlatformID> PlatformIds { get; set; }
}

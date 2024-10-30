namespace api2019;

public class Equipment2020
{
	public string PrefabName { get; set; }

	public string ModificationGuid { get; set; }

	public bool Favorited { get; set; }

	public int PlatformMask => -1;

	public string FriendlyName => "";

	public string Tooltip => "";

	public int Rarity => 0;
}

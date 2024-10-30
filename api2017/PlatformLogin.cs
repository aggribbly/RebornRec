using Newtonsoft.Json;

namespace api2017;

internal class PlatformLogin
{
	public string Token { get; set; }

	public int PlayerId { get; set; }

	public string Error { get; set; }

	public bool FirstLoginOfTheDay { get; set; }

	public static string v4(int userid)
	{
		return JsonConvert.SerializeObject(new PlatformLogin
		{
			Token = "RebornRecToken",
			PlayerId = userid,
			Error = "",
			FirstLoginOfTheDay = true
		});
	}
}

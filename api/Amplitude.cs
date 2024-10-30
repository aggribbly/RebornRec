using Newtonsoft.Json;

namespace api;

internal class Amplitude
{
	public string AmplitudeKey { get; set; }

	public static string amplitude()
	{
		return JsonConvert.SerializeObject(new Amplitude
		{
			AmplitudeKey = "RebornKey"
		});
	}
}

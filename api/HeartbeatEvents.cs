namespace api;

public class HeartbeatEvents
{
	public delegate void RoomChange();

	public delegate void MatchChange();

	public static event RoomChange RoomChangeEvent;

	public static event MatchChange MatchChangeEvent;

	public static void OnRoomChangeEvent()
	{
		HeartbeatEvents.RoomChangeEvent();
	}

	public static void OnMatchChangeEvent()
	{
		HeartbeatEvents.MatchChangeEvent();
	}
}

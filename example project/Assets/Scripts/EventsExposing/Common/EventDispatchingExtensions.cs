using UnityEngine;

public static class EventDispatchingExtensions
{
	public static T GetEventsDispatcher<T>(this GameObject go) where T : BaseSingleTriggerEventDispatcher<Object, Object>
	{
		T existingDispatcher = go.GetComponent<T>();
		if (existingDispatcher == null)
		{
			existingDispatcher = go.AddComponent<T>();
		}
		return existingDispatcher;
	}
}

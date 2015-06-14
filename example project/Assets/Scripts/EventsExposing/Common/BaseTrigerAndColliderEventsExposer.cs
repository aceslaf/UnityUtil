using System;
using UnityEngine;

public abstract class BaseTrigerAndColliderEventsExposer<EventArgs, DispatcherArgs> : MonoBehaviour
{
	public void SubscribeToTriggerEvent<T>(Action<EventArgs, DispatcherArgs> handler) where T : BaseSingleTriggerEventDispatcher<EventArgs, DispatcherArgs>
	{
		T existingExposer = this.gameObject.GetComponent<T>();
		if (existingExposer == null)
		{
			existingExposer = this.gameObject.AddComponent<T>();
		}
		existingExposer.SubscribeToTriggerEvent(handler);
	}

	public void SubscribeToLightTriggerEvent<T>(Action<DispatcherArgs> handler) where T : BaseLightSingleTriggerEventDispatcher<DispatcherArgs>
	{
		T existingExposer = this.gameObject.GetComponent<T>();
		if (existingExposer == null)
		{
			existingExposer = this.gameObject.AddComponent<T>();
		}
		existingExposer.SubscribeToLightTriggerEvent(handler);
	}
}

public static class EventsExposingExtensions
{
	public static ExposerType SubscribeToTriggerEventExtension<ExposerType, EventArgs1, DispatcherArgs>(this GameObject go, Action<EventArgs1, DispatcherArgs> handler) where ExposerType : BaseSingleTriggerEventDispatcher<EventArgs1, DispatcherArgs>
	{
		ExposerType existingExposer = go.GetComponent<ExposerType>();
		if (existingExposer == null)
		{
			existingExposer = go.AddComponent<ExposerType>();
		}
		existingExposer.SubscribeToTriggerEvent(handler);
		return existingExposer;
	}

	public static ExposerType SubscribeToLightTriggerEventExtension<ExposerType, DispatcherArgs>(this GameObject go, Action<DispatcherArgs> handler) where ExposerType : BaseLightSingleTriggerEventDispatcher<DispatcherArgs>
	{
		ExposerType existingExposer = go.GetComponent<ExposerType>();
		if (existingExposer == null)
		{
			existingExposer = go.AddComponent<ExposerType>();
		}
		existingExposer.SubscribeToLightTriggerEvent(handler);
		return existingExposer;
	}

	public static ExposerType UnSubscribeToTriggerEventExtension<ExposerType, EventArgs1, DispatcherArgs>(this GameObject go, Action<EventArgs1, DispatcherArgs> handler) where ExposerType : BaseSingleTriggerEventDispatcher<EventArgs1, DispatcherArgs>
	{
		ExposerType existingExposer = go.GetComponent<ExposerType>();
		if (existingExposer == null)
		{
			Debug.LogError("Event dispatcher does not exist anymore");
			return default(ExposerType);
		}
		existingExposer.UnSubscribeToTriggerEvent(handler);
		return existingExposer;
	}

	public static ExposerType UnSubscribeToLightTriggerEventExtension<ExposerType, DispatcherArgs>(this GameObject go, Action<DispatcherArgs> handler) where ExposerType : BaseLightSingleTriggerEventDispatcher<DispatcherArgs>
	{
		ExposerType existingExposer = go.GetComponent<ExposerType>();
		if (existingExposer == null)
		{
			Debug.LogError("Event dispatcher does not exist anymore");
			return default(ExposerType);
		}
		existingExposer.UnSubscribeToLightTriggerEvent(handler);
		return existingExposer;
	}
}


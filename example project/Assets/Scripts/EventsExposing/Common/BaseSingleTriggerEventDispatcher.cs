using System;
using UnityEngine;

public abstract class BaseSingleTriggerEventDispatcher<EventArgs, DispatcherArgs> : MonoBehaviour, ISingleColliderEventDispatcher<EventArgs, DispatcherArgs>
{
	public abstract void SubscribeToTriggerEvent(Action<EventArgs, DispatcherArgs> handler);
}

public interface ISingleColliderEventDispatcher<EventArgs, DispatcherArgs>
{
	void SubscribeToTriggerEvent(Action<EventArgs, DispatcherArgs> handler);
}
using System;
using UnityEngine;

public abstract class BaseSingleTriggerEventDispatcher<EventArgs, DispatcherArgs> : MonoBehaviour
{
	public abstract void SubscribeToTriggerEvent(Action<EventArgs, DispatcherArgs> handler);
	public abstract void UnSubscribeToTriggerEvent(Action<EventArgs, DispatcherArgs> handler);
}

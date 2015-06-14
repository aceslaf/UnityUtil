using System;
using UnityEngine;

public abstract class BaseTrigerAndColliderEventsExposer<EventArgs, DispatcherArgs> : MonoBehaviour, IColliderEventsDispatcher<EventArgs, DispatcherArgs>, ILightColliderEventsDispatcher<DispatcherArgs>
{

	protected abstract BaseLightSingleTriggerEventDispatcher<DispatcherArgs> LightEnterDispatcherr { get; }
	protected abstract BaseLightSingleTriggerEventDispatcher<DispatcherArgs> LightStayDispatcher { get; }
	protected abstract BaseLightSingleTriggerEventDispatcher<DispatcherArgs> LightExitDispatcher { get; }

	protected abstract BaseSingleTriggerEventDispatcher<EventArgs, DispatcherArgs> EnterDispatcherr { get; }
	protected abstract BaseSingleTriggerEventDispatcher<EventArgs, DispatcherArgs> StayDispatcher { get; }
	protected abstract BaseSingleTriggerEventDispatcher<EventArgs, DispatcherArgs> ExitDispatcher { get; }

	public void SubscribeToLightTriggerEvent(AllTriggerEventsTypes.EventTypes eventType, Action<DispatcherArgs> handler)
	{
		switch (eventType)
		{
			case AllTriggerEventsTypes.EventTypes.Enter:
				{
					this.LightEnterDispatcherr.SubscribeToLightTriggerEvent(handler);
					break;
				}
			case AllTriggerEventsTypes.EventTypes.Stay:
				{
					this.LightStayDispatcher.SubscribeToLightTriggerEvent(handler);
					break;
				}
			case AllTriggerEventsTypes.EventTypes.Exit:
				{
					this.LightExitDispatcher.SubscribeToLightTriggerEvent(handler);
					break;
				}
			default:
				{
					throw new NotImplementedException("event type not implemented");
				}
		}
	}

	public void SubscribeToTriggerEvent(AllTriggerEventsTypes.EventTypes eventType, Action<EventArgs, DispatcherArgs> handler)
	{
		switch (eventType)
		{
			case AllTriggerEventsTypes.EventTypes.Enter:
				{
					this.EnterDispatcherr.SubscribeToTriggerEvent(handler);
					break;
				}
			case AllTriggerEventsTypes.EventTypes.Stay:
				{
					this.StayDispatcher.SubscribeToTriggerEvent(handler);
					break;
				}
			case AllTriggerEventsTypes.EventTypes.Exit:
				{
					this.ExitDispatcher.SubscribeToTriggerEvent(handler);
					break;
				}
			default:
				{
					throw new NotImplementedException("event type not implemented");
				}
		}
	}
}

public interface ILightColliderEventsDispatcher<DispatcherType>
{
	void SubscribeToLightTriggerEvent(AllTriggerEventsTypes.EventTypes eventType, Action<DispatcherType> handler);

}

public interface IColliderEventsDispatcher<EventArgsType, DispatcherType>
{
	void SubscribeToTriggerEvent(AllTriggerEventsTypes.EventTypes eventType, Action<EventArgsType, DispatcherType> go);
}

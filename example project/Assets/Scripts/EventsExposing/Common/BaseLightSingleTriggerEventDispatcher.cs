using System;
using UnityEngine;

public abstract class BaseLightSingleTriggerEventDispatcher<DispatcherType> : MonoBehaviour, ISengleLightColliderEventDispatcher<DispatcherType>
{
	public abstract void SubscribeToLightTriggerEvent(Action<DispatcherType> go);
}

public interface ISengleLightColliderEventDispatcher<DispatcherType>
{
	void SubscribeToLightTriggerEvent(Action<DispatcherType> go);
}

using System;
using UnityEngine;

public abstract class BaseLightSingleTriggerEventDispatcher<DispatcherType> : MonoBehaviour
{
	public abstract void SubscribeToLightTriggerEvent(Action<DispatcherType> go);
	public abstract void UnSubscribeToLightTriggerEvent(Action<DispatcherType> go);
}

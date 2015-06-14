using System;
using UnityEngine;
[DisallowMultipleComponent]
public class UpdateEventExposer : BaseLightSingleTriggerEventDispatcher<GameObject>
{
	private event Action<GameObject> OnUpdate;
	void Update()
	{
		if (this.OnUpdate != null)
		{
			this.OnUpdate(this.gameObject);
		}
	}


	public override void SubscribeToLightTriggerEvent(Action<GameObject> go)
	{
		this.OnUpdate += go;
	}

	public override void UnSubscribeToLightTriggerEvent(Action<GameObject> go)
	{
		if (this.OnUpdate != null)
		{
			this.OnUpdate -= go;
		}
	}
}

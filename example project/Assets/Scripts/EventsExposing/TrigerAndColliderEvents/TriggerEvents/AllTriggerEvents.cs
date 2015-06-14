using System;
using UnityEngine;


[DisallowMultipleComponent]
public class LightTriggerEnterDispatcher : BaseLightSingleTriggerEventDispatcher<GameObject>
{
	private event Action<GameObject> Enter;
	public override void SubscribeToLightTriggerEvent(Action<GameObject> go)
	{
		this.Enter += go;
	}

	public override void UnSubscribeToLightTriggerEvent(Action<GameObject> go)
	{
		if (this.Enter != null)
		{
			this.Enter -= go;
		}
	}

	private void OnTriggerEnter()
	{
		if (this.Enter != null)
		{
			this.Enter(this.gameObject);
		}
	}
}
[DisallowMultipleComponent]
public class LightTriggerExitDispatcher : BaseLightSingleTriggerEventDispatcher<GameObject>
{
	private event Action<GameObject> Exit;
	public override void SubscribeToLightTriggerEvent(Action<GameObject> go)
	{
		this.Exit += go;
	}

	public override void UnSubscribeToLightTriggerEvent(Action<GameObject> go)
	{
		if (this.Exit != null)
		{
			this.Exit -= go;
		}
	}

	private void OnTriggerExit()
	{
		if (this.Exit != null)
		{
			this.Exit(this.gameObject);
		}
	}
}

[DisallowMultipleComponent]
public class LightTriggerStayDispatcher : BaseLightSingleTriggerEventDispatcher<GameObject>
{
	private event Action<GameObject> Stay;
	public override void SubscribeToLightTriggerEvent(Action<GameObject> go)
	{
		this.Stay += go;
	}
	public override void UnSubscribeToLightTriggerEvent(Action<GameObject> go)
	{
		if (this.Stay != null)
		{
			this.Stay -= go;
		}
	}
	private void OnTriggerStay()
	{
		if (this.Stay != null)
		{
			this.Stay(this.gameObject);
		}
	}
}

[DisallowMultipleComponent]
public class TriggerEnterDispatcher : BaseSingleTriggerEventDispatcher<Collider, GameObject>
{
	private event Action<Collider, GameObject> Enter;

	public override void SubscribeToTriggerEvent(Action<Collider, GameObject> handler)
	{
		this.Enter += handler;
	}

	public override void UnSubscribeToTriggerEvent(Action<Collider, GameObject> handler)
	{
		if (this.Enter != null)
		{
			this.Enter -= handler;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (this.Enter != null)
		{
			this.Enter(other, this.gameObject);
		}
	}
}
[DisallowMultipleComponent]
public class TriggerExitDispatcher : BaseSingleTriggerEventDispatcher<Collider, GameObject>
{
	private event Action<Collider, GameObject> Exit;

	public override void UnSubscribeToTriggerEvent(Action<Collider, GameObject> handler)
	{
		if (this.Exit != null)
		{
			this.Exit -= handler;
		}
	}
	public override void SubscribeToTriggerEvent(Action<Collider, GameObject> handler)
	{
		this.Exit += handler;
	}

	private void OnTriggerExit(Collider other)
	{
		if (this.Exit != null)
		{
			this.Exit(other, this.gameObject);
		}
	}
}
[DisallowMultipleComponent]
public class TriggerStayDispatcher : BaseSingleTriggerEventDispatcher<Collider, GameObject>
{
	private event Action<Collider, GameObject> Stay;

	public override void SubscribeToTriggerEvent(Action<Collider, GameObject> handler)
	{
		this.Stay += handler;
	}
	public override void UnSubscribeToTriggerEvent(Action<Collider, GameObject> handler)
	{
		if (this.Stay != null)
		{
			this.Stay -= handler;
		}
	}
	private void OnTriggerStay(Collider other)
	{
		if (this.Stay != null)
		{
			this.Stay(other, this.gameObject);
		}
	}
}

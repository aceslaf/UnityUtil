using UnityEngine;
using System.Collections;
using Assets.Scripts.EventsExposing.Common;
using Assets.Scripts.EventsExposing.StandardEvents;

public class Asd : MonoBehaviour {

    public GameObject goToListenTo;
	// Use this for initialization
	void Start () {
        var dispatcher = goToListenTo.ExposeEvent<UpdateEventDispatcher>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

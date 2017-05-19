using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayTrigger : MonoBehaviour {
	void Start () {
		EventTrigger trigger = GetComponent<EventTrigger>();
		EventTrigger.Entry entry = new EventTrigger.Entry();
		entry.eventID = EventTriggerType.PointerClick;
		entry.callback.AddListener((data) => { OnPointerDownDelegate((PointerEventData)data); });
		trigger.triggers.Add(entry);
	}

	public void OnPointerDownDelegate(PointerEventData data)
	{
//		print ("OnPointerDownDelegate called.");
	}
}

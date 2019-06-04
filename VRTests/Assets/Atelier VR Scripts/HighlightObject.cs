using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HighlightObject : MonoBehaviour {
	public GameObject panelInfo;
	public Color highlightColor = Color.red;
	private Color originalColor;
	
	void Start()
	{
		originalColor = GetComponent<Renderer>().material.color;
		
		
		var eventSystem = gameObject.AddComponent<EventTrigger>();
		
		EventTrigger.Entry entry = new EventTrigger.Entry();
		entry.eventID = EventTriggerType.PointerEnter;
		entry.callback.AddListener(e => Hightlight(true));
		eventSystem.triggers.Add(entry);
		
		EventTrigger.Entry entry2 = new EventTrigger.Entry();
		entry2.eventID = EventTriggerType.PointerExit;
		entry2.callback.AddListener(e => Hightlight(false));
		eventSystem.triggers.Add(entry2);
	}

	public void Hightlight( bool isHighlighting )
	{
		Debug.Log("Highlight "+isHighlighting);
		if (isHighlighting)
		{
			GetComponent<Renderer>().material.color = highlightColor;
			ActivateInfo(true);	
		}
		else
		{
			GetComponent<Renderer>().material.color = originalColor;
			ActivateInfo(false);
		}
	}

	public void ActivateInfo(bool activate)
	{
		if(panelInfo != null)
			panelInfo.SetActive(activate);
	}
	
	
}

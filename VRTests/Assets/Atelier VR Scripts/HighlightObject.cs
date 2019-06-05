using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HighlightObject : MonoBehaviour {
	public GameObject panelInfo;
	public InteractiveAction InteractiveAction;
	public Color highlightColor = Color.red;
	private Color originalColor;
	private bool IsHighlight;
	private bool CarryMode;
	private OVRPlayerController _playerController;

	void Start()
	{
		_playerController = FindObjectOfType<OVRPlayerController>();
		originalColor = GetComponent<Renderer>().material.color;
		
		
		var eventSystem = gameObject.AddComponent<EventTrigger>();
		
		EventTrigger.Entry entry = new EventTrigger.Entry();
		entry.eventID = EventTriggerType.PointerEnter;
		entry.callback.AddListener(e =>
		{
			if (!CarryMode)
			{
				Hightlight(true);
			}	
		}
		);
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
			foreach (var renderer in GetComponentsInChildren<Renderer>()) {
				foreach (var material in renderer.materials) {
					material.color = highlightColor;
				}
			}
			
			ActivateInfo(true);	
		}
		else
		{
			foreach (var renderer in GetComponentsInChildren<Renderer>()) {
				foreach (var material in renderer.materials) {
					material.color = originalColor;
				}
			}
			ActivateInfo(false);
		}
	}

	public void ActivateInfo(bool activate)
	{
		IsHighlight = activate;
		if(panelInfo != null)
			panelInfo.SetActive(activate);
	}
	
	
	private void Update() {
		Debug.Log(CarryMode);
		if (CarryMode)
		{
			var ray = Camera.main.ScreenPointToRay( new Vector2( Screen.width / 2, Screen.height / 2 ));
			
			transform.position = _playerController.transform.position + ray.direction * 2;
			if (Input.GetButton("Fire1"))
			{
				ActivateCarryMode(false);
			}
		}
		if (!IsHighlight)
			return;
		if (Input.GetButton("Fire1")) {
			if (InteractiveAction != null)
				InteractiveAction.OnAction(this);
		}
	}

	public void ActivateCarryMode(bool activate)
	{
		StartCoroutine(ActivateCarryModeCoroutine(activate));
		
	}

	private IEnumerator ActivateCarryModeCoroutine(bool activate)
	{
		yield return new WaitForSeconds(0.1f);
		CarryMode = activate;
		var rigidbody = GetComponent<Rigidbody>();
		if (rigidbody != null)
			rigidbody.isKinematic = activate;
		if (activate)
		{
			Hightlight(false);
		}	
	}
}

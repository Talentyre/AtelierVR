using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Teleporter : InteractiveAction
{
	public String SceneName;
	public bool Automatic;
		
	private void OnTriggerEnter(Collider other)
    {
		if (Automatic)
			OnAction(other.gameObject.GetComponent<HighlightObject>());
    }
	
	public override void OnAction (HighlightObject highlightObject) {
		SceneManager.LoadScene(SceneName);
	}
}

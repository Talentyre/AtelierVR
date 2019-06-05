using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryObject : InteractiveAction {

	public override void OnAction(HighlightObject highlightObject)
	{
		highlightObject.ActivateCarryMode(true);
	}
}

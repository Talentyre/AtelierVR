using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractiveAction : MonoBehaviour
{
    public abstract void OnAction (HighlightObject highlightObject);
}

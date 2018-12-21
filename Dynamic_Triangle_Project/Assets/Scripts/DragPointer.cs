using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragPointer : MonoBehaviour {

	/// <summary>
	/// Dragging points
	/// </summary>

	private Vector3 mouseToVector;
	[SerializeField] private SceneController sceneController;

	public void OnMouseDown () {
		mouseToVector = transform.root.position - Camera.main.ScreenToWorldPoint (Input.mousePosition);
	}

	public void OnMouseDrag ()    {
		transform.root.position = Camera.main.ScreenToWorldPoint (Input.mousePosition) + mouseToVector;

		//only update the stats when its dragged
		sceneController.updateLine = true;
	}

	public void OnMouseUp () {
		sceneController.updateLine = false;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SceneController : MonoBehaviour {

	/// <summary>
	/// By Grant Stevens-Wade 26-Match-2017
	/// This script allows for the resizing of the triangle
	/// It is referenced in the drag pointer script
	/// </summary>

	public bool updateLine = true;
	[SerializeField] private GameObject[] points;

	//[SerializeField] private LineRenderer line;
	[SerializeField] private GameObject dotPrefab;

	void Start()
	{


		//line renderer was what i went to first incase I couldn't get the points working

		/*Vector3[] pointPositions = new Vector3[4];
		pointPositions[0] = points[0].transform.root.position;
		pointPositions[1] = points[1].transform.root.position;
		pointPositions[2] = points[2].transform.root.position;
		pointPositions[3] = points[0].transform.root.position;
		line.numPositions = pointPositions.Length;
		line.SetPositions(pointPositions);*/

	}


	void FixedUpdate()
	{



		if (updateLine == true)
		{
			//get point transform and put into array
			for (int i=0; i<points.Length+1; i++)
			{
				//back up incase i couldn't get the points to work

				/*if (i < points.Length) {
					line.SetPosition(i, new Vector3(points[i].transform.position.x, points[i].transform.position.y));
				}
				else
				{
					line.SetPosition(i, new Vector3(points[0].transform.position.x, points[0].transform.position.y));
				}*/

				var p0 = points[0].transform.root.position; //a
				var p1 = points[1].transform.root.position; //b
				var p2 = points[2].transform.root.position; //c

				//putting the stats into a textbox which is a child
				points[0].GetComponentInChildren<Text>().text = "A\nX: "+p0.x.ToString("F2")+"\nY: "+p0.y.ToString("F2")+"\nAngle: "+Mathf.Round(Vector2.Angle((p1-p0), (p1-p2))).ToString();
				points[1].GetComponentInChildren<Text>().text = "B\nX: "+p1.x.ToString("F2")+"\nY: "+p1.y.ToString("F2")+"\nAngle: "+Mathf.Round(Vector2.Angle((p2-p1), (p2-p0))).ToString();
				points[2].GetComponentInChildren<Text>().text = "C\nX: "+p2.x.ToString("F2")+"\nY: "+p2.y.ToString("F2")+"\nAngle: "+Mathf.Round(Vector2.Angle((p0-p2), (p0-p1))).ToString();

			}

			DragActions();
		}


	}

	//resize the triangle everytime it is dragged.
	public void DragActions()
	{
		DeletePreviousTriangle();
		DrawTriangle(points[0].transform.root.position, points[1].transform.root.position);
		DrawTriangle(points[1].transform.root.position, points[2].transform.root.position);
		DrawTriangle(points[2].transform.root.position, points[0].transform.root.position);
	}

	public void DrawTriangle(Vector3 pointA, Vector3 pointB)
	{
		float pointCount = Vector2.Distance(pointA, pointB) * 5;

		for (int i=0; i<Mathf.CeilToInt(pointCount); i++)
		{
			GameObject Dot = Instantiate(dotPrefab, new Vector3(0,0,0), Quaternion.identity);
			Vector3 point = Vector3.Lerp(pointA, pointB, (i*1.5f)/pointCount);
			Dot.transform.position = point;
		}
	}


	public void DeletePreviousTriangle()
	{
		foreach (GameObject obj in GameObject.FindObjectsOfType<GameObject>())
		{
			if (obj.name == "DotPrefab(Clone)")
			{
				Destroy(obj);
			}
		}
	}


}

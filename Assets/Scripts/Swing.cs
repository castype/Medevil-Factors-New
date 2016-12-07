using UnityEngine;
using System.Collections;

public class Swing : MonoBehaviour
{
	[SerializeField]
	public float angle = 90.0f;

	[SerializeField]
	public float speed = 1.5f;

	public bool activateR;

	public bool activateL;

	Quaternion qStart, qEnd;

	private float startTime;

	void Start () 
	{
		qStart = Quaternion.AngleAxis ( angle, Vector3.forward);
		qEnd = Quaternion.AngleAxis (-angle, Vector3.forward);
	}

	void Update ()
	{
		if (activateR == true)
		{
			startTime += Time.deltaTime;
			transform.rotation = Quaternion.Lerp (qStart, qEnd,(Mathf.Sin(startTime * speed + Mathf.PI/2) + 1.0f)/ 2.0f);
		}
		if(activateR == false && activateL == false)
		{
			resetTimer ();
		}
	}

	void resetTimer()
	{
		startTime = 0.0f;
	}
}


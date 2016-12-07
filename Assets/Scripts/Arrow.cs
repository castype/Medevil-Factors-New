using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Arrow : MonoBehaviour 

{
	[SerializeField]
	private float speed;

	private Rigidbody2D myRigidbody;

	private Vector2 direction;

	// Use this for initialization
	void Start () 
	{
		myRigidbody = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate()
	{
		myRigidbody.velocity = direction * speed;

	}

	public void Initialize(Vector2 direction)
	{
		this.direction = direction;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			Destroy (other.gameObject);
		}
	}

	void OnBecameInvisible()
	{
		Destroy (gameObject);
	}
}
using UnityEngine;
using System.Collections;
using System;

public class Ladder : MonoBehaviour, IUseable 
{
	[SerializeField]
	private Collider2D platformCollider;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void Use()
	{
		if (Player_New.Instance.OnLadder)
		{
			UseLadder (false,1,0,1, "land");
		}
		else 
		{
			UseLadder (true,0,1,0, "reset");
			Physics2D.IgnoreCollision (Player_New.Instance.GetComponent<Collider2D> (), platformCollider, true);
		}
	}

	private void UseLadder(bool onLadder, int gravity, int layerWeight, int animSpeed, string trigger)
	{
		Player_New.Instance.OnLadder = onLadder;
		Player_New.Instance.MyRigidbody.gravityScale = gravity;
		Player_New.Instance.MyAnimator.SetLayerWeight (2, layerWeight);
		Player_New.Instance.MyAnimator.speed = animSpeed;
		Player_New.Instance.MyAnimator.SetTrigger (trigger);
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			UseLadder (false, 1,0,1, "land");
			Physics2D.IgnoreCollision (Player_New.Instance.GetComponent<Collider2D> (), platformCollider, false);
		}
	}

}

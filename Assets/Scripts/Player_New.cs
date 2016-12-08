using UnityEngine;
using System.Collections;
using System;

public delegate void DeadEventHandler();

public class Player_New : Character 
{

	private static Player_New instance;

	private int coins;

	private Vector2 startPos;

	public event DeadEventHandler Dead;

	private IUseable useable;

    public bool isRunning { get; set; }
		
	[SerializeField]
	private Transform[] groundPoints;

	[SerializeField]
	private float groundRadius;

	[SerializeField]
	private LayerMask whatIsGround;

	[SerializeField]
	private bool airControl;

	[SerializeField]
	private float jumpForce;

	[SerializeField]
	private GameObject arrowPrefab;

	[SerializeField]
	protected Transform arrowPos;

	private bool immortal = false;

	private SpriteRenderer spriteRenderer;

	[SerializeField]
	private float immortalTime;

	[SerializeField]
	private float climbSpeed;

	private float direction;

	private bool move;

	private float btnHorizontal;

	public Rigidbody2D MyRigidbody { get; set; }

	public bool OnLadder { get; set; }

	public bool Slide { get; set; }

	public bool Jump { get; set; }

	public bool Run { get; set; }

	public bool OnGround { get; set; }

	public static Player_New Instance
	{
		get
		{
			if (instance == null) 
			{
				instance = GameObject.FindObjectOfType<Player_New> ();
			}
			return instance;
		}

	}

	public override bool IsDead
	{
		get
		{
			if (healthStat.CurrentVal <= 0)
			{
				OnDead ();
			}

			return healthStat.CurrentVal <= 0;
		}
	}

	public bool IsFalling
	{
		get 
		{
			return MyRigidbody.velocity.y < -3;
		}
	}

	// Use this for initialization
	public override void Start ()
	{
		base.Start();
		OnLadder = false;
		startPos = transform.position;
		spriteRenderer = GetComponent<SpriteRenderer> ();
		MyRigidbody = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		if (!TakingDamage && !IsDead) 
		{
			if (transform.position.y <= -14f)
			{
				Death ();
			}
			HandleInput ();
		}

	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		if (!TakingDamage && !IsDead)
		{
			float horizontal = Input.GetAxis("Horizontal");
			float vertical = Input.GetAxis("Vertical");

			OnGround = IsGrounded ();

			if (move) 
			{
				this.btnHorizontal = Mathf.Lerp (btnHorizontal, direction, Time.deltaTime * 2);
				Flip (direction);
			} 
			else
			{
				HandleMovement (horizontal, vertical);
				Flip (horizontal);
			}

			HandleLayers ();
		}

	}

	public void OnDead()
	{
		if (Dead != null) 
		{
			Dead ();
		}

	}

	private void HandleMovement(float horizontal, float vertical)
	{

        if (isRunning)
        {
            movementSpeed = 5f;
        }
        else
        {
            movementSpeed = 2f;
        }

		if (IsFalling) 
		{
			gameObject.layer = 11;
			MyAnimator.SetBool ("land", true);
		}
		if (!Attack && !Slide && (OnGround || airControl))
		{
			MyRigidbody.velocity = new Vector2 (horizontal * movementSpeed, MyRigidbody.velocity.y);
		}
		if (Jump && MyRigidbody.velocity.y == 0 )
		{
			MyRigidbody.AddForce(new Vector2(0, jumpForce));
		}
		if (OnLadder)
		{
			MyAnimator.speed = vertical != 0 ? Mathf.Abs(vertical) : Mathf.Abs(horizontal);
			MyRigidbody.velocity = new Vector2 (horizontal * climbSpeed, vertical * climbSpeed);
		}

		MyAnimator.SetFloat ("speed", Mathf.Abs (horizontal));
	}

	private void HandleInput()
	{
		if (Input.GetKeyDown (KeyCode.Space) && !OnLadder && !IsFalling) 
		{
			MyAnimator.SetTrigger ("jump");
			Jump = true;
		}
		if (Input.GetKeyDown (KeyCode.LeftShift) ) 
		{
            if (MyRigidbody.velocity.x != 0)
			MyAnimator.SetTrigger ("run");
		}

		if (Input.GetKeyDown (KeyCode.R)) 
		{
			MyAnimator.SetTrigger ("attack");
		}
		if (Input.GetKeyDown (KeyCode.LeftControl)) 
		{
			MyAnimator.SetTrigger ("slide");
		}
		if (Input.GetMouseButton(0)) 
		{
			MyAnimator.SetTrigger ("shootArrow");
		
		}
		if (Input.GetMouseButtonUp(0))
		{
			MyAnimator.SetTrigger ("releaseArrow");
			ShootArrow (0);
		}
		if (Input.GetKeyDown (KeyCode.E)) 
		{
			Use ();
		}
	}

	private void Flip(float horizontal)
	{
		if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
		{
			ChangeDirection ();
		}
	}

	private bool IsGrounded()
	{
		if (MyRigidbody.velocity.y == 0) 
		{
            //foreach (Transform point in groundPoints) 
            //{
            //    Collider2D[] colliders = Physics2D.OverlapCircleAll (point.position, groundRadius, whatIsGround);

            //    for (int i = 0; i < colliders.Length; i++) 
            //    {
            //        if (colliders [i].gameObject != gameObject) 
            //        {
            //            return true;
            //        }
            //    }

            //}
            return true;
		}
		return false;
	}

	private void HandleLayers()
	{
		if (!OnGround) 
		{
			MyAnimator.SetLayerWeight (1, 1);
		} 
		else 
		{
			MyAnimator.SetLayerWeight (1, 0);
		}
	}

	public void ShootArrow(int value)
	{
			if (facingRight)
			{
				GameObject tmp = (GameObject)Instantiate (arrowPrefab, transform.position, Quaternion.identity);
				tmp.GetComponent<Arrow> ().Initialize (Vector2.right);
			}
			else 
			{
				GameObject tmp = (GameObject)Instantiate (arrowPrefab, transform.position, Quaternion.identity);
				tmp.GetComponent<Arrow> ().Initialize (Vector2.left);
			}

	}

	//public IEnumerator ShootArrow()
	//{	
		//GameObject arrow = (GameObject) Instantiate (arrowPrefab, transform.position, Quaternion.identity);

		//yield return new WaitForSeconds (0.5);
	//}

	private IEnumerator IndicateImmortal()
	{
		while (immortal)
		{
			spriteRenderer.enabled = false;

			yield return new WaitForSeconds (.1f);

			spriteRenderer.enabled = true;

			yield return new WaitForSeconds (.1f);
		}
	}
		
	public override IEnumerator TakeDamage()
	{
		if (!immortal) 
		{
			healthStat.CurrentVal -= 10;

			if (!IsDead) 
			{
				MyAnimator.SetTrigger ("damage");
				immortal = true;
				StartCoroutine (IndicateImmortal ());
				yield return new WaitForSeconds(immortalTime);

				immortal = false;
			} 
			else
			{
				MyAnimator.SetLayerWeight (1, 0);
				MyAnimator.SetTrigger ("die");
			}

		}
	}

	public override void Death()
	{
		MyRigidbody.velocity = Vector2.zero;
		MyAnimator.SetTrigger ("idle");
		healthStat.CurrentVal = healthStat.MaxVal;
		transform.position = startPos;
	}

	private void Use()
	{
		if (useable != null) 
		{
			useable.Use ();
		}
	}



	public void BtnAttack()
	{
		MyAnimator.SetTrigger ("attack");
	}

	public void BtnSlide()
	{
		MyAnimator.SetTrigger ("slide");
	}

	public void BtnShootArrow()
	{
		MyAnimator.SetTrigger ("shootArrow");
	}

	public void BtnMove(float direction)
	{
		this.direction = direction;
		this.move = true;
	}

	public void BtnStopMove()
	{
		this.direction = 0;
		this.btnHorizontal = 0;
		this.move = false;
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Coin") 
		{
			GameManager.Instance.CollectedCoins++;
			Destroy (other.gameObject);
		}
        if (other.transform.tag == "SwingingPlatform")
        {
            transform.parent = other.transform;
        }
	}

	public override void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Useable") 
		{
			useable = other.GetComponent<IUseable> ();
		}

		base.OnTriggerEnter2D (other);
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Useable") 
		{
			useable = null;
		}
	}

}

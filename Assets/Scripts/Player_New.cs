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

    [SerializeField]
	public bool OnGround { get; set; }

	private bool launch = false;

	[SerializeField]
	private float catapultLaunchX;

	[SerializeField]
	private float catapultLaunchY;

    [SerializeField]
    public bool TakeOff;

    Transform arrowPoint;

    [SerializeField]
    private float maxArrowDegree;

    [SerializeField]
    private int minArrowDegree;



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
			return MyRigidbody.velocity.y > 0;
		}
	}

	// Use this for initialization
	public override void Start ()
	{
		base.Start();
        OnGround = false;
        TakeOff = false;
		OnLadder = false;
		startPos = transform.position;
		spriteRenderer = GetComponent<SpriteRenderer> ();
		MyRigidbody = GetComponent<Rigidbody2D>();
	}

    void Awake() {
        arrowPoint = transform.FindChild("ArrowPos");

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

			if (move || launch) 
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
		if (Jump && OnGround && !TakeOff )
		{
			MyRigidbody.AddForce(new Vector2(0, jumpForce));
            TakeOff = true;
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
		if (Input.GetKeyDown (KeyCode.Space) && !OnLadder && OnGround) 
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

        //calculate the angles between arrow position and mouse position
        var mousePos = Input.mousePosition;
        mousePos.z = 10; // select distance = 10 units from the camera
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(mousePos).x, Camera.main.ScreenToWorldPoint(mousePos).y);
        Vector2 arrowPointPosition = new Vector2(arrowPoint.position.x, arrowPoint.position.y);

        //Debug.DrawLine(arrowPointPosition, mousePosition);

        Vector2 pointDiff = mousePosition - arrowPointPosition;
        float arrowDegree = FindDegree(pointDiff.x, pointDiff.y);

        //account for the difference between camera and arrow point
        Vector3 sp = Camera.main.WorldToScreenPoint(transform.position + new Vector3(1.05f, 0.5f, 0));
        Vector3 angle = (Input.mousePosition - sp).normalized;



        if (facingRight)
        {
            if (arrowDegree < maxArrowDegree && arrowDegree > minArrowDegree)
            {
                Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, (-arrowDegree)));
                GameObject tmp = (GameObject)Instantiate(arrowPrefab, arrowPos.position, rotation);
                tmp.GetComponent<Arrow>().Initialize(angle);
            }
            else
            {
                GameObject tmp2 = (GameObject)Instantiate(arrowPrefab, arrowPos.position, Quaternion.Euler(new Vector3(0, 0, -90)));
                tmp2.GetComponent<Arrow>().Initialize(Vector2.right);
            }

        }
        else
        {

            GameObject tmp2 = (GameObject)Instantiate(arrowPrefab, arrowPos.position, Quaternion.Euler(new Vector3(0, 0, 90)));
            tmp2.GetComponent<Arrow>().Initialize(Vector2.left);

        }


		

	}


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
            OnGround = true;
		}
        if (other.transform.tag == "Ground")
        {
            OnGround = true;
        }
 
		launch = false;
		
	}


    private void OnCollisionStay2D(Collision2D other)
    {

        if (other.transform.tag == "SwingingPlatform")
        {
            OnGround = true;
        }
        if (other.transform.tag == "Ground")
        {
            OnGround = true;
        }

        launch = false;

    }

	private void OnCollisionExit2D(Collision2D other)
	{
		if (other.transform.tag == "SwingingPlatform")
		{
			transform.parent = null;
            transform.rotation = Quaternion.identity;
            OnGround = false;

		}
        if (other.transform.tag == "Ground")
        {
            OnGround = false;
        }
        if (other.transform.name == "Catapult_Bowl")
        {
            LaunchPlayer();
            MyAnimator.SetBool("land", true);
        }


		
	}

	public override void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Useable") 
		{
			useable = other.GetComponent<IUseable> ();
		}
        if (other.tag == "SignTrigger")
        {
            GameObject sign = GameObject.Find("MathProblemSign");
            var x = sign.GetComponent<Rigidbody2D>();
            x.constraints = RigidbodyConstraints2D.None;
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

	public void LaunchPlayer()
	{
		launch = true;
		MyRigidbody.velocity = new Vector2(catapultLaunchX, catapultLaunchY);
        gameObject.layer = 11;
        MyAnimator.SetBool("land", true);
	}

    public static float FindDegree(float x, float y)
    {
        float value = (float)((Mathf.Atan2(x, y) / Math.PI) * 180f);
        if (value < 0) value += 360f;

        return value;
    }
}

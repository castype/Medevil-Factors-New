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
        if (other.gameObject.tag == "Shield")
        {
            Destroy(gameObject);

            #region Equation1
            if (Player_New.Instance.equationNum == 1)
            {
                if (other.name == "shield-40")
                {
                    GameObject objl = GameObject.Find("Correct_Left");
                    SpriteRenderer objlsr = objl.GetComponent<SpriteRenderer>();
                    objlsr.enabled = true;

                    GameObject code = GameObject.Find("Code1");
                    SpriteRenderer sr = code.GetComponent<SpriteRenderer>();
                    sr.enabled = true;
                }
                if (other.name == "shield-9")
                {
                    GameObject objm = GameObject.Find("Wrong_Middle");
                    SpriteRenderer objmsr = objm.GetComponent<SpriteRenderer>();
                    objmsr.enabled = true;
                }
                if (other.name == "shield-21")
                {
                    GameObject objr = GameObject.Find("Wrong_Right");
                    SpriteRenderer objrsr = objr.GetComponent<SpriteRenderer>();
                    objrsr.enabled = true;

                }
            }
            #endregion

            #region Equation2
            if (Player_New.Instance.equationNum == 2)
            {
                if (other.name == "shield-4")
                {
                    GameObject objr = GameObject.Find("Correct_Right");
                    SpriteRenderer objrsr = objr.GetComponent<SpriteRenderer>();
                    objrsr.enabled = true;

                    GameObject code = GameObject.Find("Code2");
                    SpriteRenderer sr = code.GetComponent<SpriteRenderer>();
                    sr.enabled = true;
                }
                if (other.name == "shield-2")
                {
                    GameObject objl = GameObject.Find("Wrong_Left");
                    SpriteRenderer objlsr = objl.GetComponent<SpriteRenderer>();
                    objlsr.enabled = true;
                }
                if (other.name == "shield-16")
                {
                    GameObject objm = GameObject.Find("Wrong_Middle");
                    SpriteRenderer objmsr = objm.GetComponent<SpriteRenderer>();
                    objmsr.enabled = true;

                }
            }
            #endregion

            #region Equation3
            if (Player_New.Instance.equationNum == 3)
            {
                if (other.name == "shield-30")
                {
                    GameObject objr = GameObject.Find("Correct_Middle");
                    SpriteRenderer objrsr = objr.GetComponent<SpriteRenderer>();
                    objrsr.enabled = true;

                    GameObject code = GameObject.Find("Code3");
                    SpriteRenderer sr = code.GetComponent<SpriteRenderer>();
                    sr.enabled = true;
                }
                if (other.name == "shield-23")
                {
                    GameObject objl = GameObject.Find("Wrong_Left");
                    SpriteRenderer objlsr = objl.GetComponent<SpriteRenderer>();
                    objlsr.enabled = true;
                }
                if (other.name == "shield-13")
                {
                    GameObject objm = GameObject.Find("Wrong_Right");
                    SpriteRenderer objmsr = objm.GetComponent<SpriteRenderer>();
                    objmsr.enabled = true;

                }
            }
            #endregion

        }
	}

	void OnBecameInvisible()
	{
		Destroy (gameObject);
	}
}
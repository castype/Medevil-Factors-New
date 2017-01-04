using UnityEngine;
using System.Collections;

public class EquationHandler : MonoBehaviour {


    private GameObject sign;
    private Rigidbody2D signRidigBody2D;
    private SpriteRenderer sr;

	// Use this for initialization
	void Start () {
        sign = GameObject.Find("MathProblemSign");
        signRidigBody2D = sign.GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (signRidigBody2D.velocity.y == 0 && signRidigBody2D.position.y < 6.8f)
        {
            

            if (Player_New.Instance.equationNum == 1)
            {
                GameObject equation = GameObject.Find("equation1");
                SpriteRenderer equationsr = equation.GetComponent<SpriteRenderer>();
                equationsr.enabled = true;

                GameObject shieldLeft = GameObject.Find("shield-40");
                SpriteRenderer srLeft = shieldLeft.GetComponent<SpriteRenderer>();
                srLeft.enabled = true;

                GameObject shieldMiddle = GameObject.Find("shield-9");
                SpriteRenderer srMiddle = shieldMiddle.GetComponent<SpriteRenderer>();
                srMiddle.enabled = true;

                GameObject shieldRight = GameObject.Find("shield-21");
                SpriteRenderer srRight = shieldRight.GetComponent<SpriteRenderer>();
                srRight.enabled = true;
            }

            if (Player_New.Instance.equationNum == 2)
            {
                GameObject equation = GameObject.Find("equation2");
                SpriteRenderer equationsr = equation.GetComponent<SpriteRenderer>();
                equationsr.enabled = true;

                GameObject shieldLeft = GameObject.Find("shield-2");
                SpriteRenderer srLeft = shieldLeft.GetComponent<SpriteRenderer>();
                srLeft.enabled = true;
                BoxCollider2D bcl = shieldLeft.GetComponent<BoxCollider2D>();
                bcl.enabled = true;

                GameObject shieldMiddle = GameObject.Find("shield-16");
                SpriteRenderer srMiddle = shieldMiddle.GetComponent<SpriteRenderer>();
                srMiddle.enabled = true;
                BoxCollider2D bcm = shieldMiddle.GetComponent<BoxCollider2D>();
                bcm.enabled = true;

                GameObject shieldRight = GameObject.Find("shield-4");
                SpriteRenderer srRight= shieldRight.GetComponent<SpriteRenderer>();
                srRight.enabled = true;
                BoxCollider2D bcr = shieldRight.GetComponent<BoxCollider2D>();
                bcr.enabled = true;
            }

            if (Player_New.Instance.equationNum == 3)
            {
                GameObject equation = GameObject.Find("equation3");
                SpriteRenderer equationsr = equation.GetComponent<SpriteRenderer>();
                equationsr.enabled = true;

                GameObject shieldLeft = GameObject.Find("shield-23");
                SpriteRenderer srLeft = shieldLeft.GetComponent<SpriteRenderer>();
                srLeft.enabled = true;
                BoxCollider2D bcl = shieldLeft.GetComponent<BoxCollider2D>();
                bcl.enabled = true;

                GameObject shieldMiddle = GameObject.Find("shield-30");
                SpriteRenderer srMiddle = shieldMiddle.GetComponent<SpriteRenderer>();
                srMiddle.enabled = true;
                BoxCollider2D bcm = shieldMiddle.GetComponent<BoxCollider2D>();
                bcm.enabled = true;

                GameObject shieldRight = GameObject.Find("shield-13");
                SpriteRenderer srRight = shieldRight.GetComponent<SpriteRenderer>();
                srRight.enabled = true;
                BoxCollider2D bcr = shieldRight.GetComponent<BoxCollider2D>();
                bcr.enabled = true;
            }
        }


	}
}

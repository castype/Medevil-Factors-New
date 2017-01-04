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
            sr.enabled = true;
        }


	}
}

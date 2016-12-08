using UnityEngine;
using System.Collections;

public class LaunchCatapult : MonoBehaviour {

    public float launchSpeedX;
    public float launchSpeedY;
    private Transform direction = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        SwingCatapult swingCatapult = gameObject.GetComponent<SwingCatapult>();
        swingCatapult.activateR = true;
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        //Player_New.Instance.Jump = true;
        //Player_New.Instance.MyRigidbody.AddForce(new Vector2(launchSpeedX * 10, launchSpeedY));

        Player_New.Instance.MyRigidbody.AddForce(Vector3.up * 500);
        Player_New.Instance.MyRigidbody.AddRelativeForce (Vector3.forward * 100);
        
    }
}

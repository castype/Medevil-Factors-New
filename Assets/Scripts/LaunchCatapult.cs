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


}

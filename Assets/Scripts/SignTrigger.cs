using UnityEngine;
using System.Collections;

public class SignTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            var t = 7;
        }

        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy")
        {
            var t3 = 7;
        }
        
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            var t = 7;
        }


    }



    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            var t = 7;
        }


    }


}

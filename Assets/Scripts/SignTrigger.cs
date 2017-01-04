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

        }

        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy")
        {

        }
        
    }

    public void OnTriggerExit(Collider other)
    {

    }



    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

        }


    }


}

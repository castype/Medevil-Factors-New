using UnityEngine;
using System.Collections;

public class SignTrigger : MonoBehaviour {


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gameObject.SetActive(false);
        }
        
    }



}

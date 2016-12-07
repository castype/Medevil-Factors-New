using UnityEngine;
using System.Collections;

public class GroundEdgeCollider : MonoBehaviour
{


    void OnCollisionEnter2D(Collision2D coll)
    {
        //this is all overkill, but I am just ensuring nothing is still happening when the edge collider is hit
        Animator animator = Player_New.Instance.MyAnimator;
        Player_New player = Player_New.Instance;

        animator.SetBool("land", false);
        animator.ResetTrigger("jump");
        animator.ResetTrigger("reset");
        
        player.Jump = false;
        player.OnGround = true;

    }


}
using UnityEngine;
using System.Collections;

public class AnswerHandler3 : MonoBehaviour
{


    private float delay = 1.5f;
    private float timeRemaining;
    SpriteRenderer spriteRenderer;

    void FixedUpdate()
    {

        if (spriteRenderer.enabled == true)
        {

            if (timeRemaining > 0)
            {
                // Reduce the remaining time by time passed since last update (frame)
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = delay;
                if (Player_New.Instance.equationNum == 3)
                {
                    GameObject objm = GameObject.Find("Correct_Middle");
                    SpriteRenderer objmsr = objm.GetComponent<SpriteRenderer>();
                    objmsr.enabled = false;

                    GameObject objl = GameObject.Find("Wrong_Left");
                    SpriteRenderer objlsr = objl.GetComponent<SpriteRenderer>();
                    objlsr.enabled = false;

                    GameObject objr = GameObject.Find("Wrong_Right");
                    SpriteRenderer objrsr = objr.GetComponent<SpriteRenderer>();
                    objrsr.enabled = false;

                    GameObject equation = GameObject.Find("equation3");
                    SpriteRenderer equationsr = equation.GetComponent<SpriteRenderer>();
                    equationsr.enabled = false;

                    GameObject shield23 = GameObject.Find("shield-23");
                    shield23.SetActive(false);

                    GameObject shield30 = GameObject.Find("shield-30");
                    shield30.SetActive(false);

                    GameObject shield13 = GameObject.Find("shield-13");
                    shield13.SetActive(false);

                    Player_New.Instance.equationNum = 0;
                    timeRemaining = delay;

                    GameObject door = GameObject.Find("door");
                    //door.SetActive(false);

                    Rigidbody2D rigidbody = door.GetComponent<Rigidbody2D>();
                    rigidbody.velocity = new Vector2(0.5f, -0.30f);

                    

                }

            }
        }
    }

    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        timeRemaining = delay;
    }




}

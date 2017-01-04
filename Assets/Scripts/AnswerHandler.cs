using UnityEngine;
using System.Collections;

public class AnswerHandler : MonoBehaviour {


    private float delay = 1.5f;
    private float timeRemaining;
    SpriteRenderer spriteRenderer;

    void FixedUpdate()
    {

        if (spriteRenderer.enabled == true && Player_New.Instance.equationNum == 1)
        {

            if (timeRemaining > 0)
            {
                // Reduce the remaining time by time passed since last update (frame)
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = delay;

                    GameObject objl = GameObject.Find("Correct_Left");
                    SpriteRenderer objlsr = objl.GetComponent<SpriteRenderer>();
                    objlsr.enabled = false;

                    GameObject objm = GameObject.Find("Wrong_Middle");
                    SpriteRenderer objmsr = objm.GetComponent<SpriteRenderer>();
                    objmsr.enabled = false;

                    GameObject objr = GameObject.Find("Wrong_Right");
                    SpriteRenderer objrsr = objr.GetComponent<SpriteRenderer>();
                    objrsr.enabled = false;

                    GameObject equation = GameObject.Find("equation1");
                    SpriteRenderer equationsr = equation.GetComponent<SpriteRenderer>();
                    equationsr.enabled = false;

                    GameObject shield40 = GameObject.Find("shield-40");
                    shield40.SetActive(false);

                    GameObject shield9 = GameObject.Find("shield-9");
                    shield9.SetActive(false);

                    GameObject shield21 = GameObject.Find("shield-21");
                    shield21.SetActive(false);

                    Player_New.Instance.equationNum = 2;
                    timeRemaining = delay;
                

            }
        }
    }

    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        timeRemaining = delay;
    }




}

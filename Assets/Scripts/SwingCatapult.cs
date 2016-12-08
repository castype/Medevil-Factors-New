using UnityEngine;
using System.Collections;

public class SwingCatapult : MonoBehaviour
{
    [SerializeField]
    public float angle;

    [SerializeField]
    public float speed ;

    public bool activateR;

    public bool activateL;

    Quaternion qStart, qEnd;

    private float startTime;

    private static bool swingEngaged;

    void Start()
    {
        activateR = false;
        activateL = false;
        qStart = Quaternion.AngleAxis(-angle, Vector3.forward);
        qEnd = Quaternion.AngleAxis(4.93f, Vector3.forward);
        swingEngaged = false;

    }

    void FixedUpdate()
    {

        if (activateR == true)
        {
            startTime += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(qStart, qEnd, (Mathf.Sin(startTime * speed + Mathf.PI / 2) + 1.0f) / 2.0f);
        }

        if (transform.rotation.eulerAngles.z > 350)
        {
            swingEngaged = true;
        }

        if (transform.rotation.eulerAngles.z < 5f && swingEngaged && transform.rotation.eulerAngles.z > 4.4f)
        {
            activateR = false;
            resetSwing();

        }

    }

    void resetSwing()
    {
        startTime = 0.0f;
        swingEngaged = false;
        activateR = false;
        activateL = false;
        qStart = Quaternion.AngleAxis(-angle, Vector3.forward);
        qEnd = Quaternion.AngleAxis(4.93f, Vector3.forward);
        swingEngaged = false;
    }

    
}
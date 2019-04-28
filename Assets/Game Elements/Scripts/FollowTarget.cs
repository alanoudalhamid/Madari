using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{

    public Transform target;
    public float speed;
    private float Timer;
    // Use this for initialization
    void Start()
    {
        Timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - Timer > 4)
        {
            Debug.Log(Vector3.Distance(transform.position, target.position));
            if (Vector2.Distance(transform.position, target.position) > 3)
            {
                Debug.Log("in if case");
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x, target.position.y, target.position.z), speed * Time.deltaTime);
            }
        }
    }
}

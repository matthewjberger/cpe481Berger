using System;
using UnityEngine;
using System.Collections;

public class Beard : MonoBehaviour
{
    public static Beard S;
    private Rigidbody2D rigidBody;
    private ParticleSystem ps;

    // Use this for initialization
    void Start ()
    {
        S = this;
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.right;
        ps = GetComponentInChildren<ParticleSystem>();
    }
    
    // Update is called once per frame
    void Update ()
    {

        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
        
        //if ( Input.GetTouch(0).tapCount > 0 )
        foreach(var i in Input.touches)
        {
            if (i.phase == TouchPhase.Began)
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, 2);
            }
        }

        if (Math.Abs(rigidBody.position.y) > ((GetComponent<Renderer>().bounds.size.y/2) + 1) ) Die();
    }

    void Die()
    {
        transform.position = Vector2.zero;
        rigidBody.velocity = Vector2.right;
        var pstmp = Instantiate(ps);
        Destroy(ps);
        ps = pstmp;
        ps.transform.parent = transform;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Fatal")
        {
            Die();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    Rigidbody rigid;
    //bool grounded = false;
    float jumppower = 350;
    bool jumptrigger = false;
    float movespeed = 5;
    public GameObject bullet;
    // Use this for initialization
    void Start () {
        rigid = this.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (GridManager.gameover)
        {
            Destroy(this);
        }
        rigid.velocity = rigid.velocity - new Vector3(rigid.velocity.x, 0, 0);
        if (jumptrigger && Mathf.Abs(rigid.velocity.y) < 0.001f)
        {
            jumptrigger = false;
            rigid.AddForce(0, jumppower, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (rigid.velocity.x > -movespeed)
            {
                rigid.velocity = rigid.velocity + new Vector3(-movespeed, 0, 0);
                transform.position = transform.position + new Vector3(0, 0.00001f, 0);
            }
            //transform.position = transform.position - new Vector3(0.1f, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (rigid.velocity.x < movespeed)
            {
                rigid.velocity = rigid.velocity + new Vector3(movespeed, 0, 0);
                transform.position = transform.position + new Vector3(0, 0.00001f, 0);
            }
            //transform.position = transform.position - new Vector3(-0.1f, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            //Debug.Log(rigid.velocity.y);
            if(Mathf.Abs(rigid.velocity.y)<0.001f){
                jumptrigger = true;
                //rigid.AddForce(0, jumppower, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position + new Vector3(0, 1.3f, 0), Quaternion.identity);
        }
    }
}

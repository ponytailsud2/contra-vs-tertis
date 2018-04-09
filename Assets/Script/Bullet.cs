using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    Rigidbody rigid;
	// Use this for initialization
	void Start () {
        rigid = this.GetComponent<Rigidbody>();
        rigid.velocity = new Vector3 (0, 10, 0);
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}

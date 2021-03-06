﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prebuilt_Tile : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Vector2 v = GridManager.V2round(transform.position);
        GridManager.grid[(int)v.x, (int)v.y] = transform;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Vector2 v = GridManager.Locate(transform);
            GridManager.grid[(int)v.x, (int)v.y] = null;
            Destroy(gameObject);
        }
    }
}

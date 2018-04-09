using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unplayable_Solo : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Vector2 v = GridManager.V2round(transform.position);
        GridManager.grid[(int)v.x, (int)v.y] = transform;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

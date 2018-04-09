using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal_Tile : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
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

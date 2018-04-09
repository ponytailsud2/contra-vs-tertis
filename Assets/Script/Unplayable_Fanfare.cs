using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unplayable_Fanfare : MonoBehaviour {

    public GameObject unplayTile;
	// Use this for initialization
	void Start () {
		for(int i = 0; i < 30; i++)
        {
            for(int j = 0; j < 30; j++)
            {
                if (i < 20 && i > 9 && j > 9)
                {

                }
                else
                {
                    GameObject o = Instantiate(unplayTile, transform.position + new Vector3(i,j,0), Quaternion.identity);
                    o.transform.SetParent(this.transform);
                    GridManager.grid[i, j] = o.transform;
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

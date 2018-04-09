using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour {

    public GameObject[] groups;
    public GameObject[] blocks;
	// Use this for initialization
	void Start () {
        spawnNext();
	}
	
	// Update is called once per frame
	void Update () {
        if (GridManager.gameover)
        {
            enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void spawnNext()
    {
        //Debug.Log("Called");
        // Random Index
        int g = Random.Range(0, groups.Length);

        // Spawn Group at current Position
        GameObject spawned = Instantiate(groups[g],transform.position,Quaternion.identity);
        //GameObject child = spawned.transform.GetChild(0).gameObject;
        //UnityEngine.Object.Destroy(child);
        for(int i = 0; i < spawned.transform.childCount; i++)
        {
            g = Random.Range(0, 2);
            if(g == 1)
            {
                GameObject spawnblock = spawned.transform.GetChild(i).gameObject;
                GameObject respawnblock = Instantiate(blocks[1], spawnblock.transform.position, Quaternion.identity);
                respawnblock.transform.SetParent(spawned.transform);
                spawnblock.transform.SetParent(null);
                UnityEngine.Object.Destroy(spawnblock);
                respawnblock.transform.SetSiblingIndex(i);
            }
            if(g == 0)
            {
                GameObject spawnblock = spawned.transform.GetChild(i).gameObject;
                GameObject respawnblock = Instantiate(blocks[0], spawnblock.transform.position, Quaternion.identity);
                respawnblock.transform.SetParent(spawned.transform);
                spawnblock.transform.SetParent(null);
                UnityEngine.Object.Destroy(spawnblock);
                respawnblock.transform.SetSiblingIndex(i);
            }
        }
    }
}

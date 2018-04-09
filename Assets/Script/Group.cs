using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group : MonoBehaviour {

    float lastFall = 0;
	// Use this for initialization
	void Start () {
        if (!IsValidGridPos())
        {
            Debug.Log("Spawner flooded");
            GridManager.GameOver();
        }
	}

    // Update is called once per frame
    void Update()
    {
        if (GridManager.gameover)
        {
            enabled = false;
        }
        if(transform.childCount == 0)
        {
            FindObjectOfType<Spawner>().spawnNext();
            enabled = false;
        }
        // Move Left
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // Modify position
            transform.position += new Vector3(-1, 0, 0);

            // See if valid
            if (IsValidGridPos())
                // It's valid. Update grid.
                UpdateGrid();
            else
                // It's not valid. revert.
                transform.position += new Vector3(1, 0, 0);
        }

        // Move Right
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // Modify position
            transform.position += new Vector3(1, 0, 0);

            // See if valid
            if (IsValidGridPos())
                // It's valid. Update grid.
                UpdateGrid();
            else
                // It's not valid. revert.
                transform.position += new Vector3(-1, 0, 0);
        }

        // Rotate
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Rotate(0, 0, -90);

            // See if valid
            if (IsValidGridPos())
                // It's valid. Update grid.
                UpdateGrid();
            else
                // It's not valid. revert.
                transform.Rotate(0, 0, 90);
        }

        // Move Downwards and Fall
        else if (Input.GetKeyDown(KeyCode.DownArrow) ||
                 Time.time - lastFall >= 1)
        {
            //Debug.Log(this.transform.childCount);
            // Modify position
            transform.position += new Vector3(0, -1, 0);
            // See if valid
            if (IsValidGridPos())
            {
                // It's valid. Update grid.
                UpdateGrid();
            }
            else
            {
                // It's not valid. revert.
                transform.position += new Vector3(0, 1, 0);

                // Clear filled horizontal lines
                while (GridManager.Sandslide())
                {
                    //Debug.Log("Sandslide");
                }

                GridManager.DeleteFullRows();

                // Spawn next Group
                //Debug.Log("Called");
                FindObjectOfType<Spawner>().spawnNext();

                // Disable script
                this.enabled = false;
            }

            lastFall = Time.time;
        }
    }

    bool IsValidGridPos()
    {
        foreach (Transform child in transform)
        {
            Vector2 v = GridManager.V2round(child.position);
            //Debug.Log(v);
            // Not inside Border?
            if (!GridManager.Insideborder(v))
            {
                return false;
            }

            // Block in grid cell (and not part of same group)?
            if (GridManager.grid[(int)v.x, (int)v.y] != null &&
                GridManager.grid[(int)v.x, (int)v.y].parent != transform)
            {
                return false;
            }
        }
        return true;
    }

    void UpdateGrid()
    {
        // Remove old children from grid
        for (int y = 0; y < GridManager.height; ++y)
            for (int x = 0; x < GridManager.width; ++x)
                if (GridManager.grid[x, y] != null)
                    if (GridManager.grid[x, y].parent == transform)
                        GridManager.grid[x, y] = null;

        // Add new children to grid
        foreach (Transform child in transform)
        {
            Vector2 v = GridManager.V2round(child.position);
            GridManager.grid[(int)v.x, (int)v.y] = child;
        }
    }
}

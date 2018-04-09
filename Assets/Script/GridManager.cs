using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {

    public static int width = 30;
    public static int height = 30;
    public static Transform[,] grid = new Transform[width, height];
    public static bool gameover = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public static Vector2 V2round(Vector2 v)
    {
        return new Vector2(Mathf.Round(v.x),Mathf.Round(v.y));
    }

    public static bool Insideborder(Vector2 pos)
    {
        return ((int)pos.x >= 0 &&
            (int)pos.x < width &&
            (int)pos.y >= 0);
    }

    public static void DeleteRow(int y)
    {
        for (int x = 0; x < width; ++x)
        {
            if (grid[x,y].tag != "Unplayable") {
            Destroy(grid[x, y].gameObject);
            grid[x, y] = null;
            }
        }
    }

    public static void DecreaseRow(int y)
    {
        for (int x = 0; x < width; ++x)
        {
            if (grid[x, y] != null && grid[x , y-1] == null && grid[x,y].gameObject.tag != "Unplayable")
            {
                // Move one towards bottom
                grid[x, y - 1] = grid[x, y];
                grid[x, y] = null;

                // Update Block position
                grid[x, y - 1].position += new Vector3(0, -1, 0);
            }
        }
    }

    public static void DecreaseRowsAbove(int y)
    {
        for (int i = y; i < height; ++i)
            DecreaseRow(i);
    }

    public static bool IsRowFull(int y)
    {
        for (int x = 0; x < width; ++x)
            if (grid[x, y] == null)
                return false;
        return true;
    }

    public static bool IsUnplayableRow(int y)
    {
        for (int x = 0; x < width; ++x)
            if (grid[x, y] == null || grid[x,y].tag != "Unplayable")
                return false;
        return true;
    }

    public static void DeleteFullRows()
    {
        for (int y = 0; y < height; ++y)
        {
            if (IsRowFull(y) && !IsUnplayableRow(y))
            {
                DeleteRow(y);
                DecreaseRowsAbove(y + 1);
                --y;
            }
        }
    }

    public static Vector2 Locate(Transform t)
    {
        return V2round(t.position);
    }

    public static void GameOver()
    {
        Time.timeScale = 0;
        gameover = true;
    }

    public static bool Sandslide()
    {
        bool moved = false;
        for (int j = 1; j < height; ++j)
        {
            for (int i = 0; i < width; ++i)
            {
                if(grid[i,j] != null && grid[i, j].gameObject.tag == "Sand" && grid[i, j - 1] == null)
                {
                    // Move one towards bottom
                    grid[i, j - 1] = grid[i, j];
                    grid[i, j] = null;

                    // Update Block position
                    grid[i, j - 1].position += new Vector3(0, -1, 0);
                    moved = true;
                }
            }
        }
        return moved;
    }
}

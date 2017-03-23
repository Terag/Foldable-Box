using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoardManager : MonoBehaviour
{

    [SerializeField]
    private GameObject tileContainer;

    [SerializeField]
    private GameObject[] tiles;

    private GameObject[,] tileTable;

    public static BoardManager Instance;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple Instance of BoardManager");
        }
        else
        {
            Instance = this;
        }
    }

    // Use this for initialization
    void Start () {
        tileTable = new GameObject[10,10];
        for(int i = 0; i < 10; i++)
        {
            for(int j = 0; j < 10; j++)
            {
                instantiateTile(i, j);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void instantiateTile(int x, int y)
    {
        tileTable[x, y] = (GameObject)Instantiate(tiles[Mathf.RoundToInt(Random.Range(0f, tiles.Length - 1))], 
                                                        new Vector3(x - 4.5f, 5f, y - 4.5f), 
                                                        Quaternion.identity);
        if (tileContainer != null)
        {
            tileTable[x, y].gameObject.transform.parent = tileContainer.transform;
        }
    }

    public GameObject getTile(int x, int y)
    {
        return tileTable[x,y];
    }

    public void flash(int x, int y, float intensity = 0.5f)
    {
        tileTable[x, y].GetComponent<Tile>().flash(intensity);
    }

    public void resetFlash(int x, int y)
    {
        tileTable[x, y].GetComponent<Tile>().resetFlashing();
    }
}

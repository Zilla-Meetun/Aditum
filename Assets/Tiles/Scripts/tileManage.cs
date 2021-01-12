using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileManage : MonoBehaviour
{
    public GameObject GrassT;
    public GameObject IceT;
    public GameObject Block;
    public GameObject StartT;
    public GameObject EndT;
    public GameObject WallT;
    public level Level;

    
    private GameObject[,] levelGrid;

    private void Awake()
    {
        Level.Setlevel1();
        levelGrid = new GameObject[Level.rows, Level.columns];

    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("running");
        GenerateTerrain();
    }
    private void PopulateGrid()
    {
        
    }
    private void GenerateTerrain()
    { 
        for (int x = 0; x < Level.rows; x++)
            for (int z = 0; z < Level.columns; z++)
            {
                Debug.Log("generating");
                if (Level.levelGrid[x,z] == 'G' && GrassT)
                {
                    levelGrid[x,z] = Instantiate(GrassT, new Vector3(x, 0, z), Quaternion.identity);
                }
                else if (Level.levelGrid[x, z] == 'I' && IceT)
                {
                    levelGrid[x, z] = Instantiate(IceT, new Vector3(x, 0, z), Quaternion.identity);
                }
                else if (Level.levelGrid[x, z] == 'S' && StartT)
                {
                    levelGrid[x, z] = Instantiate(StartT, new Vector3(x, 0, z), Quaternion.identity);
                }
                else if (Level.levelGrid[x, z] == 'E' && EndT)
                {
                    levelGrid[x, z] = Instantiate(EndT, new Vector3(x, 0, z), Quaternion.identity);
                }
                else if (Level.levelGrid[x, z] == 'W' && WallT)
                {
                    levelGrid[x, z] = Instantiate(WallT, new Vector3(x, 0, z), Quaternion.identity);
                }
                else if (Level.levelGrid[x, z] == ' ')
                {
                    Debug.Log("emptySpace");
                }
                else
                {
                    Debug.Log("lastresort");
                    levelGrid[x, z] = Instantiate(GrassT, new Vector3(x, 0, z), Quaternion.identity);
                }
            }
        
    }
    private void ClearTiles()
    {
        foreach (GameObject o in levelGrid)
        {
            Destroy(o);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

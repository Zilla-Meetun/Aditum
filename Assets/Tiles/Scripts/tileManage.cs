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

    [SerializeField] GameObject Player;
    
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
        SetPlayer();
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
                    Level.startX = x; Level.startY = z;
                }
                else if (Level.levelGrid[x, z] == 'E' && EndT)
                {
                    levelGrid[x, z] = Instantiate(EndT, new Vector3(x, 0, z), Quaternion.identity);
                }
                else if (Level.levelGrid[x, z] == 'W' && WallT)
                {
                    levelGrid[x, z] = Instantiate(WallT, new Vector3(x, 0, z), Quaternion.identity);
                    Level.endX = x; Level.endY = z;
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

    public void SetPlayer()
    {
        if (FindObjectOfType<PlayerControlls>())
        {
            Player.transform.position = new Vector3(Level.startX, 1, Level.startY);
            Player.GetComponent<PlayerControlls>().Level = Level;
        }
        else
        {
            Player = Instantiate(Player, new Vector3(Level.startX, 1, Level.startY), Quaternion.identity);
            Player.GetComponent<PlayerControlls>().Level = Level;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.x < -1 ||
            Player.transform.position.x  > Level.rows +1||
            Player.transform.position.z < -1 ||
            Player.transform.position.z > Level.columns+1||
            Player.transform.position.y < -200)
        {
            Vector3 Start = new Vector3(Level.startX, 1, Level.startY);
            Player.transform.position = Start;

            Debug.Log("FAllEN" +  Start);
        }
    }
}

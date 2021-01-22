using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlls : MonoBehaviour
{
    private float Speed = 0.06f;
    private CharacterController ChaCont;
    private GameObject player;

    

    public level Level;
    private bool startSaved = false;
    private bool InputMade = false;

    private Vector3 CurrentPos, NewPos, Direction;
    private Vector3 Gravity = new Vector3(0, -9, 0);
    private bool OutOfBounds()
    {
        return (player.transform.position.x < -1 ||
             player.transform.position.x > Level.rows + 1 ||
             player.transform.position.z < -1 ||
             player.transform.position.z > Level.columns + 1 ||
             player.transform.position.y < -200);
    }
    // Start is called before the first frame update
    private void Awake()
    {
        player = this.gameObject;
        ChaCont = player.GetComponent<CharacterController>();
        
    }
    void Start()
    {
        
    }
  
    public void Moving()
    {
        
        if (!InputMade)
        {
            if (Input.GetAxis("Vertical") > 0)// Up
            {
                Direction = new Vector3(-1, 0, 0);
                NewPos = CurrentPos + Direction; InputMade = true;
            }
            if (Input.GetAxis("Vertical") < 0)// Down
            {
                Direction = new Vector3(1, 0, 0);
                NewPos = CurrentPos + Direction; InputMade = true;
            }
            if (Input.GetAxis("Horizontal") > 0) // Right
            {
                Direction = new Vector3(0, 0, 1);
                NewPos = CurrentPos + Direction; InputMade = true;
                
            }
            if (Input.GetAxis("Horizontal") < 0) // Left
            {
                Direction = new Vector3(0, 0, -1);
                NewPos = CurrentPos + Direction; InputMade = true;
            }
            
        }
        else
        {
            
            
         this.transform.position = Vector3.Lerp(CurrentPos, NewPos, Speed);

        if (Level.IsIce((int)NewPos.x, (int)NewPos.z))
        {
            NewPos += Direction;
        }

            
        if (Vector3.Distance(this.transform.position, NewPos) < 0.01f)
        {
            if (this.transform.position == NewPos)
            {
                InputMade = false;
                Debug.Log("Move Complete");
            }
            this.transform.position = NewPos;
            CurrentPos = NewPos;


        }
        }

    }
        
    
    
    // Update is called once per frame
    void Update()
    {
        if (!startSaved && ChaCont.isGrounded)
        {
            CurrentPos = this.transform.position;
            startSaved = true;
        }
        ChaCont.SimpleMove(Gravity);
        CurrentPos = this.gameObject.transform.position;

        if(startSaved)
            Moving();

        if (OutOfBounds())
        {
            player.transform.position = new Vector3(Level.startX, 1, Level.startY);
            startSaved = false;
        }
        
        
    }
}

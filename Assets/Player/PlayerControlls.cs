using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlls : MonoBehaviour
{
    private float Speed = 0.06f;
    private CharacterController ChaCont;
    private GameObject player;

    private static readonly Vector3 Up = new Vector3(-1, 0, 0);
    private static readonly Vector3 Down = new Vector3(1, 0, 0);
    private static readonly Vector3 Right = new Vector3(0, 0, 1);
    private static readonly Vector3 Left = new Vector3(0, 0, -1);

    public level Level;
    private bool startSaved = false;
    private bool InputMade = false;

    private Vector3 CurrentPos, NewPos, Direction;
    private Vector3 Gravity = new Vector3(0, -9, 0);
    
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
            if (!Level.OutBounds((int)CurrentPos.x, (int)CurrentPos.z))
            {
                if (Input.GetAxis("Vertical") > 0)// Up
                {
                    Direction = Up;
                    NewPos = CurrentPos + Direction; InputMade = true;
                }
                if (Input.GetAxis("Vertical") < 0)// Down
                {
                    Direction = Down;
                    NewPos = CurrentPos + Direction; InputMade = true;
                }
                if (Input.GetAxis("Horizontal") > 0) // Right
                {
                    Direction = Right;
                    NewPos = CurrentPos + Direction; InputMade = true;

                }
                if (Input.GetAxis("Horizontal") < 0) // Left
                {
                    Direction = Left;
                    NewPos = CurrentPos + Direction; InputMade = true;
                }
            }
        }
        else
        {

            CurrentPos = this.gameObject.transform.position;
            this.transform.position = Vector3.Lerp(CurrentPos, NewPos, Speed);

            if (Level.IsIce((int)NewPos.x, (int)NewPos.z))
            {
                Debug.DrawLine(CurrentPos, NewPos);
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
        if ((!startSaved && ChaCont.isGrounded) || this.transform.position.y < CurrentPos.y)
        {
            CurrentPos = this.transform.position;
            startSaved = true;
        }
        ChaCont.SimpleMove(Gravity);

        
        if(startSaved)
            Moving();

        if (this.transform.position.y < -100)
        {
            player.transform.position = new Vector3(Level.startX, 1, Level.startY);
            startSaved = false;
            InputMade = false;
            Direction = Vector3.zero;

        }
        
        
    }
}

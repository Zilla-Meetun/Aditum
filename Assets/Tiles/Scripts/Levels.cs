using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct level 
{
    public int rows;
    public int columns;
    public int startX;
    public int endX;
    public int startY;
    public int endY;
    public char[,] levelGrid;

    //KEY!!!!
    //G = Grass
    //I = Ice
    //  = Nothing
    //S = Start
    //E = End
    public void Setlevel1()
    {
        rows = 3;
        columns = 3;
        levelGrid = new char[3, 3] { 
            { 'S', 'G', 'G' },
            { 'G', 'G', 'G' }, 
            { 'I', ' ', 'E' }
                                    };
        
    }
    
}
   


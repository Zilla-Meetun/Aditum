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
    public int LVLIndex;
    //KEY!!!!
    //G = Grass
    //I = Ice
    //  = Nothing
    //S = Start
    //E = End
    private bool OutOfBounds(int x, int z)
    {
        if (x >= rows || z >= columns || x < 0 || z < 0)
            return true;
        return false;
    }
    public bool IsIce(int x, int z)
    {
        if (!OutOfBounds(x, z) && levelGrid[x, z] == 'I')
            return true;
        return false;
    }
    
    public void Setlevel1()
    {
        rows = 4;
        columns = 4;
        levelGrid = new char[4, 4] { 
            { 'I', 'G', 'G', 'I' },
            { 'G', 'G', 'G', 'I' }, 
            { 'S', 'G', 'G', 'I' },
            { 'G', 'I', 'I', 'G' }
                                    };
        
    }
    
}
   


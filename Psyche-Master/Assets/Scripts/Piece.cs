using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Collections.ObjectModel;



public class Piece : MonoBehaviour
{
    public const double RANDOM_INCREMENT = 0.1428571428571429‬;
    public const int ROWS = 3;
    public const int COLS = 3;

    public const Vector2Int OffScreen = new Vector2Int(1000000,1000000);

    public static int[,] L =  {{1,0,0},
                               {1,0,0},          
                               {1,1,0}};

    public static int[,] LMirror = {{0,0,1},
                                   {0,0,1},          
                                   {0,1,1}};

    public static int[,] Z = {{0,0,1},
                              {0,1,1},          
                              {0,1,0}};
  
    public static int[,] ZMirror = {{1,0,0},
                                    {1,1,0},          
                                    {0,1,0}};

    public static int[,] Line = {{0,1,0},
                                 {0,1,0},         
                                 {0,1,0}};

    public static int[,] Blck = {{0,0,0},
                                 {1,1,0},          
                                 {1,1,0}};

    public static int[,] T = {{0,0,0},
                             {0,1,0},          
                             {1,1,1}};

    public static int [][,]shapeList = {L, LMirror, Z, ZMirror, Line, Blck, T};
                                    
    public enum Shape
    {
        L = 4,
        LMirror = 8,
        Z = 128,
        ZMirror = 256,
        Line = 512,
        Block = 1024,
        T = 2056
    }

    Tile [,]tiles;
    Shape type;
    Vector2 pos;
    Vector2 xyMax;
    Vector2 xyMin;
    bool mixed;
    UInt16 count;
    float cooldown;
    
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        Array tileVals = Enum.GetValues(typeof(TileType));
        System.Random random = new System.Random();

        ;

        tiles = DecideTiles(false, shapeList[(int)tileVals.GetValue(random.Next(tileVals.Length))]);

        cooldown = 1000f;//one second, 1000 ms     
    }
    
    //drop individual tiles for a piece by their height, which will be considered one unit
    bool Fall(Piece p)
    {
        for(int i = 0; i < COLS; i++)
        {
            for(int j = 0; j < ROWS; j++)
            {
                if(p.tiles[i,j] != null)
                {
                    p.tiles[i,j].pos.y += p.tiles[i,j].height;
                }
            }        
        }
    }

    //Decide how tiles will be generated
    Tile[,] DecideTiles(bool mixed, int [,]s)
    {
        Tile [,] shape = new Tile[COLS,ROWS];

        for(int i = 0; i < COLS; i++)
        {
            for(int j = 0; j < ROWS; j++)
            {
                if(s[i,j] == 0)
                {
                    shape[i,j] = null;

                    continue;
                }
                else
                {
                    shape[i,j] = new Tile();

                    Array tileVals = Enum.GetValues(typeof(TileType));
                    System.Random random = new System.Random();

                    shape[i,j].type = (TileType)tileVals.GetValue(random.Next(tileVals.Length));
                    shape[i,j].sprite = shape[i,j].ChooseSpriteForTile(shape[i,j].GetTileType());

                    continue;
                }
            }
        }


        
        

        return t;
    }
}

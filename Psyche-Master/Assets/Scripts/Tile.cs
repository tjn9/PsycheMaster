using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

   public enum TileType
   {
       Invalid = 0,
       Positivity = 1,
       Stability = 2,
       Fortitude = 4
   }

public class Tile : MonoBehaviour
{
    public TileType type;
    public UInt16 width,  height;
    public Vector2 pos;
    public Sprite sprite;

    public void Start()
    {
        Vector2 offset = new Vector2(width, height);
        pos = Piece.OffScreen + offset;

    }

   public void SetType(TileType tp)
   {
       this.type = tp;
   }

    public TileType GetTileType()
   {
       return this.type;
   }

   public Sprite ChooseSpriteForTile(TileType t)
   {
       switch(t)
       {
           case TileType.Positivity:
               return Resources.Load<Sprite>("pSprite");

           case TileType.Stability:
               return Resources.Load<Sprite>("sSprite");

           case TileType.Fortitude:
               return Resources.Load<Sprite>("fSprite");

           default:
               return null;
       }
   }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private bool isVisible;
    private bool hasMine;
    private bool hasFlag;
    private int value;
    private bool collapsed;

    public bool PlayerMoveCheck() //false denotes a game over due to stepping on a mine
    {
        if (hasMine && hasFlag) //Tile is mined but flagged, so it's travelable
            return true;

        if (hasMine) //Game over!
            return false;

        if (!collapsed) //Tile is stepped on, and has never been traveled on before
            collapsed = true;

        return true;
    }

    public void DisplayValue()
    {
        //TODO: BoardManager calls this to tell the tile to display it's value
    }

    public void Flag()
    {
        hasFlag = true;
        //TODO: Logic to visually spawn a flag
    }

    public void IncrementValue() //Called by board manager when an adjacent mine is discovered
    {
        value++;
    }
}

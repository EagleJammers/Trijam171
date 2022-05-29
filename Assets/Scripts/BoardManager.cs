using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    //Tile[][] Board;
    //Player p;
    int dimension = 0;
    float minePercent = 20f;

    // Start is called before the first frame update
    void Start()
    {
      //Find Player object
      //Find Mine objects and insert them into Board array
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updatePlayer()
    {
      //Check if player is moving off the board (x or y changing to be > dimension-1 or < 0)
      //Check if Tile has mine and is not Flagged at place player is going
        //if true blow him up
        //reveal every tile
        //else, reveal Tile
        //Update UI to reflect where Player is
    }
}

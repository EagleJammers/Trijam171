using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    private Tile[][] Board;
    private Player p;
    [serializefield]
    private Tile tObj;

    private int dimension = 0;
    private float minePercent = .20f;
    private float minePresent = 0f;

    private float percentbytile = (float) 1 / (dimension * dimension);
    private int tilepermine = (int) dimension * dimension * minePercent;

    // Start is called before the first frame update
    void Start()
    {
      //Find Player object by Tag

      int tilesunmined = 0;
      //Instantiate Mine objects and insert them into Board array
      for(int x;x < dimension;x++)
      {
        for(int y;y<dimensions;y++)
        {
          //Tile t = Instantiate new Tile
          //Board[x][y] = t
          //Move that tile to some place on the UI based on screen size vs how many we have

          //Set Mine flag to true or false based on RNG
            //if set to true
              //minepresent += percentbytile
              //tilesunmined = 0;

            //if set to false
          //if tiles unmined >= tiles permine, set tilesunmined = 0, set mine flag to true
          //else increase tilesunmined by 1

        }
      }
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

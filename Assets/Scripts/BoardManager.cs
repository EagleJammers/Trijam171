using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    private Tile[,] Board;
    [SerializeField]
    private PlayerMovement p;
    [SerializeField]
    private Tile tObj;

    private float minePercent = .20f;
    private float minesPresent = 0f;
    private int tilesunmined = 0;
    private int dimension = 5;
    public float stepsize = 1f;

    private float percentbytile;
    private int tilepermine;

    // Start is called before the first frame update
    void Start()
    {
      Board = new Tile[dimension,dimension];
      percentbytile = (float) 1 / (dimension * dimension);
      tilepermine = (int) (dimension * dimension * minePercent);
      int px = Random.Range(0, dimension);
      int py = Random.Range(0, dimension);


      SpawnMines();


            //Instantiate Player then assign it to p
            p = Object.Instantiate(p, new Vector2(0,0), Quaternion.identity) as PlayerMovement;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnMines(){
      //Instantiate Mine objects and insert them into Board array
      for(int x = 0;x < dimension;x++)
      {
        for(int y = 0;y < dimension;y++)
        {
          Board[x, y] = Object.Instantiate(tObj, new Vector2(0, 0), Quaternion.identity) as Tile;

          //TODO Scale and Move that tile to some place on the UI based on screen size vs how many we have
          Board[x,y].transform.position = new Vector3(stepsize * x, stepsize * y, 0f);

        }
      }

      //Loop to increment tile numbers and assign mines
      for (int x = 0; x < dimension; x++)
      {
        for (int y = 0; y < dimension; y++)
        {
          //Set Mine flag to true or false based on RNG
          //if comparison is true
          if (Random.Range(0f, 1f) < minePercent || tilesunmined >= tilepermine)
          {
              minesPresent += percentbytile;
              tilesunmined = 0;
              Board[x, y].setMine();
              IncrementTiles(x, y);

              // TODO increment neightbor tiles
          }
          //if comparison is false
          else
          {

              //increase tilesunmined by 1
              tilesunmined++;
          }
        }
      }
    }

    public bool UpdatePlayer(Vector2 direction)
    {
      return true;
      //return true if movement is valid
      //return false if movement is invalid
      //game over if the tile is a mine

      //Check if player is moving off the board (x or y changing to be > dimension-1 or < 0)
      //Check if Tile has mine and is not Flagged at place player is going
        //if true blow him up
        //reveal every tile
        //else, reveal Tile
        //Update UI to reflect where Player is
    }

    public void SetFlag(Vector2 input)
    {
      return;
    }

    private void IncrementTiles(int x, int y)
    {
      int hcap = 1+x;
      int vcap = 1+y;

      if(x == 0) x++;
      else if(x == dimension - 1) hcap--;

      if(y==0) y++;
      else if(y == dimension-1) vcap--;


      for(int a = x-1; a < hcap; a++)
      {
        for(int b = y-1; b < vcap; b++)
        {
            Board[a, b].IncrementValue();
        }
      }

    }
    public bool IsValidMove(Vector2 direction)
    {
      //checks whether movement would give index out of bounds error

      return true;
    }
}

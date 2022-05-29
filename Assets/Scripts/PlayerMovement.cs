using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    int stepsize = 1;
    //[SerializeField]
    //BoardManager boardmanager = null;

    // Start is called before the first frame update
    void Start()
    {
        //Assert.IsTrue(boardmanager != null);
    }
    private Vector2 movement = new Vector3(0f,0f);
    // Update is called once per frame
    void FixedUpdate()
    {
      //take our input and store it
      if(Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
      {
          movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
          //make the movement either 1 or -1
          if(movement.x != 0)
            movement.x = stepsize * movement.x / Mathf.Abs(movement.x);
          if(movement.y != 0)
            movement.y = stepsize * movement.y / Mathf.Abs(movement.y);

          //prevent diagonal movement.
          if(movement.x != 0 && movement.y != 0)
            movement.y = 0;

          //check with the boardmanager that this is a valid move first
          //if(boardmanager.is_valid_move(movement))
          //{
            //actually move the player in unity
            this.transform.position += new Vector3(movement.x,movement.y,0);
            //update the board managers function to move the player in BM's 2d array.
            //boardmanager.player_moved(movement);
          //}
          //reset movement delta
          movement.x = 0;
          movement.y = 0;
      }
    }
}

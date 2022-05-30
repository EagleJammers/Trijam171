using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float stepsize = 1;

    private bool prompting = false;
    private Vector2 movement = new Vector2(0f,0f);
    //[SerializeField]
    //BoardManager boardmanager = null;

    // Start is called before the first frame update
    void Start()
    {
        //Assert.IsTrue(boardmanager != null);
        //stepsize = boardmanager.stepsize;
    }

    // Update is called once per frame
    void Update()
    {
      //take our input and store it
      if(Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
      {
        if(!prompting){
          move();
        }
        else
          place_flag();
      }
      //prompt the user
      if(Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1"))
      {
          prompting = true;

          //unused
          prompt_flag_direction();
      }
    }
    private void move(){
      movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
      //make the movement either 1 or -1
      movement = unit_length_vect2_vars(movement);

      //prevent diagonal movement.
      if(movement.x != 0 && movement.y != 0)
        movement.y = 0;

      //check with the boardmanager that this is a valid move first
      //if(boardmanager.is_valid_move(movement))
      //{
        //actually move the player in unity
        this.transform.position += new Vector3(stepsize * movement.x,stepsize * movement.y,0);
        //update the board managers function to move the player in BM's 2d array.
        //boardmanager.UpdatePlayer(movement);
      //}
      //reset movement delta
      movement.x = 0;
      movement.y = 0;
    }
    private Vector2 unit_length_vect2_vars(Vector2 vect){
      /*
        make all of the dimensions of the incoming vector2
        to be stepsize size
      */
      if(vect.x != 0)
        vect.x = vect.x / Mathf.Abs(vect.x);
      if(vect.y != 0)
        vect.y = vect.y / Mathf.Abs(vect.y);
      return vect;
    }
    private void prompt_flag_direction(){
        /*
          this function will bring up cool graphics to inform
          the user that they need to choose a direction to place a flag
        */
    }
    private void place_flag(){
      /*
        this function will make a call to boardmanager to spawn a flag in a direction relative to player.
      */
      Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
      //force it to be -1,0,1 for x and y just in case
      direction = unit_length_vect2_vars(direction);
      //boardmanager.SetFlag(direction);

      prompting = false;
    }
}

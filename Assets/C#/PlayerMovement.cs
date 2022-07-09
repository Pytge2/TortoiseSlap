using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody playerRB;
    public Vector2 playerMoveVector;
    public float movementSpeed = 0.5f;

    void Start()
    {
        
    }

    void Update()
    {
        

    }
    private void FixedUpdate()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        #region Input
        if ((Input.GetAxis("Vertical")!=0))
        {
            playerMoveVector.y = (Input.GetAxis("Vertical"));
        }
        else
        {
            playerMoveVector.y = 0f;
        }
        //Second input
        if ((Input.GetAxis("Horizontal") != 0))
        {
            playerMoveVector.x = (Input.GetAxis("Horizontal"));
        }
        else
        {
            playerMoveVector.x = 0f;
        }

        #endregion

        Vector3 direction = playerRB.rotation* new Vector3(playerMoveVector.x,0,playerMoveVector.y);
        
        playerRB.MovePosition (transform.position + direction*movementSpeed);

    }
}

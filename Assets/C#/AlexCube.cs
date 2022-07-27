using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlexCube : MonoBehaviour
{
    public CharacterController alexcubecc;
    public Vector3 moveVector;
    public float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

    }

    private void PlayerMovement()
    {
        moveVector = new Vector3(Input.GetAxis("Horizontal")*Time.deltaTime*movementSpeed, 0, Input.GetAxis("Vertical")*Time.deltaTime*movementSpeed);

        moveVector = moveVector * movementSpeed;

        if (Vector3.zero != moveVector)
        {
            alexcubecc.Move(moveVector);
            

        }

        
    }


}


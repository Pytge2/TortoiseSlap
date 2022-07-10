using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool useCharacterController;
    private CamMove camMoveRef;

    private CharacterController playerCC;
    private Rigidbody playerRB;
    public Vector2 playerMoveVector;
    public float movementSpeed = 0.5f;
    private bool canJump = false;
    private bool jumpRBbool = false;


    #region setup
    private void Awake()
    {
        camMoveRef = GameObject.FindGameObjectWithTag("Player").GetComponent<CamMove>();
        camMoveRef.useCCcam = useCharacterController;
    }

    void Start()
    {
        if (useCharacterController) SwapControllerType();
        else AddRBcomponent();
     
    }
    private void AddRBcomponent()
    {
        playerRB = this.gameObject.AddComponent<Rigidbody>();
        camMoveRef.playerRBcam = playerRB;
        playerRB.constraints = (RigidbodyConstraints.FreezeRotationX) | (RigidbodyConstraints.FreezeRotationZ);
        //playerRB.constraints = RigidbodyConstraints.FreezeRotationZ;
    }
    private void SwapControllerType()
    {
        // Destroy(playerRB);
        playerCC = this.gameObject.AddComponent<CharacterController>();
        //playerCC = this.GetComponent<CharacterController>();
        playerCC.height = 1.8f;
       
    }
    #endregion
    #region updates
    void Update()
    {
        if (useCharacterController) PlayerMoveCC();
        if (!useCharacterController) PlayerMoveRB();
    }
    private void FixedUpdate()
    {
        // if (!useCharacterController)PlayerMoveRB();
        if (!useCharacterController) ApplyRBForce();
    }

  
    #endregion


    #region PlayerRB
    private void PlayerMoveRB()
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
        if (Input.GetButtonDown("Jump")) jumpRBbool = true;
        #endregion

        /* Vector3 direction = playerRB.rotation* new Vector3(playerMoveVector.x,0,playerMoveVector.y);

         playerRB.MovePosition (transform.position + direction*movementSpeed);
         if (Input.GetButtonDown("Jump")) JumpRB(); */
    }

    private void ApplyRBForce()
    {
        Vector3 direction = playerRB.rotation * new Vector3(playerMoveVector.x, 0, playerMoveVector.y);

        playerRB.MovePosition(transform.position + direction * movementSpeed);
        if (jumpRBbool) JumpRB();
    }

    private void JumpRB()
    {
        playerRB.MovePosition(transform.position + new Vector3(0, 3f, 0));
        jumpRBbool = false;
    }

    #endregion

    #region PlayerCC
   

    private void PlayerMoveCC ()
    {
        GravityCC();
        
        #region InputCC
        if ((Input.GetAxis("Vertical") != 0))
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

        //Jump Input
        if (Input.GetButtonDown("Jump")) JumpCC();

        #endregion

        Vector3 direction = this.transform.rotation * new Vector3(playerMoveVector.x, 0, playerMoveVector.y);
        
        playerMoveVector = playerMoveVector* Time.deltaTime * movementSpeed;
        playerCC.Move(new Vector3(playerMoveVector.x, 0, playerMoveVector.y));
        

    }

    private void JumpCC()
    {
       //Jump for later
        StartCoroutine("JumpingCoro");
    }

    private IEnumerator JumpingCoro ()
    {
        yield return null;
    }

    private void GravityCC ()
    {
        playerCC.Move(new Vector3(0, -3, 0));
    }
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public GameObject rotationPoint;

    private float mouseX;
    private float mouseY;
    private Rigidbody playerRBcam;

    private void Awake()
    {
        playerRBcam = this.GetComponent<Rigidbody>();
    }
    void Start()
    {
        


    }



    void Update()
    {
        CameraInputRotation();


    }

    private void CameraInputRotation ()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y")*-1f;

        #region RB rotation
        //Cam player rotation. This might need to be changing angle of velocity / angular velocity(=new velocity)
        //Old rotation
        //this.gameObject.transform.Rotate(new Vector3(0, mouseX, 0));
        playerRBcam.angularVelocity = new Vector3(0, mouseX*3, 0);
        



    #endregion

        //Cam X rotation
        if (mouseY!=0)
        {

            if ((mouseY>0) && (rotationPoint.transform.rotation.eulerAngles.x<45f|| rotationPoint.transform.rotation.eulerAngles.x>305))
            {
                // Up, positive X
                rotationPoint.transform.Rotate(new Vector3(mouseY, 0, 0));
            }


            if ((mouseY<0)&& (rotationPoint.transform.rotation.eulerAngles.x < 50f || rotationPoint.transform.rotation.eulerAngles.x > 310))
            {
                //Down
                rotationPoint.transform.Rotate(new Vector3(mouseY, 0, 0));
            }

          

          //  rotationPoint.transform.Rotate(new Vector3(mouseY, 0, 0));
        }
            
        
    }
}

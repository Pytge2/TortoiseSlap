using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public GameObject rotationPoint;

    private float mouseX;
    private float mouseY;

    public float maxRotation;
    public float minRotation;

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

        //Cam player rotation. This might need to be changing angle of velocity / angular velocity(=new velocity)
        this.gameObject.transform.Rotate(new Vector3(0, mouseX, 0));

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

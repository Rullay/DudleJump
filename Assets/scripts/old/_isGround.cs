using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class _isGround : MonoBehaviour
{
    public bool Bool_isGround;
    public RaycastHit hitinfo;

    void Start()
    {

    }

    void Update()
    {
       //NotGround();
      
    }

    void OnCollisionStay(Collision other)
    {
        if (other.transform.tag == "isGround")
        {
            Bool_isGround = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        Bool_isGround = false;
    }

      bool _isGrounded_Left_45()
     {
         Debug.DrawRay(transform.position - new Vector3(0f,0.3f,0f), transform.TransformDirection(new Vector3(-1,-1f,0)), Color.yellow);
         return (Physics.Raycast(transform.position - new Vector3(0f,0.3f,0f), new Vector3(-1,-1f,0), 0.38f, 1, QueryTriggerInteraction.Ignore));
     }
     bool _isGrounded_right_45()
     {
         Debug.DrawRay(transform.position - new Vector3(0f,0.3f,0f), transform.TransformDirection(new Vector3(1,-1f,0)), Color.yellow);
         return (Physics.Raycast(transform.position - new Vector3(0f,0.3f,0f), new Vector3(1,-1f,0), 0.38f, 1, QueryTriggerInteraction.Ignore));
     }

     bool _isGrounded_Left()
     {
         Debug.DrawRay(transform.position - new Vector3(0f,0.3f,0f), transform.TransformDirection(new Vector3(-1,-0.2f,0)), Color.yellow);
         return (Physics.Raycast(transform.position - new Vector3(0f,0.3f,0f), new Vector3(-1,-0.2f,0), 0.38f, 1, QueryTriggerInteraction.Ignore));
     }
     bool _isGrounded_right()
     {
         Debug.DrawRay(transform.position - new Vector3(0f,0.3f,0f), transform.TransformDirection(new Vector3(1,-0.2f,0)), Color.yellow);
         return (Physics.Raycast(transform.position - new Vector3(0f,0.3f,0f), new Vector3(1,-0.2f,0), 0.38f, 1, QueryTriggerInteraction.Ignore));
     }

    void NotGround()
    {
        if(!_isGrounded_Left() && !_isGrounded_right() && !_isGrounded_Left_45() && !_isGrounded_right_45())
        {
            Bool_isGround = false;
        }
    }   


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Move : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    public new Rigidbody rigidbody;
    public float verticalVelocity;
    public float garavity;
    private float TDT;
    public GameObject is_Ground;
    public GameObject[] Platforms;
    public GameObject characterCamera;
    private float shiftPosition;
    public bool CHARACTERDEATH;
    private Vector3 MoveVector3;
    public bool Bool_isGround;
    private float transform_y_Hight;
    public float Score;
    public Text score_counter;
    




    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        shiftPosition = 7.24f;
        CHARACTERDEATH = false;
        transform_y_Hight = 0;

    }


    void Update()
    {
        TDT = Time.deltaTime;
        
        GroundTrue();
        NotGround();
        characterDeath();
        colliderOff();
        quantityScore();
    }
    void FixedUpdate()
    {
        Move_Logic();
        shift();
    }
    void LateUpdate()
    {
        
    }


    void Move_Logic()
    {
        Jump_Logic();
        float Horizontal = Input.GetAxis("Horizontal");

        if (Horizontal != 0)
        {
            MoveVector3 = new Vector3(Horizontal * speed, MoveVector3.y, 0);
        }
        rigidbody.velocity = MoveVector3;

    }

    void Jump_Logic()
    {

       
        if (Bool_isGround == true)
        {
            if (GetComponent<BoxCollider>().enabled == true)
            {
                verticalVelocity = 0;
                verticalVelocity = jumpSpeed;
            }
        }

        verticalVelocity -= garavity * Time.fixedDeltaTime;
        MoveVector3 = new Vector3(0, verticalVelocity, 0);

    }

    void characterDeath()
    {
        float VelocityDeath = -35;
        if (verticalVelocity <= VelocityDeath)
        {
            characterCamera.transform.parent = null;
            speed = 0;
            jumpSpeed = 0;
            CHARACTERDEATH = true;
            SceneManager.LoadScene("DeathMenu");
        }
    }

    void shift()
    {

        if (transform.position.x <= -shiftPosition)
        {
            transform.position = new Vector3(shiftPosition, transform.position.y, transform.position.z);
        }
        if (transform.position.x > shiftPosition)
        {
            transform.position = new Vector3(-shiftPosition, transform.position.y, transform.position.z);
        }
    }

    void GroundTrue()
    {
        if (_isGrounded_Left() || _isGrounded_right() || _isGrounded_Left_45() || _isGrounded_right_45())
        {
            Bool_isGround = true;
        }
    }

    bool _isGrounded_Left_45()
    {
        return (Physics.Raycast(transform.position - new Vector3(0f, 0.35f, 0f), new Vector3(-1, -1f, 0), 0.38f, 1, QueryTriggerInteraction.Ignore));
    }
    bool _isGrounded_right_45()
    {
        return (Physics.Raycast(transform.position - new Vector3(0f, 0.35f, 0f), new Vector3(1, -1f, 0), 0.38f, 1, QueryTriggerInteraction.Ignore));
    }

    bool _isGrounded_Left()
    {
        return (Physics.Raycast(transform.position - new Vector3(0f, 0.35f, 0f), new Vector3(-1, -0.2f, 0), 0.38f, 1, QueryTriggerInteraction.Ignore));
    }
    bool _isGrounded_right()
    {
        return (Physics.Raycast(transform.position - new Vector3(0f, 0.35f, 0f), new Vector3(1, -0.2f, 0), 0.38f, 1, QueryTriggerInteraction.Ignore));
    }

    void NotGround()
    {
        if (!_isGrounded_Left() && !_isGrounded_right() && !_isGrounded_Left_45() && !_isGrounded_right_45())
        {
            Bool_isGround = false;
        }
    }

    void colliderOff()
    {
        if (verticalVelocity >= 0.5)
        {
            GetComponent<BoxCollider>().enabled = false;
        }

        if (verticalVelocity < 0)
        {
            GetComponent<BoxCollider>().enabled = true;

        }

    }
    void OnCollisionStay(Collision other)
    {
        if (other.transform.tag == "isGround")
        {
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    void quantityScore()
    {
        if (transform.position.y + 0.5 > transform_y_Hight)
        {
            transform_y_Hight = transform.position.y + 0.5f;
            Score += 1;
            score_counter.text = "   Score " + Score;
        }
    }

}



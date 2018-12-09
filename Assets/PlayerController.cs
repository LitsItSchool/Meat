using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float acceleration = 35;
    public float jumpSpeed = 8;

    public bool IsDoubleJump { get; set; }
    void Start()
    {

    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal < -0.1f)
        {
            if (GetComponent<Rigidbody2D>().velocity.x > -speed)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(-acceleration, 0f));
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);
            }
        }

        if (horizontal > 0.1f)
        {
            if (GetComponent<Rigidbody2D>().velocity.x < speed)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(acceleration, 0f));
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
            }
        }
        float vertical = Input.GetAxis("Vertical");

        if (IsGrounded())
        {
            if (Input.GetButtonDown("Jump"))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpSpeed);
                IsDoubleJump = true;
            }
        }
        else
        {
            if (IsDoubleJump)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpSpeed);
                    IsDoubleJump = false;
                }
            }


        }





    }

    public bool IsGrounded()
    {
        var lengthToSearch = 0.1f;
        var colliderThreshold = 0.001f;

        Vector2 lineStart = new Vector2(transform.position.x, transform.position.y - GetComponent<SpriteRenderer>().bounds.extents.y - colliderThreshold);

        Vector2 vectorToSearch = new Vector2(transform.position.x, lineStart.y - lengthToSearch);

        RaycastHit2D hit = Physics2D.Linecast(lineStart, vectorToSearch);
        return hit;
    }

    public bool IsWall(bool isLeft)
    {
        int modificator = 1;
        if (isLeft)
        {
            Debug.Log("left");
            modificator = -1;
        }
        bool retVal = false;
        var lengthToSearch = 0.1f;
        var colliderThreshold = 0.01f;

        Vector2 lineStart = new Vector2(transform.position.x + GetComponent<SpriteRenderer>().bounds.extents.x * modificator + colliderThreshold * modificator, transform.position.y);
        Vector2 vectorToSearch = new Vector2(lineStart.x + lengthToSearch * modificator, lineStart.y);


        RaycastHit2D hit = Physics2D.Linecast(lineStart, vectorToSearch);
        Debug.DrawLine(lineStart, vectorToSearch, Color.blue, 1f);
        retVal = hit;
        if (retVal)
        {
            if (hit.collider.tag == "noSlide")
            {
                return false;
            }
        }
        return retVal;
    }
}

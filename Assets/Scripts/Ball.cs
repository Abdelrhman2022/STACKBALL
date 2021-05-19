using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float gravityPower = 5f;
    [SerializeField] private float bouncePower = 1f;
    [SerializeField] private float dashSpeed = 9f;

    private Vector3 motionDirection;
    private float myRadius;
    private Vector3 lastPosition;
    private bool dashing;

    void Start()
    {
        myRadius = transform.localScale.x / 2f;
        lastPosition = transform.position;
    }

    
    void Update()
    {
        motionDirection.y -= gravityPower * Time.deltaTime;

        transform.position += motionDirection * Time.deltaTime;
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
            dashing = true;
        if (Input.GetMouseButtonUp(0) || Input.GetKeyUp("space"))
            dashing = false;
        //Detection
        if (!dashing)
            Idle();
        else
            Dash();

        lastPosition = transform.position;
    }

    void Idle()
    {
        motionDirection.y -= gravityPower * Time.deltaTime;

        if (Physics.Linecast(lastPosition, transform.position - new Vector3(0, myRadius, 0), out RaycastHit hit))
        {
            motionDirection.y = bouncePower;
            transform.position = new Vector3(transform.position.x, hit.point.y + myRadius, transform.position.z);
        }
    }
    void Dash()
    {
        motionDirection.y = -dashSpeed; 
    }
}

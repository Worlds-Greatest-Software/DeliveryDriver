using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver1 : MonoBehaviour
{
    [SerializeField] float steerSpeed = 125;
    [SerializeField] float moveSpeed = 12;
    [SerializeField] float slowSpeed = 4;
    [SerializeField] float slowDuration = 2;
    [SerializeField] float boostSpeed = 17;
    [SerializeField] float boostDuration = 2;
    float startSpeed = 12f;

    bool boostIsActive = false;
    bool slowIsActive = false;

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        // transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
        if (moveAmount < 0f)
        {
            transform.Rotate(0, 0, steerAmount);
        }
        if (moveAmount > 0f)
        {
            transform.Rotate(0, 0, -steerAmount);
        }

        if (boostIsActive)
        {
            moveSpeed = boostSpeed;
        }
        if (slowIsActive)
        {
            moveSpeed = slowSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        moveSpeed = slowSpeed;
        Invoke("endSlow", slowDuration);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boost")
        {
            boostIsActive = true;
        }
        Invoke("endBoost", boostDuration);
    }

    void endSlow()
    {
        slowIsActive = false;
        moveSpeed = startSpeed;
    }

    void endBoost()
    {
        boostIsActive = false;
        moveSpeed = startSpeed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beetle : MonoBehaviour
{
    [SerializeField] float steerSpeed = 125f;
    [SerializeField] float moveSpeed = 12f;
    [SerializeField] float slowSpeed = 7f;
    [SerializeField] float slowDuration = 2;
    [SerializeField] float boostSpeed = 17f;
    [SerializeField] float boostDuration = 3;

    float startSpeed = 12f;

    bool boostIsActive = false;
    bool slowIsActive = false;

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(0, moveAmount, 0);
        if (moveAmount < 0f)
        {
            transform.Rotate(0, 0, steerAmount);
        }
        else
        {
            transform.Rotate(0, 0, -steerAmount);
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

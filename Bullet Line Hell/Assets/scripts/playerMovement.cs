using System;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    private Rigidbody2D characterBody;
    private Boolean isKilled = false;

    private void Awake()
    {
        characterBody = gameObject.GetComponent<Rigidbody2D>();
    }

    //looked up how fixed update works and how it does not require time.deltatime
    void FixedUpdate()
    {
        if (!isKilled)
        {
            Vector2 userInputVelocity = Vector2.zero;
            if (Input.GetKey(KeyCode.W))
                userInputVelocity.y = 1f * speed;
            if (Input.GetKey(KeyCode.S))
                userInputVelocity.y = -1f * speed;
            if (Input.GetKey(KeyCode.A))
                userInputVelocity.x = -1f * speed;
            if (Input.GetKey(KeyCode.D))
                userInputVelocity.x = 1f * speed;

            characterBody.velocity = userInputVelocity;

            if (userInputVelocity != Vector2.zero)
            {
                GetComponent<Animator>().SetBool("isMoving", true);
            }
            else
            {
                GetComponent<Animator>().SetBool("isMoving", false);
            }
        }

    }
    public void Killed()
    {
        Destroy(gameObject);
    }
}

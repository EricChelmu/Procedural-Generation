using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    [SerializeField]
    private float speed = 15f;
    private float gravity = -9.81f;

    Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.forward * z + transform.right * x;

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(move * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.Space))
        {
            characterController.Move(-velocity * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            characterController.Move(velocity * Time.deltaTime);
        }
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;


    }
}

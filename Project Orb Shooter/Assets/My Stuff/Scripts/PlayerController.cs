using System.Collections;
using System.Collections.Generic;
using InControl;
using UnityEngine;

public class PlayerController : Actor
{
    protected Rigidbody playerRb;

    public static float health;

    //Vector3 shootDirection;
    Vector3 moveDirection;

    protected bool disableInput;
    InputDevice inputDevice;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        inputDevice = InputManager.ActiveDevice;
        health = 100;

        GetComponent<AudioSource>().clip = shoot;
    }

    void Update()
    {
        /*Vector3 localVelocity = transform.InverseTransformDirection(playerRb.velocity);
        localVelocity.x = 0;
        localVelocity.z = 0;

        playerRb.velocity = transform.TransformDirection(localVelocity);*/

        UpdateInputDevice(inputDevice);
        timer += Time.deltaTime;

        if (timer > bulletDelay)
            canFire = true;

    }

    void UpdateInputDevice(InputDevice inputDevice_)
    {
        if (disableInput)
            return;

        /*moveDirection = Vector3.up * inputDevice_.LeftStickX + Vector3.forward * inputDevice_.LeftStickY;
        if (moveDirection.sqrMagnitude > 0.0f)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection, Vector3.forward);
            playerRb.velocity = moveSpeed * transform.forward;
        }
        else
            playerRb.velocity = new Vector3(0,0,0);*/

        if (inputDevice_.LeftStickY >= 0 && inputDevice_.LeftStickX <= 0.5 && inputDevice_.LeftStickX >= -0.5)
        {
            playerRb.velocity = moveSpeed * transform.forward;
        }
        else if (inputDevice_.LeftStickY <= 0.5 && inputDevice_.LeftStickY >= -0.5 && inputDevice_.LeftStickX <= 0)
        {
            playerRb.velocity = moveSpeed * transform.forward;
            transform.RotateAround(transform.position, transform.right, Time.deltaTime * 90.0f * rotateSpeed);
        }
        else if (inputDevice_.LeftStickY <= 0.5 && inputDevice_.LeftStickY >= -0.5 && inputDevice_.LeftStickX >= 0)
        {
            playerRb.velocity = 1 * moveSpeed * transform.forward;
            transform.RotateAround(transform.position, transform.right, Time.deltaTime * -90.0f * rotateSpeed);
        }
        else if (inputDevice_.LeftStickY < 0 && inputDevice_.LeftStickX <= 0.5 && inputDevice_.LeftStickX >= -0.5)
        {
            playerRb.velocity = -1 * moveSpeed * transform.forward;
        }
        else
            playerRb.velocity = new Vector3(0, 0, 0);

        if (inputDevice_.RightTrigger.IsPressed && canFire)
            Fire();

        /*shootDirection = Vector3.up * inputDevice_.RightStickX + Vector3.forward * inputDevice_.RightStickY;
        if (shootDirection.sqrMagnitude > 0.0f)
        {
            transform.rotation = Quaternion.LookRotation(shootDirection, Vector3.forward);
            if (canFire)
                Fire();
        }*/
        
    }
}

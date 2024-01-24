using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// TODO: import UnityEngine.InputSystem and UnityEngine.SceneManagement


public class PlayerController : MonoBehaviour
{
    private Vector3 originalScale;
    private bool isFlattened = false;
    Rigidbody rb;

    [SerializeField] float speed = 5f;
    [SerializeField] float jumpHeight = 10f;

    Vector2 moveValue = Vector2.zero;
    
    // TODO: add variables for speed, jumpHeight, and respawnHeight

    // TODO: add variable to check if we're on the ground


    // Start is called before the first frame update
    void Start()
    {
        // TODO: Get references to the components attached to the current GameObject
        originalScale = transform.localScale;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: check if player is under respawnHeight and call Respawn()
        Move(moveValue.x, moveValue.y);
    }

    public void OnFlatten()
    {
        if (!isFlattened)
        {
            transform.localScale = new Vector3(originalScale.x * 2, originalScale.y / 2, originalScale.z * 2);
            isFlattened = true;
        }
    }

    public void OnUnflatten()
    {
        if (isFlattened)
        {
            transform.localScale = originalScale;
            isFlattened = false;
        }
    }

    void OnJump()
    {
        // TODO: check if player is on the ground, and call Jump()
        Jump();
    }

    private void Jump()
    {
        // TODO: Set the y velocity to some positive value while keeping the x and z whatever they were originally
        rb.velocity = new Vector3(rb.velocity.x, jumpHeight, rb.velocity.z);
    }

    void OnMove(InputValue value)
    {
        Vector2 direction = value.Get<Vector2>();
        Debug.Log(direction);
        moveValue = direction;
        // Move(direction.x, direction.y);
        
    }

    private void Move(float x, float z)
    {
        // TODO: Set the x & z velocity of the Rigidbody to correspond with our inputs while keeping the y velocity what it originally is.
        rb.velocity = new Vector3(x * speed, rb.velocity.y, z* speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        // This function is commonly useful, but for our current implementation we don't need it

    }

    void OnCollisionStay(Collision collision)
    {
        // TODO: Check if we are in contact with the ground. If we are, note that we are grounded

    }

    void OnCollisionExit(Collision collision)
    {
        // TODO: When we leave the ground, we are no longer grounded

    }

    private void Respawn()
    {
        // TODO: reload current scene

    }
}

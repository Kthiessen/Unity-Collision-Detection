using UnityEngine;
using System.Collections;

public class PlayerController : GenericActorController {

    public float jumpHeight;
    public float jumpTime;
    private float jumpForce;

    private bool jumpOnNextFixedUpdate = false;

    void Start()
    {
        if (jumpTime > 0)
            Physics2D.gravity = new Vector2(0, -2 * jumpHeight / (jumpTime * jumpTime));

        jumpForce = Mathf.Sqrt(2 * Physics2D.gravity.magnitude * rigidbody2D.gravityScale * jumpHeight);
        Debug.Log("Gravity: " + Physics2D.gravity + "          Jumpforce: " + jumpForce);

    }
    void Update()
    {
        if (InputControl.GetButtonDown("Jump"))
        {
            StartCoroutine(Jump());
        }
    }
    
    IEnumerator Jump()
    {
        yield return new WaitForFixedUpdate();

        rigidbody2D.AddForce(-Physics2D.gravity.normalized * jumpForce, ForceMode2D.Impulse);

        float startPos = transform.position.y;

        while (rigidbody2D.velocity.y > 0)
        {
            yield return new WaitForFixedUpdate();
        }

        float endPos = transform.position.y;

        Debug.Log("Height Diff: " + (endPos - startPos));
    }

    void FixedUpdate()
    {

    }
}

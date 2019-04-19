using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Santa : MonoBehaviour
{
    private Rigidbody2D rgbody2d;
    [SerializeField] private bool onGround = true;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rgbody2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetFloat("Move", 0);
    }

    // Update is called once per frame
    void Update()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * 10f;
        var newXPos = transform.position.x + deltaX;
        var newYPos = transform.position.y;
        transform.position = new Vector3(newXPos, newYPos, transform.position.z);
        anim.SetFloat("Move", Mathf.Abs(deltaX));

        if (deltaX < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (deltaX > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rgbody2d.velocity = new Vector2(0, 20f);
            anim.SetTrigger("Jump");


        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        onGround = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        onGround = true;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        onGround = true;
    }
}

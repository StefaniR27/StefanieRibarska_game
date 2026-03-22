using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode leftKey;
    public KeyCode rightKey;
    

    public Animator animator;

    float horizontal;
    GameManager gm;
    [SerializeField]
    float speed;
    void Start()
    {
        gm = FindFirstObjectByType<GameManager>();
        horizontal = 0;
        speed = 3;
    }
    
    void MoveUp()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void MoveDown()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void MoveLeft()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    void MoveRight()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void Attack()
    {
        Debug.Log("Attack!");
    }
    void Update()
    {
        if (gm != null && gm.gameEnded)
            return;

        Vector2 move = Vector2.zero;

        if (Input.GetKey(leftKey))
            move.x = -1;

        if (Input.GetKey(rightKey))
            move.x = 1;

        if (Input.GetKey(upKey))
            move.y = 1;

        if (Input.GetKey(downKey))
            move.y = -1;

        transform.Translate(move * speed * Time.deltaTime);

        animator.SetBool("isWalking", move != Vector2.zero);   
    }
    void FixedUpdate(){
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(horizontal * speed,rb.velocity.y);
    }

}

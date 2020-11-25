using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWalker : MonoBehaviour {

    [SerializeField]
    private Transform startPos, endPos;

    private bool collision;

    public float speed = 1f;

    private Rigidbody2D myBody;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Move();
        ChangeDirection();
    }

    void ChangeDirection()
    {
        collision = Physics2D.Linecast(startPos.position, endPos.position, 1 << LayerMask.NameToLayer("Ground"));

        if (!collision)
        {
            Vector3 temp = transform.localScale;
            if (temp.x == 1f)
            {
                temp.x = -1;
            }
            else
            {
                temp.x = 1f;
            }

            transform.localScale = temp;
        }
    }

    void Move()
    {
        myBody.velocity = new Vector2(transform.localScale.x, 0)*speed;
    }

    private void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.tag == "Player")
        {
            Destroy(target.gameObject);
        }
    }
    
}

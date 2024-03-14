using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSkull : MonoBehaviour
{
    public float vel = 1;
    Rigidbody2D rb;
    GameObject player;
    Transform transformPlayer;
    public float lifeTime;
    public static float damage=2;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        transformPlayer= player.transform;
    }
    private void Start()
    {
        if(transformPlayer.localScale.x>0)
        {
            rb.velocity = new Vector2(vel, rb.velocity.y);
            transform.localScale = new Vector3(1, 1, 1);
        } else if (transformPlayer.localScale.x < 0)
        {
            rb.velocity = new Vector2(-vel, rb.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1);
        }

    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,lifeTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag!="Player")
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
        }
    }
}

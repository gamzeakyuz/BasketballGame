using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{

    private float ballScorePosition;
    private Vector2 defaultBallPosition;
    public UnityEvent scoredEvent;

    public UnityEvent<Transform> onGroundEvent;

    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public CircleCollider2D col;

    [HideInInspector] public Vector3 pos { get { return transform.position; } }

    //bütün fonksiyonların oyun başladığı anda çalışmaya başladı alan.
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
    }


    public void Push(Vector2 force)
    {
        rb.AddForce(force,ForceMode2D.Impulse);
    }

    public void DesactivateRb()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;
        rb.isKinematic = true;
    }

    //Bu collider2D/rigidbody2D başka bir rigidbody2D/collider2D ile temas etmeye başladığında (yalnızca 2D fizik) OnCollisionEnter2D çağrılır
    void OnCollisionEnter2D(Collision2D collision)
    {
        checkGroundContact(collision);
    }
    //topun aktiflik özelliğini bellirlendiği alan
    public void ActivateRb()
    {
        rb.isKinematic = false;
    }
    //topun aktiflik özelliğini bellirlendiği alan
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        ballScorePosition = transform.position.y;
    }

    //Collider2D other tetikleyiciye temas etmeyi durdurduğunda OnTriggerExit2D çağrılır (yalnızca 2D fizik)
    void OnTriggerExit2D(Collider2D collision)
    {
        if(transform.position.y < ballScorePosition)
        {
            Debug.Log("Scored");
            scoredEvent.Invoke();
        }
    }
    private void checkGroundContact(Collision2D collision)
    {
        if (!collision.gameObject.tag.Equals("ground")) return;

        rb.isKinematic = true;
        defaultBallPosition = transform.position;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;

        onGroundEvent.Invoke(transform);

    }
}

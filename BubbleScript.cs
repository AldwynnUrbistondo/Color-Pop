using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour
{
    Transform bubble;
    public ColorValue bubbleColorValue;
    public float bubbleMoveSpeed;
    Animator bubbleAnimator;

    public bool isPopped = false;

    AudioSource bubbleSource;
    CircleCollider2D circleCollider;
    
    void Start()
    {
        bubble = GetComponent<Transform>();
        bubbleSource = GetComponent<AudioSource>();
        circleCollider = GetComponent<CircleCollider2D>();
        bubbleAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {

            Projectile pr = collision.GetComponent<Projectile>();

            if (pr.projectileColor == bubbleColorValue)
            {
                bubbleSource.Play();

                GameManager.scoreInt++;

                Destroy(collision.gameObject);

                StartCoroutine(PopAndDelete());
                
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }
        else if ((collision.gameObject.CompareTag("Player")))
        {
            GameManager gm = FindObjectOfType<GameManager>();
            gm.DeleteLife();

            StartCoroutine(PopAndDelete());
        }
    }

    private void Update()
    {
        if (!isPopped)
        {
            bubble.position = new Vector2(bubble.position.x, bubble.position.y - bubbleMoveSpeed * Time.deltaTime);
        }
        
    }

    IEnumerator PopAndDelete()
    {
        

        isPopped = true;
        circleCollider.enabled = false;
        bubbleAnimator.SetTrigger("Pop");

        yield return new WaitForSeconds(0.3f);

        Destroy(gameObject);

    }

}

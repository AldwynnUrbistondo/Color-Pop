using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    //Player Model
    SpriteRenderer spriteRenderer;
    public Sprite[] sprites;

    //PlayerMovement
    Transform player;
    float moveSpeed = 15f;

    //Projectile Spawn
    public bool canShoot = true;
    float timeShoot = 1;
    public GameObject[] projectiles;

    //Audio
    AudioSource audioSource;

    void Start()
    {
        player = GetComponent<Transform>();
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }


    void Update()
    {

        if (timeShoot <= 0.15f)
        {
            timeShoot += Time.deltaTime;
        }
        else
        {
            canShoot = true;
        }

        //PlayerMovement();

        PlayerMovementMouse();

        SpawnBullet();

        ChangeSprite();
    }

   /*void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            if (player.position.x >= -7.75f)
            {
                player.position = new Vector2(player.position.x - moveSpeed * Time.deltaTime, player.position.y);
            }

        }

        if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
        {
            if (player.position.x <= 7.75f)
            {
                player.position = new Vector2(player.position.x + moveSpeed * Time.deltaTime, player.position.y);
            }

        }
    }*/

    void PlayerMovementMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        if (mousePosition.x <= -7.75f)
        {
            player.position = new Vector2(-7.75f, player.position.y);
        }
        else if (mousePosition.x >= 7.75f)
        {
            player.position = new Vector2(7.75f, player.position.y);
        }
        else
        {
            player.position = new Vector2(mousePosition.x, player.position.y);
        }
    }

    void SpawnBullet()
    {
        if (canShoot)
        {
            if (Input.GetMouseButtonDown(0))
            {

                audioSource.Play();

                if (GameManager.playerProjectileColor == ColorValue.Red)
                {
                    Instantiate(projectiles[0], new Vector2(player.position.x, -3.5f), Quaternion.identity);
                }
                else if (GameManager.playerProjectileColor == ColorValue.Green)
                {
                    Instantiate(projectiles[1], new Vector2(player.position.x, -3.5f), Quaternion.identity);
                }
                else if (GameManager.playerProjectileColor == ColorValue.Yellow)
                {
                    Instantiate(projectiles[2], new Vector2(player.position.x, -3.5f), Quaternion.identity);
                }

                canShoot = false;
                timeShoot = 0;
            }

        }
       
    }

    void ChangeSprite()
    {
        if (GameManager.playerProjectileColor == ColorValue.Red)
        {
            spriteRenderer.sprite = sprites[0];
        }
        else if (GameManager.playerProjectileColor == ColorValue.Green)
        {
            spriteRenderer.sprite = sprites[1];
        }
        else if (GameManager.playerProjectileColor == ColorValue.Yellow)
        {
            spriteRenderer.sprite = sprites[2];
        }

    }
}

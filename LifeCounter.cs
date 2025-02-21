using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCounter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Bubble"))
        {
            GameManager gm = FindObjectOfType<GameManager>();
            gm.DeleteLife();
        }
    }
}

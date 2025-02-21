using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerProjectile : MonoBehaviour
{

    public string TagToDestroy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagToDestroy))
        {
            Destroy(collision.gameObject);
        }

    }
}

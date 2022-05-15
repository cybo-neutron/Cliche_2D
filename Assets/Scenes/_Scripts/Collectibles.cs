using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{

    public LayerMask layer;
    public ParticleSystem effect;
    SpriteRenderer sprite;
    Collider2D col;
    public GameObject targetGameObject;
    // Start is called before the first frame update
    void Start()
    {
        effect = GetComponent<ParticleSystem>();
        sprite = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == targetGameObject)
        {
            if (effect != null)
            {
                effect.Play();
            }

            Destroy(col);
            Destroy(sprite);

            Destroy(gameObject, effect.main.duration);
        }
    }

    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (other.gameObject.layer == layer)
    //     {
    //         if (effect == null)
    //         {
    //             effect.Play();
    //         }
    //         Destroy(gameObject, effect.main.duration);
    //     }
    // }

}

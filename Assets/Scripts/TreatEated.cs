using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreatEated : MonoBehaviour
{
    public Sprite closedMouth;
    public Sprite openedMouth;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = closedMouth;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Meat"))
        {
            spriteRenderer.sprite = openedMouth;
            Destroy(collision.gameObject);
            Invoke("CloseMouth", 0.3f);
        }
    }

    void CloseMouth()
    {
        spriteRenderer.sprite = closedMouth;
    }
}

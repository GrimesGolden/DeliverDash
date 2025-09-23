using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;
    [SerializeField] Color32 hasPackageColor = new Color32 (1, 1, 1, 255);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 255); 
    [SerializeField] float destroyDelay = 0.2f;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Package" && !hasPackage)
        {
            Debug.Log("You picked up a package.");
            hasPackage = true;
            Destroy(collision.gameObject, destroyDelay);

            spriteRenderer.color = hasPackageColor; // TEST
        }
        else if (collision.tag == "Package" && hasPackage)
        {
            Debug.Log("You already have a package!");
        }
        else if (collision.tag == "Customer" && hasPackage)
        {
            Debug.Log("You delivered to a customer. CHOCOLATE I remember chocolate!");
            hasPackage = false;
            spriteRenderer.color = noPackageColor; // TEST
        }
        else if (collision.tag == "Customer" && !hasPackage)
        {
            Debug.Log("WHERES MY DRINK!");
        }
    }
}

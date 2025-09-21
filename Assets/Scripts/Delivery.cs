using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;
    [SerializeField] float destroyDelay = 0.2f;  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(gameObject.name + " collided with " + collision + " oh the HUMANITY!");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Package" && !hasPackage)
        {
            Debug.Log("You picked up a package.");
            hasPackage = true;
            Destroy(collision.gameObject, destroyDelay);
        }
        else if (collision.tag == "Package" && hasPackage)
        {
            Debug.Log("You already have a package!"); 
        }
        else if (collision.tag == "Customer" && hasPackage)
        {
            Debug.Log("You delivered to a customer. CHOCOLATE I remember chocolate!");
            hasPackage = false;
        }
        else if (collision.tag == "Customer" && !hasPackage)
        {
            Debug.Log("WHERES MY DRINK!");
        }
    }
}

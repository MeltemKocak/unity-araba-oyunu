using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Car"))
        {
            Debug.Log("Araba çarptı.");
        }
    }


    private void OnTriggerEnter(Collider contact)
    {
        if (contact.gameObject.tag == "Coin")
        {
            CoinT.coAmount += 1;
            Destroy(contact.gameObject);

        }
    }
}

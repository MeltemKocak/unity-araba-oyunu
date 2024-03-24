using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarHealth : MonoBehaviour
{
    public float Health;
    float maxHealth = 100;

    public Slider healthSlider;

    private void Update()
    {
        
        if (Health >= 100)
        {
            Health = 100;
        }
        
    }
    private void OnTriggerEnter(Collider contact)
    {
        if (contact.gameObject.tag == "Barrel")
        {
            GetDamage(10);
            Destroy(contact.gameObject);

        }
    }
        public void GetDamage(float amount)
    {
        Health -= amount;
        healthSlider.value = Health;
        if (Health <= 0)
        {
            Debug.Log("Can bitti.");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour
{
    public float CurrentHealth{get; set;}
    public float MaxHealth{get; set;}
    public Slider healthbar;
    // Start is called before the first frame update
    void Start()
    {
        MaxHealth = 20f;
        CurrentHealth = MaxHealth;
        healthbar.value = CalculateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.X))
          // DealDamage(5);
    }

    public void DealDamage(float dmgVal){
        CurrentHealth -= dmgVal;
        healthbar.value = CalculateHealth();
        if(CurrentHealth <= 0) Die();
    }
    float CalculateHealth()
    {
        return CurrentHealth / MaxHealth;
    }

    void Die(){
        CurrentHealth = 0;
        Camera.main.transform.parent = null;
        this.gameObject.SetActive(false);
        //this.CharacterHealth.SetActive(false);
        Destroy(this);
    }
}

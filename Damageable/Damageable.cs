using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DamageTypes;
using static Healthbar;
using static Item;

abstract public class Damageable : MonoBehaviour
{   

    List<Item> items;
    [SerializeField] protected int healthGrowth;
    [SerializeField] protected int level;
    protected int baseHealth;
    protected int baseArmor;

    int currentMaxHealth;
    int currentMaxArmor;

    int currentHealth;
    int currentArmor;

    // Decides whether you display numbers on health bar. Off by default
    protected bool healthbarNumbers = false;

    public Healthbar healthbar;
    // Start is called before the first frame update
    public void Start()
    {
        currentMaxHealth = baseHealth;
        currentMaxArmor = baseArmor;

        currentHealth = currentMaxHealth;
        currentArmor = currentMaxArmor;
    }
    
    public void TakeDamage(int amount, DamageType damageType) { 

        switch (damageType) {

            case DamageType.Normal:
                currentHealth -= (int)((float) amount * 100.0 / (100.0 + (float) currentArmor)); 
                break;
            
            case DamageType.True:
                currentHealth -= amount;
                break;
        }
        
        if (currentHealth < 0) {

            healthbar.ChangeHealthFill(0, currentMaxHealth);
        } else {
            
            healthbar.ChangeHealthFill(currentHealth, currentMaxHealth);
        }
    }

    public virtual void AfterTakeDamage() {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int heatlth ;
    // Start is called before the first frame update
    void Start()
    {
        heatlth = maxHealth;
    }

    public void TakeDamage(int damage) {
        heatlth -= damage;
        if (heatlth <= 0) {
            Destroy(gameObject);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mob_damage : MonoBehaviour
{

    public int damage;
    public PlayerHealth health;
    // Start is called before the first frame update
    private void OnCollider2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            health.TakeDamage(damage);
        }
    }
}

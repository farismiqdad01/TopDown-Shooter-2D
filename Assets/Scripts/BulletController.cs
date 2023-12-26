using System;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10f;
    private int damage = 10;

    private void Start()
    {
        Destroy(gameObject, 5f); // Hancurkan proyektil setelah 5 detik
    }

    private void Update()
    {
        MoveBullet();
    }

    private void MoveBullet()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Cek apakah proyektil bertabrakan dengan objek yang memiliki tag "Enemy"
        if (other.CompareTag("Enemy"))
        {
            // Dapatkan komponen Health dari objek yang tertabrak
            Enemy enemyHealth = other.GetComponent<Enemy>();

            // Jika objek memiliki komponen EnemyHealth, berikan damage ke musuh
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }

            // Hancurkan proyektil setelah menyentuh musuh
            Destroy(gameObject);
        }
        else if (other.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
    public void SetDamage(int newDamage)
    {
        damage = newDamage;
    }
}

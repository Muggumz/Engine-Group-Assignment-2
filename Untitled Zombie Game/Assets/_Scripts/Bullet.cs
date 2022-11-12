using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        Destroy(gameObject);

        GameObject Gun = GameObject.FindWithTag("Gun");

        GunShoot damage = Gun.GetComponentInChildren<GunShoot>();

        if (other.collider.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        } else if(other.collider.tag == "Enemy")
        {
            Health health = other.gameObject.GetComponent<Health>();
            health?.TakeDamage(damage.damageNumber);
            if (health.currentHealth <= 0)
            {
                ScoreManager.instance.ChangeScore(1);
            }
            //other.gameObject.GetComponent<EnemyController>().OnTakeDamages(25);
            //Destroy(other.gameObject);
        }
    }

    private void Update()
    {
        Destroy(gameObject, 3);
    }
}

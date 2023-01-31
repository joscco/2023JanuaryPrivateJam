using System.Collections;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    public float health = 1;
    private ParticleSystem _particleSystem;

    DropItem _dropItem;

    bool alive = true;

    void Start()
    {
        _particleSystem = GetComponentInChildren<ParticleSystem>();
        _dropItem = GetComponent<DropItem>();
    }

    void Update()
    {
        if (health < 0 && alive)
        {
            alive = false;
            _dropItem.Drop();
           Die();
        }
    }

    void Die()
    {
        
        StartCoroutine(DeathAnimation());
    }

    IEnumerator DeathAnimation()
    {
        _particleSystem.Play();
        transform.localScale = Vector3.zero;
        ParticleSystem.MainModule mainModule = _particleSystem.main;
        float particleSystemDuration = mainModule.duration + mainModule.startLifetime.constant;
        yield return new WaitForSeconds(particleSystemDuration);
        Destroy(gameObject);
    }
}

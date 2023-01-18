using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerAttack : MonoBehaviour
{
    public float attack = 1;
    public float attackSpeed = 1;

    public List<Weapon> weapons;

    bool _canAttack = true;
    VisionRadius _visionRadius;

    void Start()
    {
        _visionRadius = GetComponentInChildren<VisionRadius>();
    }

    void Update()
    {
        if (_visionRadius.enemyInSight.Count > 0 && _canAttack)
        {
            _canAttack = false;
            Invoke("ReArm", attackSpeed);
            Attack(_visionRadius.enemyInSight[0]);
        }
    }

    void Attack(GameObject enemy)
    {
        enemy.GetComponent<EnemyStats>().health -= attack;

        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].transform.position = enemy.transform.position;
        }
    }

    void ReArm()
    {
        _canAttack = true;

        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].transform.position = transform.position + weapons[i].idlePosition;
        }
    }
}
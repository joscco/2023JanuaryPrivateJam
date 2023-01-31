using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attack = 0.1f;
    
    public List<GameObject> weapons;

    VisionRadius _visionRadius;

    void Start()
    {
        _visionRadius = GetComponentInChildren<VisionRadius>();
    }

    void Update()
    {
        if (_visionRadius.enemyInSight.Count > 0)
        {
            TurnAllWeaponsTowardsEnemy(_visionRadius.enemyInSight[0]);
            Attack(_visionRadius.enemyInSight[0]);
        }
    }

    private void TurnAllWeaponsTowardsEnemy(GameObject enemy)
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            TurnWeaponTowardsEnemy(weapons[0], enemy);
        }
    }

    void Attack(GameObject enemy)
    {
        var enemyStats = enemy.GetComponent<EnemyStats>();
        enemyStats.health -= attack;
        
        // This is a very intertwined logic
        if (enemyStats.health <= 0)
        {
            _visionRadius.enemyInSight.Remove(enemy);
        }
    }

    void TurnWeaponTowardsEnemy(GameObject weapon, GameObject enemy)
    {
        Transform weaponTransform = weapon.transform;
        Vector3 aimDirection = (enemy.transform.position - weaponTransform.position).normalized;
        float currentAngle = weaponTransform.eulerAngles.z;
        float aimAngle = Mathf.Acos(Vector3.Dot(Vector3.right, aimDirection)) * Mathf.Rad2Deg;
        weaponTransform.eulerAngles = new Vector3(0, 0, Mathf.Lerp(currentAngle, aimAngle, 0.1f));
    }
}
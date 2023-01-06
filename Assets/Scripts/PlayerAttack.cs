using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public float attack = 1;
    public float attackspeed = 1;

    public List<GameObject> weapons;
    List<Vector3> weaponPositions = new List<Vector3>();

    bool canAttack = true;


    VisionRadius _visionRadius;
    // Start is called before the first frame update
    void Start()
    {
        _visionRadius = GetComponentInChildren<VisionRadius>();
        
        for(int i = 0; i<weapons.Count;i++)
        {
            weaponPositions.Add( new Vector3(0,0,0) );
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(_visionRadius.enemyInSight.Count > 0 && canAttack)
        {
            canAttack = false;
            Invoke("Rearm",2);
            Attack(_visionRadius.enemyInSight[0]);
        }
    }

    void Attack(GameObject enemy)
    {
        enemy.GetComponent<EnemyStats>().health -= attack;
        SaveWeaponPositions();

        for(int i = 0; i<weapons.Count;i++)
        {
                weapons[i].GetComponent<Transform>().position = enemy.GetComponent<Transform>().position;
        }
    }

    void Rearm()
    {
       canAttack = true;

        for(int i = 0; i<weapons.Count;i++)
        {
                weapons[i].GetComponent<Transform>().position = weaponPositions[i];
        }
    }

    void SaveWeaponPositions()
    {
        for(int i = 0; i<weapons.Count;i++)
        {
            weaponPositions[i] = weapons[i].GetComponent<Transform>().position;
        }
    }
}

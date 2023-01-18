using UnityEngine;

public class Honey : MonoBehaviour
{
    public PlayerItems playerItems;
    public float xpGain = 1;
    public float hpGain = 1;
    
    void Start()
    {
        playerItems = FindObjectOfType<PlayerItems>();
    }
    
    public void Effect()
    {
        playerItems.xp += xpGain;
        Vanish();
    }

    void Vanish()
    {
        Destroy(gameObject);
    }
}

using UnityEngine;

public class Honey : MonoBehaviour
{
    public PlayerStats playerItems;
    public float xpGain = 1;
    
    void Start()
    {
        playerItems = FindObjectOfType<PlayerStats>();
    }
    
    public void TriggerEffect()
    {
        playerItems.AddXP(xpGain);
        Destroy(gameObject);
    }
}

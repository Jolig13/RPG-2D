using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "RPG 2D/PlayerData", order = 0)]
public class PlayerData : ScriptableObject
{
    public float Health;
    public float currentHealth;
    public float damage;   
    public float speedMove;

}


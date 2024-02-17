using UnityEngine;

[CreateAssetMenu(fileName = "Bullets", menuName = "Bullet", order = 51)]
public class BulletBaseData : ScriptableObject
{
    [SerializeField] protected int damage;
    [SerializeField] protected float speed;

    public int GetDamage { get { return damage; } }
    public float GetSpeed { get { return speed; } }
}

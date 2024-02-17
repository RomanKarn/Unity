using UnityEngine;

[CreateAssetMenu(fileName = "Etems", menuName = "Heals", order = 51)]
public class HealsEtemsBaseData : ScriptableObject
{
    [SerializeField] protected int heals;
    [SerializeField] protected float speed;
    [SerializeField] private float chanceSpavn;
    [SerializeField] private Sprite spriteHealse;
    public int GetHalse { get { return heals; } }
    public float GetSpeed { get { return speed; } }
    public float GetChanceSpavn { get { return chanceSpavn; } }
    public Sprite GetSpriteHealse { get { return spriteHealse; } }
}

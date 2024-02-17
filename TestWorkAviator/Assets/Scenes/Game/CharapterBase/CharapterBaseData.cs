using UnityEngine;

[CreateAssetMenu(fileName = "Charapters", menuName = "CharaptersData/CharapterBaseData", order = 51)]
public class CharapterBaseData : ScriptableObject
{
    [SerializeField] protected int healsPoint;
    [SerializeField] protected int healsPointMax;
    [SerializeField] protected float speed;
    [SerializeField] protected float speedShoot;

    public int HealsPoint 
    { 
        get { return healsPoint; } 
        set 
        {
            if (value < 0)
            {
                healsPoint = 0;
                return;
            }
            if (value > healsPointMax)
            {
                healsPoint = healsPointMax;
                return;
            }
            healsPoint = value;
        }
    }
    public int GetHealsPointMax { get { return healsPointMax; } }
    public float GetSpeed { get { return speed; } }
    public float GetSpeedShoot { get { return speedShoot; } }

}

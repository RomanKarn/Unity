using UnityEngine;

public class Healsing : MonoBehaviour
{
    private HealsEtemsBaseData healsingData;
    private MoveBase moveHeals;
    private Vector3 finalPoint;
    public void Initcalizashion(HealsEtemsBaseData heals, Vector3 targetMoive, GameObject healsePrefab)
    {
        this.healsingData = heals;
        this.GetComponent<SpriteRenderer>().sprite = heals.GetSpriteHealse;
        moveHeals = new MoveBase(this.transform, targetMoive, heals.GetSpeed);
        finalPoint = targetMoive;

    }
    private void FixedUpdate()
    {
        moveHeals.MoveUpdate();
        EndPointFinish();
    }

    private void EndPointFinish()
    {
        if (this.transform.position == finalPoint)
            Disable();
    }

    public void Disable()
    {
        this.transform.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ICanHealsing>() != null)
        {
            collision.GetComponent<ICanHealsing>().Healsing(healsingData.GetHalse);
            Disable();
        }

    }
}

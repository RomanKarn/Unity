using UnityEngine;

public class Bullet : MonoBehaviour
{
    private BulletBaseData bullet;
    private MoveBase moveBullet;
    private Vector3 finalPoint;
    public void Initcalizashion(BulletBaseData bullet, Vector3 targetMoive)
    {
        this.bullet = bullet;
        moveBullet = new MoveBase(this.transform, targetMoive, bullet.GetSpeed);
        finalPoint = targetMoive;
    }

    void FixedUpdate()
    {
        moveBullet.MoveUpdate();
        EndPointFinish();
    }
    private void EndPointFinish()
    {
        if (this.transform.position == finalPoint)
            DisableBullet();
    }

    public void DisableBullet()
    {
        this.transform.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<ITakeDamage>() != null)
        {
            collision.GetComponent<ITakeDamage>().TakeDamage(bullet.GetDamage);
            DisableBullet();
        }
            
    }
}

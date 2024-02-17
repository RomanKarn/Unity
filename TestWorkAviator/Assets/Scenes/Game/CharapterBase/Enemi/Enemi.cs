using UnityEngine;
using System.Collections;

public class Enemi : MonoBehaviour, ITakeDamage
{
    private EnemiCharapterData enemi;
    private MoveBase moveEnemi;
    private Vector3 finalPoint;
    private BaseShoot shootEneni;
    

    private Vector3 whenForvard;
    public void Initcalizashion(EnemiCharapterData enemi, Vector3 targetMoive, GameObject bulletPrefab, BulletBaseData bulletData, PoolObgect globalPullBullet)
    {
        this.enemi = enemi;
        this.enemi.HealsPoint = enemi.GetHealsPointMax;
        moveEnemi = new MoveBase(this.transform, targetMoive, enemi.GetSpeed);
        whenForvard = targetMoive - this.transform.position;
        shootEneni = new BaseShoot(bulletPrefab, bulletData, this.transform, globalPullBullet, whenForvard);
        finalPoint = targetMoive;

        StartCoroutine(ShootTimer());
    }

    private void FixedUpdate()
    {
        moveEnemi.MoveUpdate();
        EndPointFinish();
    }
    
    private void EndPointFinish()
    {
        if(this.transform.position == finalPoint)
            DisableEnemi();
    }

    public void DisableEnemi()
    {
        this.transform.gameObject.SetActive(false);
    }

    private IEnumerator ShootTimer()
    {
        while (true)
        {
            shootEneni.Shoot();
            yield return new WaitForSeconds(enemi.GetSpeedShoot);
        }
    }

    public void TakeDamage(int damage)
    {
        enemi.HealsPoint = enemi.HealsPoint - damage;
        if (enemi.HealsPoint <= 0)
        {
            DisableEnemi();
            Score.AddScore(enemi.GetPoint);
        }

    }
}

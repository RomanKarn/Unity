using System;
using System.Collections;
using UnityEngine;

public class Plaer : MonoBehaviour, ITakeDamage, ICanHealsing
{  
    public event Action<int> PlaerTakeColDamag;
    public event Action<int> PlaerTakeColHalsing;
    public event Action PlaerGameOver;

    private CharapterBaseData plaer; 
    private MoveBase movePlaer;
    private BaseShoot shootPlaer;
    private Vector3 hashMoveTarget;

    private Vector3 whenForvard;
    private bool plaerCanMove=true;
    private IEnumerator shootInum;
    private PoolObgect pullBullet;
    public void Initcalizashion(CharapterBaseData plaer,GameObject bulletPrefab, BulletBaseData bulletData)
    {
        this.plaer = plaer;
        this.plaer.HealsPoint = plaer.GetHealsPointMax;
        whenForvard = hashMoveTarget - this.transform.position;
        pullBullet = new PoolObgect(bulletPrefab, 3, new GameObject("PullBulletPlaer").transform, true);
        shootPlaer = new BaseShoot(bulletPrefab, bulletData,this.transform, pullBullet, whenForvard);
        movePlaer = new MovePlaer(this.transform, this.transform.position, plaer.GetSpeed);
        hashMoveTarget = this.transform.position;
        StartShoot();
    }

    private void FixedUpdate()
    {
        movePlaer.MoveUpdate(hashMoveTarget);
        whenForvard = hashMoveTarget - this.transform.position;
    }

    public void SetTargetMove(Vector3? target)
    {
        if (!plaerCanMove)
            return;
        if(target != null)
            hashMoveTarget = (Vector3)target;
    }
    private void StartShoot()
    {
        shootInum = ShootTimer();
        StartCoroutine(shootInum);
    }
    private void StopShoot()
    {
        StopCoroutine(shootInum);
    }
    private IEnumerator ShootTimer()
    {
        while(true)
        {
            shootPlaer.Shoot();
            yield return new WaitForSeconds(plaer.GetSpeedShoot);
        }
    }

    public void TakeDamage(int damage)
    {
        plaer.HealsPoint = plaer.HealsPoint - damage;
        PlaerTakeColDamag?.Invoke(damage);
        if (plaer.HealsPoint <= 0)
        {
            PlaerGameOver?.Invoke();
            StopShoot();
            plaerCanMove = false;
            foreach (var item in pullBullet.ReturnListElements())
            {
                item.gameObject.SetActive(false);
            }
            this.gameObject.SetActive(false);

        }
    }

    public void Healsing(int heals)
    {
        plaer.HealsPoint = plaer.HealsPoint + heals;
        PlaerTakeColHalsing?.Invoke(heals);
    }
}

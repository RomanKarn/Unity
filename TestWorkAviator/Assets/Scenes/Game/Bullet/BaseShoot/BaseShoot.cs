using UnityEngine;

public class BaseShoot
{
    private PoolObgect bulletPool;
    private GameObject bulletPrefab;
    private BulletBaseData bulletData;
    private Transform spavnPoint;
    private Vector3 foravardShoot;
    public BaseShoot(GameObject bulletPrefab, BulletBaseData bulletData, Transform spavnPoint, Transform paretPull, Vector3 forvard)
    {
        this.bulletData = bulletData;
        this.bulletPrefab = bulletPrefab;
        this.spavnPoint = spavnPoint;
        foravardShoot = forvard.normalized;
        bulletPool = new PoolObgect(bulletPrefab, 3, paretPull, true);
    }
    public BaseShoot(GameObject bulletPrefab, BulletBaseData bulletData, Transform spavnPoint, PoolObgect poolObgect, Vector3 forvard)
    {
        this.bulletData = bulletData;
        this.bulletPrefab = bulletPrefab;
        this.spavnPoint = spavnPoint;
        foravardShoot = forvard.normalized;
        bulletPool = poolObgect;
    }
    public virtual void Shoot()
    {
        Vector3 posisionSpavn = new Vector3(spavnPoint.position.x+1*foravardShoot.x, spavnPoint.position.y + bulletPrefab.transform.localScale.y * foravardShoot.y, 0f);
        Bullet bullet = bulletPool.GetFreeElement().GetComponent<Bullet>();
        bullet.transform.position = posisionSpavn;
        bullet.Initcalizashion(bulletData, new Vector3(posisionSpavn.x+1 * foravardShoot.x, posisionSpavn.y + 10f * foravardShoot.y, posisionSpavn.z));
    }
}

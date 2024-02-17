using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spavner : MonoBehaviour
{
    private GameObject prefabEnemi;
    private EnemiCharapterData enemiData;
    private GameObject enemiBulletPrefab;
    private BulletBaseData enemiBulletData;
    private PoolObgect globalPullBullet;

    private GameObject healsingPrefab;
    private List<HealsEtemsBaseData> healsingData;

    private RangeSavn rangeSpavn;
    private float moveEndPosihionY;

    private PoolObgect poolEnemi;
    private PoolObgect poolHealse;

    private IEnumerator enemiSpavnInum;
    private IEnumerator itemSpavnInum;
    public void Initcalizashion(GameObject enemi, EnemiCharapterData enemiCarapter, GameObject bulletPrefab, 
        BulletBaseData bulletData, GameObject healsPrefab, List<HealsEtemsBaseData> healseData, Plaer plaer)
    {
        prefabEnemi = enemi;
        enemiData = enemiCarapter;
        enemiBulletPrefab= bulletPrefab;
        enemiBulletData = bulletData;
        healsingPrefab = healsPrefab;
        healsingData = healseData;

        if (globalPullBullet == null)
        {
            globalPullBullet = new PoolObgect(bulletPrefab, 15, new GameObject("PullBulletEnemiGlobal").transform, true);
        }

        rangeSpavn = new RangeSavn(Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0f)), Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, 0)));
        moveEndPosihionY = Camera.main.ViewportToWorldPoint(new Vector3(0, 0f, 0f)).y- prefabEnemi.transform.localScale.y;
        poolEnemi = new PoolObgect(prefabEnemi,10,this.transform,true);
        poolHealse = new PoolObgect(healsPrefab, 10, this.transform, true);
        StartSpavn();
        plaer.PlaerGameOver += GameOver;
    }

    private void GameOver()
    {
        StopSpavn();

        foreach ( var item in poolEnemi.ReturnListElements() ) 
        {
            item.gameObject.SetActive(false);
        }
        foreach (var item in poolHealse.ReturnListElements())
        {
            item.gameObject.SetActive(false);
        }
        foreach (var item in globalPullBullet.ReturnListElements())
        {
            item.gameObject.SetActive(false);
        }
    }

    private void StartSpavn()
    {
        enemiSpavnInum = SpavnEnemi();
        itemSpavnInum = SpavnEtem();
        StartCoroutine(enemiSpavnInum);
        StartCoroutine(itemSpavnInum);
    }
    private void StopSpavn()
    {
        StopCoroutine(enemiSpavnInum);
        StopCoroutine(itemSpavnInum);
    }

    private IEnumerator SpavnEnemi()
    {
        while (true)
        {
            var rendomPosishionSpavnX = Random.Range(rangeSpavn.Left.x, rangeSpavn.Right.x);
            Vector3 posisionSpavn = new Vector3 (rendomPosishionSpavnX,rangeSpavn.Left.y + prefabEnemi.transform.localScale.y, 0f);
            Enemi enemi = poolEnemi.GetFreeElement().GetComponent<Enemi>();
            enemi.transform.position = posisionSpavn;
            enemi.Initcalizashion(enemiData, new Vector3(enemi.transform.position.x, moveEndPosihionY,enemi.transform.position.z), 
                enemiBulletPrefab, enemiBulletData, globalPullBullet);
            yield return new WaitForSeconds(1.5f);
        }

    }

    private IEnumerator SpavnEtem()
    {
        while (true)
        {
            var rendomPosishionSpavnX = Random.Range(rangeSpavn.Left.x, rangeSpavn.Right.x);
            Vector3 posisionSpavn = new Vector3(rendomPosishionSpavnX, rangeSpavn.Left.y + prefabEnemi.transform.localScale.y, 0f);
            Healsing helase = poolHealse.GetFreeElement().GetComponent<Healsing>();
            helase.transform.position = posisionSpavn;
            helase.Initcalizashion(GetRandomHealse(), new Vector3(helase.transform.position.x, moveEndPosihionY, helase.transform.position.z), healsingPrefab);
            yield return new WaitForSeconds(4f);
        }

    }

    private HealsEtemsBaseData GetRandomHealse()
    {
        List<float> chanse = new List<float>();
        foreach (var healse in healsingData)
        {
            chanse.Add(healse.GetChanceSpavn);
        }

        float value = Random.Range(0, chanse.Sum());
        float sum = 0;

        for (int i = 0; i < chanse.Count; i++)
        {
            sum += chanse[i];
            if (value < sum)
            {
                return healsingData[i];
            }
        }

        return healsingData[healsingData.Count - 1]; ;
    }
}

public struct RangeSavn
{
    public Vector3 Left { get; set; }
    public Vector3 Right { get; set; }
    public RangeSavn(Vector3 left, Vector3 right)
    {
        Left = left;
        Right = right;
    }
}

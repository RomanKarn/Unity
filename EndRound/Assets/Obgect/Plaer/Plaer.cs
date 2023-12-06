using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.Arm;

public class Plaer : MonoBehaviour, IMovoble, IInit
{
    [SerializeField] private Sprite VeponCatolic;
    [SerializeField] private Sprite VeponPravos;
    [SerializeField] private Sprite VeponIslam;
    [SerializeField] private SpriteRenderer VeponNow;
    [SerializeField] private Animator AnimashionClouse;

    [SerializeField] private SpriteRenderer ButtonE;

    private GameObject[] clous;
    private TriggerpointClouse[] clousTriget;
    private GameObject[] vepon;
    private TriggerPointVepon[] veponTriget;

    [SerializeField] private float speed;
    [SerializeField] private bool plaerTakeObg=false;
    [SerializeField] private ICanTake canTakeObgPlaer=null;
    [SerializeField] private ICanTake takeObgPlaer = null;
    [SerializeField] private ICanEnteractive canUseObgPlaer = null;
    private Rigidbody2D plaerBody;
    public void Init()
    {
        plaerBody = GetComponent<Rigidbody2D>();


        clous = GameObject.FindGameObjectsWithTag("TriggerPointClouse");
        clousTriget = new TriggerpointClouse[clous.Length];
        for (int i = 0; i < clous.Length; i++)
        {
            clousTriget[i] = clous[i].GetComponent<TriggerpointClouse>();
            clousTriget[i].EnableClouse += SwitchAtrebutClouse;
        }

        vepon = GameObject.FindGameObjectsWithTag("TriggerPointVepon");
        veponTriget = new TriggerPointVepon[vepon.Length];
        for (int i = 0; i < vepon.Length; i++)
        {
            veponTriget[i] = vepon[i].GetComponent<TriggerPointVepon>();
            veponTriget[i].EnableVepon += SwitchAtrebutVepon;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<ICanTake>() !=null)
        {
            canTakeObgPlaer = collision.GetComponent<ICanTake>();
            ButtonE.enabled = true;
        }
        if (collision.GetComponent<ICanEnteractive>() != null)
        {
            canUseObgPlaer = collision.GetComponent<ICanEnteractive>();
            ButtonE.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<ICanTake>() != null)
        {
            ButtonE.enabled = false;
            canTakeObgPlaer = null;
        }
        if (collision.GetComponent<ICanEnteractive>() != null)
        {
            ButtonE.enabled = false;
            canUseObgPlaer = null;
        }
    }
    public void Update() 
    {
        TakeObg();
        UseObg();
    }

    private void TakeObg()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!plaerTakeObg)
            {
                if (canTakeObgPlaer != null)
                {
                    takeObgPlaer = canTakeObgPlaer;
                    takeObgPlaer.ObgTake(this.transform);
                    plaerTakeObg = true;
                }
            }
            else
            {
                takeObgPlaer.ObgDrop();
                takeObgPlaer=null;
                plaerTakeObg = false;
            }
        }
    }

    private void UseObg()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (canUseObgPlaer != null)
            {
                canUseObgPlaer.UseObgetc();
            }
        }
    }
    public void Move(Vector2 position)
    {
        if (position != new Vector2(0f,0f))
        {
            AnimashionClouse.SetBool("Go", true);
            plaerBody.MovePosition((Vector2)transform.position + position * Time.deltaTime * speed);
        }
        else
        {
            AnimashionClouse.SetBool("Go", false);
        }
    }

    private void SwitchAtrebutClouse(EnumClouse nowClouse)
    {
        switch (nowClouse)
        {
            case EnumClouse.Hresian:
                AnimashionClouse.SetTrigger("EcvipPravos");
                break;
            case EnumClouse.Islam:
                AnimashionClouse.SetTrigger("EcvipIslam");
                break;
            case EnumClouse.Cotolik:
                AnimashionClouse.SetTrigger("EcvipCotolic");
                break;
        }
    }
    private void SwitchAtrebutVepon(EnumVapen nowVepon)
    {
        switch (nowVepon)
        {
            case EnumVapen.Hresian:
                VeponNow.sprite = VeponPravos;
                break;
            case EnumVapen.Islam:
                VeponNow.sprite = VeponIslam;
                break;
            case EnumVapen.Cotolik:
                VeponNow.sprite = VeponCatolic;
                break;
        }
    }
}

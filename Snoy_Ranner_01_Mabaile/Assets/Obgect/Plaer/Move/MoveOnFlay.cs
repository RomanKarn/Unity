using System.Collections;
using UnityEngine;
using Score;

namespace Move
{
    public class MoveOnFlay : MonoBehaviour, ITruks
    {
        [SerializeField] private Animator animatorPlaer;
        [SerializeField] private ConfigurableJoint joinPlaer;
        [SerializeField] private ScoreCalkulateByTruks trukScoreCalkulate;
        private ConfigurableJoint configyreJoin;
        private Transform plaerRotasion;
        private float plaerRotashionLocalHeshX;
        private float plaerRotashionLocalHeshY;
        private bool moveForvordHesh;


        [SerializeField] private Rigidbody plaer;
        [SerializeField] private AnimationCurve speedExponend;
        private bool trukEnable = false;
        private Vector3 vectorForse;
        private float speed;
        private float timeForFors=0;
        void Start()
        {
            this.configyreJoin = this.GetComponent<ConfigurableJoint>();
            this.plaerRotasion = this.GetComponent<Transform>();
            this.plaerRotashionLocalHeshX = 0;

        }
        void FixedUpdate()
        {
            RotasionPlaerX();
            RotasionPlaerY();
            Stabilizate();
            ForseInTruks();
        }
        public void RotashionX(float sceilRotasion)
        {
            plaerRotashionLocalHeshX = sceilRotasion*2;
        }
        public void RotashionY(float sceilRotasion, bool moveForvord)
        {
            plaerRotashionLocalHeshY = sceilRotasion * 2;
            moveForvordHesh = moveForvord;
        }

        
        public void SolevoiTruk(bool playTruk)
        {
            if (playTruk)
            {
                trukEnable = !trukEnable;
                vectorForse = plaer.velocity;
                speed = plaer.velocity.magnitude;
                animatorPlaer.enabled = true;
                animatorPlaer.Rebind();
                animatorPlaer.SetBool("SolevoiTrucs", true);
                trukScoreCalkulate.StartTimer("SolevoiTrucs");
            }
            else
            {
                trukEnable = !trukEnable;
                vectorForse = plaer.velocity;
                speed = plaer.velocity.magnitude;
                ForseOutTruks();
                timeForFors = 0;
                animatorPlaer.SetBool("SolevoiTrucs", false);
                trukScoreCalkulate.StopTimer();
            }
            
        }

        public void RotashionDoynHeadTruk(bool playTruk)
        {
            if (playTruk)
            {
                trukEnable = !trukEnable;
                vectorForse = plaer.velocity;
                speed = plaer.velocity.magnitude;
                animatorPlaer.enabled = true;
                animatorPlaer.enabled = true;
                animatorPlaer.Rebind();
                animatorPlaer.SetBool("RotashionDoynHeadTruk", true);
                trukScoreCalkulate.StartTimer("RotashionDoynHeadTruk");
            }
            else
            {
                trukEnable = !trukEnable;
                vectorForse = plaer.velocity;
                speed = plaer.velocity.magnitude;
                ForseOutTruks();
                timeForFors = 0;
                animatorPlaer.SetBool("RotashionDoynHeadTruk", false);
                trukScoreCalkulate.StopTimer();
            }
        }


        private bool rotasionX =false;
        private void RotasionPlaerX()
        {
            
            plaerRotasion.Rotate(Vector3.up, plaerRotashionLocalHeshX * Time.fixedDeltaTime);
            if (plaerRotashionLocalHeshX != 0)
            {
                RotasionTrukDetatedEnableX();
            }
            if (plaerRotashionLocalHeshX == 0)
            {
                RotasionTrukDetatedDisableX();
            }
        }
        
        private void RotasionTrukDetatedEnableX()
        {
            if (rotasionX)
                return;
            trukScoreCalkulate.StartTimer("plaerRotashionLocalX");
            rotasionX = true;
        }
        private void RotasionTrukDetatedDisableX()
        {
            if (!rotasionX)
                return;
            trukScoreCalkulate.StopTimer();
            rotasionX = false;
        }
        private void RotasionPlaerY()
        {
            if (!moveForvordHesh)
            {
                plaerRotashionLocalHeshY *= 1;
            }
            plaerRotasion.Rotate(Vector3.left, plaerRotashionLocalHeshY * Time.fixedDeltaTime);

            if (plaerRotashionLocalHeshY != 0)
            {
                RotasionTrukDetatedEnableY();
            }
            if (plaerRotashionLocalHeshY == 0)
            {
                RotasionTrukDetatedDisableY();
            }
        }
        private bool rotasionY = false;
        private void RotasionTrukDetatedEnableY()
        {
            if (rotasionY)
                return;
            trukScoreCalkulate.StartTimer("plaerRotashionLocalY");
            rotasionY = true;
        }
        private void RotasionTrukDetatedDisableY()
        {
            if (!rotasionY)
                return;
            trukScoreCalkulate.StopTimer();
            rotasionY = false;
        }
        private void Stabilizate()
        {
            JointDrive driveZiro = new JointDrive();
            driveZiro.positionSpring = 30;
            driveZiro.positionDamper = 200;
            driveZiro.maximumForce = 1000;
            configyreJoin.slerpDrive = driveZiro;
            
            if (moveForvordHesh)
            {
                configyreJoin.targetRotation = Quaternion.Euler(0f, 0f, 0f);
            }
            else
            {
                configyreJoin.targetRotation = Quaternion.Euler(0f, 180f, 0f);
            }
            
            if ((Angele.CalkylateAngel.AngelZ(transform) - 90)>10)
            {
                plaerRotasion.Rotate(Vector3.forward, 100f * Time.fixedDeltaTime);
            }
            if ((Angele.CalkylateAngel.AngelZ(transform) - 90) < -10)
            {
                plaerRotasion.Rotate(Vector3.back, 100f * Time.fixedDeltaTime);
            }
        }
    
        private void ForseInTruks()
        {
            if (trukEnable)
            {
                timeForFors += 0.01f;
                plaer.AddForce(vectorForse * speed * 10f* speedExponend.Evaluate(timeForFors));
                plaer.AddForce(Vector3.down * 9.8f * 100f * 1/speedExponend.Evaluate(timeForFors));
            }
        }
        private void ForseOutTruks()
        {
            plaer.AddForce(vectorForse * speed * 30f,ForceMode.Acceleration);
        }
    }
}
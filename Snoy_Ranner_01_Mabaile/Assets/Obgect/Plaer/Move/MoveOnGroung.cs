using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Move
{
    public class MoveOnGroung : MonoBehaviour, IMoving, IRotashion
    {
        [SerializeField] private float poverForceJump;
        [SerializeField] private float poverForce;
        [SerializeField] private float poverForceRidth;
        [SerializeField] private float maxSpeed;
        [SerializeField] private float sceilGravitashion;
        [SerializeField] private float nitroPoverForce;
        [SerializeField] private float nitroMaxSpeed;
        [SerializeField] private Vector3 centerMass;
        private bool nitroAnable;

        [SerializeField] private AnimationCurve speedExponend;
        [SerializeField] private AnimationCurve agelDrag;
        [SerializeField] private AnimationCurve agelRotasionX;
        [SerializeField] private AnimationCurve maxSpeedForEllerAngen;
        [SerializeField] private AnimationCurve stabilitySceil;
        [SerializeField] private AnimationCurve stabilitySceilForg;

        private ConfigurableJoint configyreJoin;
        private Rigidbody plaerRigidBodi;
        private Transform plaerTransformLocal;
        private Transform plaerRotasion;

        private float plaerRotashionLocalHesh;
        private bool moveForvordHesh=true;
        JointDrive stabilazeteSceil;
        void Start()
        {
            this.configyreJoin=this.GetComponent<ConfigurableJoint>();
            this.plaerRigidBodi=this.GetComponent<Rigidbody>();
            this.plaerRigidBodi.centerOfMass = centerMass;

            this.plaerRotasion=this.GetComponent<Transform>();
            this.plaerTransformLocal = this.GetComponent<Transform>();
            this.plaerRotashionLocalHesh = 0;

            stabilazeteSceil.positionSpring = configyreJoin.slerpDrive.positionSpring;
            stabilazeteSceil.positionDamper = configyreJoin.slerpDrive.positionDamper;
            stabilazeteSceil.maximumForce = configyreJoin.slerpDrive.maximumForce;
        }


        void FixedUpdate()
        {
            Stabilizate();
            MovePlaer();
            RotasionPlaer();            
        }
        public void Move(bool moveForvord)
        {
            moveForvordHesh= moveForvord;
        }
        private void MovePlaer()
        {
            float maxSpeedFinal;
            if (moveForvordHesh)
            {
                maxSpeedFinal = maxSpeed* maxSpeedForEllerAngen.Evaluate(plaerRotasion.rotation.eulerAngles.x);
            }
            else
            {
                maxSpeedFinal = maxSpeed * maxSpeedForEllerAngen.Evaluate(-1 * (plaerRotasion.rotation.eulerAngles.x - 360));
            }
            if (plaerRigidBodi.velocity.magnitude < maxSpeedFinal)
            {
                if (moveForvordHesh)
                {
                    plaerRigidBodi.AddRelativeForce(plaerTransformLocal.forward * poverForce * 1.2f * speedExponend.Evaluate(Angele.CalkylateAngel.AngelY(transform)));
                    plaerRigidBodi.drag = agelDrag.Evaluate(transform.rotation.eulerAngles.y);
                }
                else
                {
                    plaerRigidBodi.AddRelativeForce(plaerTransformLocal.forward * poverForce *0.8f * speedExponend.Evaluate(Angele.CalkylateAngel.AngelY(transform)));
                    plaerRigidBodi.drag=agelDrag.Evaluate(transform.rotation.eulerAngles.y);
                }


            }
        }
        public void Jump()
        {
            plaerRigidBodi.AddForce(plaerTransformLocal.up * poverForceJump, ForceMode.Impulse);
        }
        public void NitroInMomentTochGround() 
        {
            plaerRigidBodi.AddRelativeForce(plaerTransformLocal.forward * plaerRigidBodi.velocity.magnitude*10f, ForceMode.Impulse);
        }
        public void Rotashion(float sceilRotasion)
        {
            plaerRotashionLocalHesh = sceilRotasion;
          
        }
        private void RotasionPlaer()
        {
            plaerRotasion.Rotate(Vector3.up, plaerRotashionLocalHesh * Time.fixedDeltaTime);
           
        }
   
        private void NitroSpeedActive()
        {
            nitroAnable = true;
            poverForce += nitroPoverForce;
            maxSpeed += nitroMaxSpeed;
        }
        private void NitroSpeedDisable()
        {
            nitroAnable = false;
            poverForce -= nitroPoverForce;
            maxSpeed -= nitroMaxSpeed;
        }
        private void OnCollisionEnter(Collision collision)
        {
            if ((collision.transform.tag == "SpeedPlatform") && (!nitroAnable))
            {
                NitroSpeedActive();
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if ((collision.transform.tag == "SpeedPlatform") && (nitroAnable))
            {
                NitroSpeedDisable();
            }
        }

        private void Stabilizate()
        {
            JointDrive chesheStabilazeteSceil = new JointDrive();
            chesheStabilazeteSceil.positionSpring = stabilazeteSceil.positionSpring * stabilitySceil.Evaluate(Angele.CalkylateAngel.AngelZ(plaerTransformLocal) - 90);
            chesheStabilazeteSceil.positionDamper = stabilazeteSceil.positionDamper;
            chesheStabilazeteSceil.maximumForce = stabilazeteSceil.maximumForce;
            configyreJoin.slerpDrive = chesheStabilazeteSceil;
            if (moveForvordHesh)
            {
                configyreJoin.targetRotation = Quaternion.Euler(0f,0f,0f);
            }
            else
            {
                configyreJoin.targetRotation = Quaternion.Euler(0f, 180f, 0f);
            }
        }

    }
}
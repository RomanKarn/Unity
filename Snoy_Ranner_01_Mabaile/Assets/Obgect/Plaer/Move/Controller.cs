using UnityEngine;
using State;

namespace Move
{
    public class Controller : MonoBehaviour
    {
        [SerializeField] private StateMashin stateMashin;
        [SerializeField] private RayCastControllerAndroind controllerAndroid;
        [SerializeField] private float sceilRotasionX;
        private float gradusRotasionX;

        [SerializeField] private float sceilRotasionY;
        private float gradusRotasionY;

        public bool moveForvord{ private set; get; } = true; //ПОнимаем едим мы задом или передом
        private Transform plaerRotasion;

        private IMoving moveController;
        private IRotashion rotasionController;
        private ITruks truksController;

        private bool muveGround;
        private bool dead=false;
        void Start()
        {
            this.plaerRotasion = this.GetComponent<Transform>();
            stateMashin.svitchStateMove += SelectStateMove;
            stateMashin.svitchStateFlay += SelectStateFlay;
            stateMashin.svitchStateDaed += SelectStateDead;
            this.moveController = this.GetComponent<IMoving>();
            this.rotasionController = this.GetComponent<IRotashion>();
            this.truksController = this.GetComponent<ITruks>();
        }

        void Update()
        {
            if (dead)
                return;
            if(muveGround)
            {
               MoveGround();
            }
            else
            {
                MoveFlay();
            }
            EkpendetToZeroRotasion();
        }

        public void RotasionLeftX()
        {
            gradusRotasionX = -sceilRotasionX;
            if (Angele.CalkylateAngel.AngelY(transform)<90)
            {
                moveForvord = true;
            }
            else
            {
                moveForvord = false;
            }
        }

        public void RotasionRigthX()
        {
            gradusRotasionX = +sceilRotasionX;
            if (Angele.CalkylateAngel.AngelY(transform) < 90)
            {
                moveForvord = true;
            }
            else
            {
                moveForvord = false;
            }
        }
        public void RotasionForvordY()
        {
            gradusRotasionY = -sceilRotasionY;
        }

        public void RotasionDownY()
        {
            gradusRotasionY = sceilRotasionY;
        }


        private void MoveGround()
        {
            if (Input.GetKey(KeyCode.A)|| controllerAndroid.ButtonGet("Left"))
            {
                RotasionLeftX();
            }
            if (Input.GetKey(KeyCode.D) || controllerAndroid.ButtonGet("Rigth"))
            {
                RotasionRigthX();
            }
            if (Input.GetKeyDown(KeyCode.Space) || controllerAndroid.ButtonDown("Jump"))
            {
                moveController.Jump();
            }
            moveController.Move(moveForvord);
            rotasionController.Rotashion(gradusRotasionX);
        }

        private void MoveFlay()
        {
            if (Input.GetKey(KeyCode.W) || controllerAndroid.ButtonGet("Up"))
            {
                RotasionForvordY();
            }
            if (Input.GetKey(KeyCode.S) || controllerAndroid.ButtonGet("Down"))
            {
                RotasionDownY();
            }
            if (Input.GetKey(KeyCode.A) || controllerAndroid.ButtonGet("Left"))
            {
                RotasionLeftX();
            }
            if (Input.GetKey(KeyCode.D) || controllerAndroid.ButtonGet("Rigth"))
            {
                RotasionRigthX();
            }
            if (Input.GetKeyDown(KeyCode.E) || controllerAndroid.ButtonDown("Truks1"))
            {
                truksController.SolevoiTruk(true);
            }
            if (Input.GetKeyUp(KeyCode.E) || controllerAndroid.ButtonUp("Truks1"))
            {
                truksController.SolevoiTruk(false);
            }
            if (Input.GetKeyDown(KeyCode.R) || controllerAndroid.ButtonDown("Truks2"))
            {
                truksController.RotashionDoynHeadTruk(true);
            }
            if (Input.GetKeyUp(KeyCode.R) || controllerAndroid.ButtonUp("Truks2"))
            {
                truksController.RotashionDoynHeadTruk(false);
            }
            truksController.RotashionX(gradusRotasionX);
            truksController.RotashionY(gradusRotasionY, moveForvord);
        }
        private void EkpendetToZeroRotasion()
        {
            if(gradusRotasionX != 0)
            {
                gradusRotasionX = 0;
            }
            if (gradusRotasionY != 0)
            {
                gradusRotasionY = 0;
            }
        }
        private void SelectStateMove()
        {
            this.GetComponent<MoveOnGroung>().enabled = true;
            this.GetComponent<MoveOnFlay>().enabled = false;
            muveGround = true;
        }
        private void SelectStateFlay()
        {
            
             this.GetComponent<MoveOnGroung>().enabled = false;
             this.GetComponent<MoveOnFlay>().enabled = true;
            muveGround = false;
            if (Angele.CalkylateAngel.AngelY(transform) < 90)
            {
                moveForvord = true;
            }
            else
            {
                moveForvord = false;
            }
        }
        private void SelectStateDead()
        {
            this.GetComponent<MoveOnGroung>().enabled = false;
            this.GetComponent<MoveOnFlay>().enabled = false;
            dead = true;
        }
    
    
    }
}
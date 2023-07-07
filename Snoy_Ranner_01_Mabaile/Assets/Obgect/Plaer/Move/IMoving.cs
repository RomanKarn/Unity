
namespace Move
{
    public interface IMoving
    {
        public void Move(bool moveForvord);
        public void Jump();

        public void NitroInMomentTochGround();
    }
}
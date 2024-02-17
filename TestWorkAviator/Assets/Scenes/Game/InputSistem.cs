using UnityEngine;
public class InputSistem 
{
    private Touch touch;
    public InputSistem()
    {
    }

    public Vector3? GetPointMove()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            return Camera.main.ScreenToWorldPoint(touch.position);
        }
        return null;

    }
}

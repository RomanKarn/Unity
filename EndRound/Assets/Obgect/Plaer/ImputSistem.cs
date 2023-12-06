using UnityEngine;

public class ImputSistem : MonoBehaviour, IInit
{
    private IMovoble move;
    private Vector2 m_Input;
    public void Init()
    {
        move = GetComponent<IMovoble>();
        if (move == null)
        {
            Debug.LogError(gameObject.name +" Not foind IMoveble");
            return;
        }
    }
    void Update()
    {
        MoveInput();
    }
    private void FixedUpdate()
    {
        move.Move(m_Input);
    }
    void MoveInput() 
    {
        m_Input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}


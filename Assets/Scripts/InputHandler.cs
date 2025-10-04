using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public Vector2 inputVector { get; private set; }

    public Vector3 MousePosition { get; private set; }

    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        inputVector = new Vector2(h, v);

        MousePosition = Input.mousePosition;
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 movement;
    [SerializeField] float speedsens;
    [SerializeField] float xrange;
    [SerializeField] float yrange;

    [SerializeField] float rotatecont;
    [SerializeField] float rotationspeed;
    [SerializeField] float pitchcont;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveProcess();
        RotateProcess();
    }

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    public void MoveProcess()
    {
        float xoffset = movement.x * Time.deltaTime * speedsens;
        float xpos = transform.localPosition.x + xoffset;
        float clampedXpos = Mathf.Clamp(xpos, -xrange, xrange);

        float yoffset = movement.y * Time.deltaTime * speedsens;
        float ypos = transform.localPosition.y + yoffset;
        float clampedYpos = Mathf.Clamp(ypos, -yrange, yrange);

        transform.localPosition = new Vector3(clampedXpos, clampedYpos, transform.localPosition.z);
    }

    public void RotateProcess()
    {
        Quaternion targetRotation = Quaternion.Euler(0, 0, movement.x * -rotatecont);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, rotationspeed * Time.deltaTime);

        Quaternion targetPitch = Quaternion.Euler(movement.y * -rotatecont * pitchcont , 0, 0);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetPitch, rotationspeed * Time.deltaTime);
    }
}

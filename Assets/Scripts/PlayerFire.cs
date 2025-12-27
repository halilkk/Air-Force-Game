using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance = 100f;

    bool isFire = false;

    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        FireProcess();
        CrosshairCont();
        MoveTargetPoint();
        AimLasers();
    }
    public void OnFire(InputValue value)
    {
        isFire = value.isPressed;
    }

    void FireProcess()
    {
        foreach(GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isFire;

        }
    }

    void CrosshairCont()
    {
        crosshair.position = Input.mousePosition;
    }

    void MoveTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Input.mousePosition.x,Input.mousePosition.y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }

    void AimLasers()
    {
        foreach (GameObject laser in lasers)
        {
        Vector3 fireDirection = targetPoint.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(fireDirection);
        laser.transform.rotation = targetRotation;
        }
    }
}
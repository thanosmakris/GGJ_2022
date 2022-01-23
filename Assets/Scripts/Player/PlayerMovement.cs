using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    public LayerMask whatIsGround;

    public Camera mainCam;


    private void Awake() {
        mainCam = Camera.main;
    }


    void Update()
    {
        Movement();
        Rotation();
    }


    void Movement()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(hor, 0f, ver);

        transform.position += direction * speed * Time.deltaTime;
    }


    public float offset;
    void Rotation()
    {
        Vector3 mousePosIn3D;
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, whatIsGround))
        {
            mousePosIn3D = hit.point;
        }
        else
        {
            mousePosIn3D = Vector3.zero;
        }
        Vector3 lookDir = mousePosIn3D - transform.position;
        float angle = Mathf.Atan2(lookDir.x, lookDir.z) * Mathf.Rad2Deg + offset;

        transform.rotation = Quaternion.Euler(0f, angle, 0f);
    }
}

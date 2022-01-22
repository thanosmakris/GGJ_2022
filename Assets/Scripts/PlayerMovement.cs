using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public Transform rotationParent;


    void Update()
    {
        Movement();
        Rotation();
    }


    void Movement()
    {
        float hor = Input.GetAxis("Horizontal") * Time.deltaTime;
        float ver = Input.GetAxis("Vertical") * Time.deltaTime;
        Vector3 direction = new Vector3(hor, 0f, ver);

        transform.position += direction * speed;
    }


    void Rotation()
    {
        if (Input.GetKey(KeyCode.Q)) // rotate LEFT
        {
            rotationParent.Rotate(Vector3.up * Time.deltaTime * -rotationSpeed);
        }

        else if (Input.GetKey(KeyCode.E)) // rotate RIGHT
        {
            rotationParent.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
        }
    }
}

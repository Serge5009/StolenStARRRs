using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float speed = 6.0f;

    void Start()
    {
        
    }

    void Update()
    {
        CheckInput();
    }

    void CheckInput()
    {

        float x = Input.GetAxis("Horizontal"); //  Get input
        float y = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(x, y, 0);   //  Get direction vector

        if(moveDirection.magnitude > 1) //  Limit this vector magnitude to 1
        {
            moveDirection = moveDirection / moveDirection.magnitude;
        }

        //Debug.Log(moveDirection);
        //Debug.Log(moveDirection.magnitude);

        transform.position += moveDirection * speed * Time.deltaTime;    //  Apply movement

    }
}

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
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float y = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.position += new Vector3(x, y, 0);

    }
}

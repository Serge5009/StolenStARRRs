using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    float rotSpeed = 20.0f;
    static private Vector3 rotVec = new Vector3(0, 0, 1);

    void Update()
    {
        this.transform.Rotate(rotVec, rotSpeed * Time.deltaTime);
    }
}


using UnityEngine;

public class ComplexEnemy : MonoBehaviour
{
    [SerializeField]
    public float speed;

    [SerializeField]
    private Vector3[] locations;

    private int offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, locations[offset], Time.deltaTime * speed); // move to the pre determined points

        if(transform.position == locations[offset]) // if the location same
        {
            if( offset == locations.Length -1)
            {
                offset = 0; //restard the queue
            }
            else
            {
                offset++; // otherwise follow queue
            }
        }
    }
}



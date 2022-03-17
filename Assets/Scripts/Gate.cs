
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour
{
    [SerializeField]
    public string targetScene;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionObject = collision.gameObject; //allow us to get info about collided object (like name in my case)

        if(collisionObject.name == "Player") //if it collided with player
        {
            SceneManager.LoadScene(targetScene); //load target scene ^-^
        }

    }

}

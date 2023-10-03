using UnityEngine;

public class PlantPot : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Hit by player");
           
        }
            
    }
}

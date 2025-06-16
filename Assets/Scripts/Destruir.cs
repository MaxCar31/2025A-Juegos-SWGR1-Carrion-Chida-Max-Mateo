using UnityEngine;

public class Destruir : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject); // Destruye el objeto al colisionar con un objeto que tenga la etiqueta "Player"
        }   
    }


}

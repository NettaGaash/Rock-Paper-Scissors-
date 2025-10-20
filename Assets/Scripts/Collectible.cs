using UnityEngine;

public class Collectible : MonoBehaviour
{
    private Rigidbody rb;
    public AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource.Play(1);

            this.gameObject.SetActive(false);

        }
    }

    
     

    
    
}

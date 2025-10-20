using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Collectible : MonoBehaviour
{
    [SerializeField] private AudioSource pickupAudio;
    [SerializeField] private GameObject visualsRoot;

    bool collected;

    void Reset()
    {
        var c = GetComponent<Collider>();
        c.isTrigger = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (collected) return;
        if (!other.CompareTag("Player")) return;

        collected = true;
        GameManager.Instance.IncrementCollectibles();

        if (visualsRoot) visualsRoot.SetActive(false);

        if (pickupAudio != null)
        {
            pickupAudio.Play();
            Destroy(gameObject, pickupAudio.clip.length);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

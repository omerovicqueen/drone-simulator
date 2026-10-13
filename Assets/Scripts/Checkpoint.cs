using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool isTriggered = false;
    public GameObject model;
    public Collider col;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private AudioSource audioSource;
    public AudioClip checkpointClip;
    public ParticleSystem checkpointParticles;
    public void OnTriggerEnter(Collider other)
    {
        audioSource.PlayOneShot(checkpointClip);
        
        
        if (isTriggered == false)
        {
            isTriggered = true;
            
            
            model.SetActive(false);
            col.enabled = false;
            checkpointParticles.Stop(); 
            checkpointParticles.Play();
            
            if (gameManager != null)
            {
                gameManager.OnCheckpointStateChanged();
            }
        }
    }
   
}

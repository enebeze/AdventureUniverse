using UnityEngine;

public class MoedaScript : MonoBehaviour
{
    Animator anim;

    CircleCollider2D col;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        col = gameObject.GetComponent<CircleCollider2D>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource.Play();
            GameManager.gm.SetMoedas(1);
            col.enabled = false;
            anim.SetTrigger("MoedaColetando");
            Destroy(gameObject, 0.667f);
        }
    }
}

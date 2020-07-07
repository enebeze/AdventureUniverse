using UnityEngine;

public class CaixaScript : MonoBehaviour
{
    Animator anim;
    public float jumpForce;
    public int moedas;
    public GameObject moedaPrefab;

    public AudioClip[] audios;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
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
            audioSource.clip = audios[0];
            audioSource.Play();
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            other.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            anim.SetTrigger("Colidindo");
            if (moedas > 0)
            {
                GameObject tempMoeda = Instantiate(moedaPrefab, transform.position, transform.rotation) as GameObject;
                tempMoeda.GetComponent<Animator>().SetTrigger("MoedaColetando");
                tempMoeda.GetComponent<AudioSource>().Play();
                moedas -= 1;
                GameManager.gm.SetMoedas(1);
                Destroy(tempMoeda, 0.667f);

            }
            else
            {
                audioSource.clip = audios[1];
                AudioSource.PlayClipAtPoint(audios[1], transform.position);
                Destroy(gameObject);
            }


        }
    }
}

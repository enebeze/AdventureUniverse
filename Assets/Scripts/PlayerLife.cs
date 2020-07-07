using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    Animator anim;

    bool vivo = true;

    public AudioClip deathSound;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
        GameManager.gm.AtualizaHud();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PerdeVidas()
    {
        if (vivo)
        {
            audioSource.clip = deathSound;
            audioSource.Play();
            vivo = false;
            anim.SetTrigger("Morreu");
            GameManager.gm.SetVidas(-1);
            gameObject.GetComponent<PlayerAttack>().enabled = false;
            gameObject.GetComponent<PlayerController>().enabled = false;
        }
    }

    public void Reset()
    {
        if (GameManager.gm.GetVidas() > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            SceneManager.LoadScene(5);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator anim;

    public float intervaloDeAtaque;
    private float proximoAtaque;

    public AudioClip spinSoud;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > proximoAtaque)
        {
            Atacando();
        }
    }

    void Atacando()
    {
        audioSource.clip = spinSoud;
        audioSource.Play();
        anim.SetTrigger("Ataque");
        proximoAtaque = Time.time + intervaloDeAtaque;
    }
}

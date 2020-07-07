using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    private int vidas = 3;
    private int moedas = 0;


    void Awake()
    {
        if (gm == null)
        {
            gm = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    void Start()
    {
        AtualizaHud();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetVidas(int vida)
    {
        vidas += vida;
        if (vidas >= 0)
            AtualizaHud();
    }

    public int GetVidas()
    {
        return vidas;
    }

    public void SetMoedas(int moeda)
    {
        moedas += moeda;
        if (moedas >= 50)
        {
            moedas = 0;
            vidas += 1;
        }

        AtualizaHud();
    }

    public void AtualizaHud()
    {
        GameObject.Find("VidasText").GetComponent<Text>().text = vidas.ToString();
        GameObject.Find("MoedaText").GetComponent<Text>().text = moedas.ToString();
    }

    void OnLevelWasLoaded()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            vidas = 3;
            moedas = 0;
        }
    }
}

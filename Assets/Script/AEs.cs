using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AEs : MonoBehaviour {
    public GameObject Sprefab;
    public Transform pos1;
    public Transform pos2;
    public Transform pos3;
    public Transform pos4;
    public Transform pos5;
    public Animator bars;
    public GameObject Title;
    public GameObject Boss;
    private Animator anims;
    public GameObject bossCamera;
    public GameObject subcam;
    public GameObject maincam;
    AudioSource aura;
    AudioSource throwsword;
    AudioSource charge;
    AudioSource karaburi;
    AudioSource dash;
    AudioSource damage;
    AudioSource fon;
    AudioSource cure;
    AudioSource jmp;

    // Use this for initialization
    void Start() {
        AudioSource[] audioSources = GetComponents<AudioSource>();

        karaburi = audioSources[0];
        aura = audioSources[1];
        throwsword = audioSources[2];
        charge = audioSources[3];
        dash = audioSources[4];
        damage = audioSources[5];
        fon = audioSources[6];
        cure = audioSources[7];
        jmp = audioSources[8];
        anims = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

    }

    public void SwordAt()
    {
        GameObject instance = GameObject.Instantiate(Sprefab) as GameObject;
        instance.transform.position = pos1.position;
    }

    public void SwordAt2()
    {
        GameObject instance = GameObject.Instantiate(Sprefab) as GameObject;
        instance.transform.position = pos2.position;

    }

    public void SwordAt3()
    {
        GameObject instance = GameObject.Instantiate(Sprefab) as GameObject;
        instance.transform.position = pos3.position;
    }

    public void SwordAt4()
    {
        GameObject instance = GameObject.Instantiate(Sprefab) as GameObject;
        instance.transform.position = pos4.position;
    }

    public void SwordAt5()
    {
        GameObject instance = GameObject.Instantiate(Sprefab) as GameObject;
        instance.transform.position = pos5.position;
    }

    public void ApBar()
    {
        bars.Play("fadeInBar");
    }
    public void BossApBar()
    {
        bars.Play("fadeinbarBoss");
        bars.SetBool("Boss", true);
    }
    public void DisApBar()
    {
        bars.Play("fadeOutBar");
    }

    public void opening()
    {
        bars.Play("OpeningEnd");
    }

    public void TdisP()
    {
        Destroy(Title);
    }

    public void bossAp()
    {
        Boss.SetActive(true);
    }

    public void stopController()
    {
        anims.SetBool("At3", true);
    }

    public void startController()
    {
        anims.SetBool("At3", false);
        //bossCamera.SetActive(true);
    }

    public void camch1()
    {
        subcam.SetActive(true);
        maincam.SetActive(false);
    }
    public void camch2()
    {
        bossCamera.SetActive(true);
        subcam.SetActive(false);
    }

    void auras()
    {
        aura.Play();
    }

    void stopaura()
    {
        aura.Stop();
    }

    void throwso()
    {
        throwsword.Play();
    }

    void chargesa()
    {
        charge.Play();
    }

    void stopchargesa()
    {
        charge.Stop();
    }

    void kara()
    {
        karaburi.Play();
    }

    void dashon()
    {
        dash.Play();
    }

    void damageon()
    {
        damage.Play();
    }

    void fonfon()
    {
        fon.Play();
    }

    void heal()
    {
        cure.Play();
    }

    void painthrow()
    {
        GetComponent<cotroller>().damage = false;
    }

    void jumpsnd()
    {
        jmp.Play();
    }
}

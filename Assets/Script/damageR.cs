using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class damageR : MonoBehaviour {
    private GameObject TimeM;
    // Use this for initialization
    [SerializeField] private GameObject damagePrefab;
    [SerializeField] private GameObject explo;
    [SerializeField] private GameObject ePos;
    [SerializeField] private int HP;
    [SerializeField] private float power;
    public Animator _anims;
    private Animator _thisanim;
    private Rigidbody2D rigid;
    private bool isOnce=false;
    private int interv = 0;
    private GameObject KCM;
    // Use this for initialization
    void Start() {
        _thisanim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        TimeM = GameObject.FindGameObjectWithTag("TimeManager");
        KCM= GameObject.FindGameObjectWithTag("KCM");
       


    }
	// Update is called once per frame
	void Update () {
        interv ++; 
        if (HP <= 0)
        {
            if (isOnce == false)
            {
                GetComponent<AudioSource>().Play();
                GetComponent<BoxCollider2D>().enabled = false;
                rigid.AddForce(new Vector2(0, power*1.5f), ForceMode2D.Impulse);
                var damagePerticle2 = GameObject.Instantiate(explo, ePos.transform) as GameObject;
                _thisanim.Play("Death");
                KCM.GetComponent<KCManeger>().killP();
                if (_anims.transform.root.gameObject.GetComponent<SpAtt>() != null)
                {
                    _anims.transform.root.gameObject.GetComponent<SpAtt>().EPup();
                }
                Invoke("Destroy", 3);
                isOnce = true;
            }

        }

        if (transform.position.y <= -200)
        {
            Destroy(gameObject);
        }
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
    public void Damage()
    {
        GetComponent<AudioSource>().Play();
        
        var damagePerticle = GameObject.Instantiate(damagePrefab, ePos.transform.position, Quaternion.Euler(0, 0, Random.Range(0,360))) as GameObject;
        TimeM.GetComponent<TimeManager>().SlowDown();
        Debug.Log("Damage!");
        HP -= 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.root.gameObject.GetComponent<Animator>())
        {
            if ((collision.transform.root.gameObject.GetComponent<Animator>().GetBool("At2") == true) && (collision.transform.tag == "Weapon"))
            {
                _thisanim.Play("damagerobo");
                if (collision.transform.root.gameObject.GetComponent<SpAtt>() != null)
                {
                    collision.transform.root.gameObject.GetComponent<SpAtt>().EPup();
                }
                rigid.AddForce(new Vector2(collision.gameObject.transform.forward.x * power, power), ForceMode2D.Impulse);
                Damage();

            }
            else if(collision.gameObject.tag=="Player")
            {
                if (interv >= 200)
                {
                    collision.gameObject.GetComponent<cotroller>().Damagemotion();
                    interv = 0;
                }
            }
        }
        
    }
}

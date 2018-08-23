using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCon : MonoBehaviour {
    private GameObject target;
    private float searchDis=120f;
    private Transform nowpos;
    [SerializeField]private int HP;
    [SerializeField]
    private BoxCollider2D AtPoint;
    public Animator _anims;
    private Animator _thisanim;
    private int item = 0;
    public GameObject exp;
    private bool de = false;
    public GameObject TimeM;
    // Use this for initialization
    [SerializeField]private GameObject damagePrefab;
    [SerializeField] private GameObject ePos;
    private int CoolTime;
    private int ran;
    private bool coolTime = false;
    public Slider bossbar;
    void Start () {
        target = GameObject.FindGameObjectWithTag("Player");
        _thisanim = GetComponent<Animator>();
        Debug.Log(target);
        nowpos = transform;
        bossbar.maxValue = HP;
	}
	
	// Update is called once per frame
	void Update () {
        bossbar.value = HP;
        if (transform.position.z != 0)
        {
            transform.position=new Vector3(nowpos.position.x,nowpos.position.y,0);
        }
        if ((target.transform.position-transform.position).magnitude<=searchDis)
        {
            if (transform.position.x - target.transform.position.x > 0)
            {
                //_thisanim.Play("newWalk");
                Debug.Log("Walk");
            }
            //transform.LookAt(target.transform.position);
            transform.position += transform.forward;
        }
        
        if (HP <= 0)
        {
            if (de == false)
            {
                _thisanim.Play("Dead");
                exp.SetActive(true);
                //gameObject.GetComponent<Rigidbody2D>().simulated = false;
                GetComponent<Rigidbody2D>().AddForce(new Vector2(100, 300), ForceMode2D.Impulse);
                //transform.position += new Vector3(1, 1f, 0);
                de = true;
            }
           
        }

        if (CoolTime > 300)
        {
            // _thisanim.StopPlayback();
            ran = Random.Range(1,4);
            if (ran==1)
            {
                 _thisanim.Play("Attack1");
            }
            if (ran == 2)
            {
                _thisanim.Play("Atatck2");
            }
            if (ran == 3)
            {
                _thisanim.Play("Attack3");
            }
            //thisanim.Play("RexAttack");
            _thisanim.SetBool("At1", true);
            Debug.Log("RexAttack!");
            CoolTime = 0;
        }
        else
        {
            CoolTime++;
        }
        
        nowpos = transform;
	}
    public void Damage()
    {
        GetComponent<AudioSource>().Play();
        var damagePerticle = GameObject.Instantiate(damagePrefab,ePos.transform) as GameObject;
        TimeM.GetComponent<TimeManager>().SlowDown();
        Debug.Log("Damage!");
        if (_thisanim.GetBool("At1")==false)
        {
            _thisanim.Play("Rdamage");
        }
        HP -= 1;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.transform.root.gameObject);
        
            if ((_anims.GetBool("At2") == true) && (col.transform.tag == "Weapon"))
            {
                if (col.transform.root.gameObject.GetComponent<SpAtt>() != null)
                {
                    col.transform.root.gameObject.GetComponent<SpAtt>().EPup();
                }
                Damage();
            }
        
        if (_thisanim.GetBool("InAtt") == true)
        {
            col.transform.root.gameObject.GetComponent<cotroller>().damage = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class cotroller : MonoBehaviour {
    private Rigidbody2D rigid;
    Animator _animator;
    float jumpTime = 30;
    float dashTime=0;
    float pow = 0.8f;
    bool dash = false;

    float At1Time=0;
    public bool debug = false;
    bool Attack=false;
    public bool damage = false;
    bool jum=false;
    float djump = 0;
    float spcount = 0;
    private Transform nowpos;

    bool G = false;
    public bool dead = false;

    public Slider HPbar;
    public Slider SPbar;
    [SerializeField] private bool isjumpPower = false;
    [SerializeField] private int jumpPower=20;

    [SerializeField]
     public int HP;
    [SerializeField]
    public int SP;

    public bool bossCheck = false;

    private float seconds;
    public static float Timecnt;

    public static float getTime()
    {
        return Timecnt;
    }

    enum State
    {
        STATE_IDLE,
        STATE_WALK,
        STATE_JUMP,
        STATE_ATTACK,
        STATE_DAMAGE,
        STATE_DASH
    };

    private State state=default(State);
	// Use this for initialization
	void Start () {
        Timecnt = 0f;
        rigid = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        state = State.STATE_IDLE;
        nowpos = transform;
        Timecnt=0f;

    }
	
	// Update is called once per frame
	void Update () {
        
        HPbar.value = HP;
        SPbar.value = SP;

        if (SP < 100)
        {
            if (spcount > 150)
            {
                SP++;
                spcount = 0;
            }
            else
            {
                spcount++;
            }
        }
        if (_animator.GetBool("At3") == true)
        {
            Timecnt += Time.deltaTime;
            if (transform.position.z != 0)
            {
                transform.position = new Vector3(nowpos.position.x, nowpos.position.y, 0);
            }


            float x = Input.GetAxisRaw("Horizontal");
            Vector3 scale = transform.localScale;
            if (x >= 0)
            {
                scale.x = 1;
                //transform.rotation=Quaternion.LookRotation(new Vector3(0, 0, 0));
            }
            else
            {
                scale.x = -1;
                //transform.rotation=Quaternion.LookRotation(new Vector3(180, 0, 0));
            }
            transform.localScale = scale;


            if ((Input.GetKeyDown(KeyCode.Z)) || (Input.GetKeyDown(KeyCode.Joystick1Button2)))
            {
                if (_animator.GetBool("At2") == false)
                {
                    _animator.Play("Attack1");
                    _animator.SetBool("At1", true);
                    GetComponent<AudioSource>().Play();
                }
            }
            if ((Input.GetKey(KeyCode.LeftArrow)) || (Input.GetKey(KeyCode.RightArrow))||(x!=0))
            {
                if (checkGround())
                {
                    _animator.SetBool("Walk", true);
                    
                    if (state == State.STATE_IDLE)
                    {
                        state = State.STATE_WALK;
                    }
                }

            }
            else
            {
                _animator.SetBool("Walk", false);
                state = State.STATE_IDLE;
            }

            transform.position += new Vector3(x * 0.6f, 0, 0);



            if ((Input.GetKeyDown(KeyCode.Space)) || (Input.GetKeyDown(KeyCode.Joystick1Button0)))
            {
                if (checkGround())
                {
                    _animator.Play("Jump");
                    _animator.SetBool("Jump", true);
                    jum = true;
                    G = true;
                }
            }

            if (jum == true)
            {
                if (isjumpPower)
                {
                    if (jumpTime <= 10)
                    {
                        transform.position += new Vector3(0, 2.4f, 0);
                        if (debug == false)
                        {
                            jumpTime++;
                        }
                    }
                    else
                    {
                        jum = false;
                    }
                }
                else
                {
                    rigid.AddForce(Vector2.up * jumpPower);
                    jum = false;
                }
               
            }
            else
            {
                jumpTime = 0;
            }
            



            if ((Input.GetKey(KeyCode.X)) || (Input.GetKeyDown(KeyCode.Joystick1Button5)))
            {                        
                    if (dash == false)
                    {
                        _animator.Play("Dash");
                        _animator.SetBool("Dash", true);

                    if (transform.localScale.x > 0)
                    {
                        rigid.AddForce(new Vector2(100, 5), ForceMode2D.Impulse);
                    }
                    else
                    {
                        rigid.AddForce(new Vector2(-100, 5), ForceMode2D.Impulse);
                    }

                    Invoke("cooltime", 0.3f);
                    dash = true;
                }

            }


            if ((Input.GetKeyUp(KeyCode.X)) || (Input.GetKeyDown(KeyCode.Joystick1Button5)))
            {
                dashTime = 0;
                _animator.SetBool("Dash", false);
            }

            if (checkFall(rigid))
            {
                _animator.SetBool("Jump", false);
                _animator.SetBool("Fall", true);
                transform.position += new Vector3(0, -0.2f, 0);
            }
            else
            {
                _animator.SetBool("Fall", false);

            }




            if (damage == true)
            {
                if (djump < 10)
                {
                    _animator.Play("Damage");
                    transform.position += new Vector3(-0.8f, 0.8f, 0);
                    HP--;
                    djump++;
                }
                else
                {
                    djump = 0;
                    //HP -= 10;
                    damage = false;
                }
            }

            if (HP<=0)
            {
                if (dead == false)
                {
                    _animator.Play("deaduni");

                    dead = true;
                }
               
            }
        }
        else
        {
            if ((Input.GetKeyDown(KeyCode.Return)) || (Input.GetKeyDown(KeyCode.Joystick1Button0)))
            {
                _animator.Play("Opening");
            }
        }



        switch (state)
        {
            case State.STATE_IDLE:

                break;

            case State.STATE_WALK:
               
                break;

            case State.STATE_JUMP:
                break;

            case State.STATE_DASH:
                break;

            case State.STATE_DAMAGE:
                break;

            case State.STATE_ATTACK:
                break;
        }
        if (checkGround() == false)
        {
            //transform.position += new Vector3(0, -0.2f, 0);
           
        }
 

        nowpos = transform;
    }

   private bool checkGround()
    {
        RaycastHit2D hitinfo;
        hitinfo=Physics2D.Raycast(transform.position-new Vector3(0,0.2f,0), Vector2.down, 0.1f);
        
        if (hitinfo.transform != null)
        {
            if (hitinfo.transform.tag == "ground")
            {

                jumpTime = 0;
                G = true;
                return true;
            }
            else
            {
               
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    private bool checkFall(Rigidbody2D rigid)
    {
        
        float velY = rigid.velocity.y;
                       
         if (checkGround())
        {
            _animator.SetBool("ground", true);

        }
        else
        {
            _animator.SetBool("ground", false);

        }
        if (velY<-0.1f)
        {
            return true;
        }
        else
        {
            return false;
        }

       

        
    }

    public void Damagemotion()
    {
        HP--;
        damage = true;
    }

    private void cooltime()
    {
        dash = false;
    }

    public void DJ()
    {
        _animator.Play("Jump");
        //_animator.SetBool("Jump", true);
        jumpTime = 0;
        jum = true;
        G = false;
    }
     public void Healing()
    {
        if (HP < 90)
        {
            HP += 20;
        }else if (HP == 90)
        {
            HP += 10;
        }
        
    }
    public bool Getg()
    {
        return G;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        
    }

    

   
}

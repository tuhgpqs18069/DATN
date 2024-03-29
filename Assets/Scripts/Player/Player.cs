﻿using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 28f;
    private float direction = 0f;
    private Rigidbody2D rb;
    private bool isFacingRight = true;
    // Check nền khi player đụng đất mới được nhảy nếu không thì nó tự vẫn nhảy trên không trung được.
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;

    // Các vật phẩm player được saved 
    private int health = 100;
    public static int diem = 0; //điểm vàng người dùng nhặt được
    public GameObject scoreText; //Text trên Unity
    public static int diem2 = 0; //điểm ruongw vàng người dùng nhặt được
    public GameObject scoreText2; //Text trên Unity

    // UI tắt Sound, Music
    public GameObject offSound;
    public GameObject offMusic;
    public bool isSound = false;
    public bool isMusic = false;
    public AudioSource music_sound;
    public AudioSource soundGame_sound;
    public AudioSource menu_sound;
    public AudioSource coin_sound;
    public AudioSource death_sound;

    // Check nhân vật đang chạy (true) hay đứng (false)
    public bool isRunning = false;

    // JoyStick: Assets của Unity hổ trợ nút để di chuyển
    public Joystick joystick;

    // Character Dash
    public bool canDash = true;
    public bool isDashing;
    // Sức dash
    private float dashingPower = 24f;
    // THời gian dash
    private float dashingTime = 0.2f;

    // Hồi chiêu (cooldown) Dash
    private float dashingCooldown = 1f;

    [SerializeField] private TrailRenderer tr;
    //Object để dùng ẩn hiện phòng ẩn
    public GameObject hiddenRoom;
    public GameObject disableBlock;

    //pause game , show canvas menu,dead, tutorial
    public bool isPause = false;
    public GameObject CanvasMenu;
    public GameObject CanvasDead;
    public GameObject CanvasTutorial;
    public bool isTutorial = false;

    //PickKeyScript
    public Component doorCollider;
    public GameObject keyGone;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
        music_sound.Play();
         
}

    // Update is called once per frame
    void Update()
    {
        
        if (isDashing)
        {
            return;
        }

        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        direction = Input.GetAxis("Horizontal");
        //direction = joystick.Horizontal;

        if(direction > 0f)
        {
            rb.velocity = new Vector2(direction * speed, rb.velocity.y);
        }
        else if(direction < 0)
        {
            rb.velocity = new Vector2(direction * speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKeyDown("w") && isTouchingGround == true || Input.GetKey(KeyCode.UpArrow) && isTouchingGround == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }


        if (Input.GetKeyDown("z") && canDash)
        {
            StartCoroutine(Dash());
        }
        Flip();

        //Pause game
        if (Input.GetKey(KeyCode.P) || Input.GetKey(KeyCode.Escape))
        {
            isPause = !isPause;
            if (isPause)
            {
                Time.timeScale = 0;
                CanvasMenu.SetActive(true);
                //Dừng và Lưu các Info được code bên SystemData 
                SystemData.Saving(this);
            }
            else
            {
                Time.timeScale = 1;
                CanvasMenu.SetActive(false);
                // Tiếp tục và Lấy các info player được save ở trên và tiếp tục
                PlayerSaveData data = SystemData.Loading();
                Debug.Log(">>>>>>> Health: " + data.health);
                Debug.Log(">>>>>>> Position: " + data.position[0] + " " + data.position[1] + " " + data.position[2]);

            }
        }
        // On/Off CanvasTutorial
        if (Input.GetKey(KeyCode.I))
        {
                isTutorial  = !isTutorial;
                if (isTutorial)
                {
                    CanvasTutorial.SetActive(true);
       
                }
                else
                {
                    CanvasTutorial.SetActive(false);
                }
        }


    }

    /*public void jumpButton()
    {
        if(isTouchingGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
        
    }*/

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
    }

    // Check mặt (FacingRight) lúc dash, k có cái này nó chỉ dash bên phải, k xác định mặt còn lại để dash
    private void Flip()
    {
        if (isFacingRight && direction < 0f || !isFacingRight && direction > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /**
        if (collision.gameObject.tag == "Coin")
        {
            //Play music
            point_sound.Play();
            //Particle System
            Destroy(collision.gameObject);
            ParticleSystem ps =  Instantiate(coin, transform.localPosition, Quaternion.identity);
            Destroy(ps, 1);
            //+coin
            TinhDiem(1);
        }
        **/

        // Kill Player
        if (collision.gameObject.tag == "Lava" || collision.gameObject.tag == "Horn")
        {
            Destroy(GameObject.Find("Player"));
            Time.timeScale = 0;
            death_sound.Play();
            CanvasDead.SetActive(true);
        }
        if (collision.gameObject.tag == "Machine")
        {
            Destroy(GameObject.Find("Player"));
            Time.timeScale = 0;
            death_sound.Play();
            CanvasDead.SetActive(true);
        }
        //Controller Map
        if (collision.gameObject.tag == "scene2")
        {
            SceneManager.LoadScene("Scene2");
        }
        if (collision.gameObject.tag == "NextEasy2")
        {
            SceneManager.LoadScene("Easy2");
        }
        if (collision.gameObject.tag == "NextEasy3")
        {
            SceneManager.LoadScene("Easy3");
        }
        if (collision.gameObject.tag == "NextHard1")
        {
            SceneManager.LoadScene("Hard1");
        }
        if (collision.gameObject.tag == "NextHard2")
        {
            SceneManager.LoadScene("Hard2");
        }
        if (collision.gameObject.tag == "NextHard3")
        {
            SceneManager.LoadScene("Hard3");
        }
        if (collision.gameObject.tag == "NextHard4")
        {
            SceneManager.LoadScene("Hard4");
        }

        //Controller Sene
        if (collision.gameObject.tag == "WindowTunel" && isDashing)
        {
            //Destroy(GameObject.Find("WindowTunel"));
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "elevator")
        {
            //transform.parent = collision.gameObject.transform;
        }
        
        

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "elevator")
        {
            transform.parent = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnterTrap")
        {
            disableBlock.SetActive(false);
        }
        if (collision.gameObject.tag == "ExitTrap")
        {
            disableBlock.SetActive(true);
        }
        if (collision.gameObject.tag == "EnterRoom")
        {
            hiddenRoom.SetActive(false);
        }
        if (collision.gameObject.tag == "ExitRoom")
        {
            hiddenRoom.SetActive(true);
        }
        //PickKey: Nhặt chìa khóa
        if (collision.gameObject.tag == "Key")
        {
            doorCollider.GetComponent<DoorOpened>().enabled = true;
            keyGone.SetActive(false);
        }
        //PickCoin: Nhặt Vàng
        if (collision.gameObject.tag == "Coin")
        {
            {
                Destroy(collision.gameObject);
                //Play music
                //point_sound.Play();
                //Particle System
                /*ParticleSystem ps = Instantiate(coin, transform.localPosition, Quaternion.identity);
                Destroy(ps, 1);*/
                //+coin
                TinhDiem(1);
                if(isSound == false)
                {
                    coin_sound.Play();
                }
                
            }
        };
        if (collision.gameObject.tag == "ChestCoin")
        {
            {
                Destroy(collision.gameObject);
                //Play music
                //point_sound.Play();
                //Particle System
                /*ParticleSystem ps = Instantiate(coin, transform.localPosition, Quaternion.identity);
                Destroy(ps, 1);*/
                //+coin
                TinhDiem2(1);
                if (isSound == false)
                {
                    coin_sound.Play();
                }
            }
        };
    }
    //Script để nhân vật có thể dash 1 đoạn nhỏ
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    //Script tính điểm khi nhặt vàng
    public void TinhDiem(int d)
    {
        diem += d;
        scoreText.GetComponent<Text>().text = diem.ToString();
    }
    //Script tính điểm khi nhặt rương vàng 
    public void TinhDiem2(int d2)
    {
        diem2 += d2;
        scoreText2.GetComponent<Text>().text = diem2.ToString();
    }

    //Public để khải báo sang script khác  khi private
    public int getHealth()
    {
        return this.health;
    }

    public void tatAmThanh()
    {
        isSound = !isSound;
        if (isSound)
        {
            offSound.SetActive(true);
            //soundGame_sound.Stop();
            coin_sound.Stop();
            death_sound.Stop();
        }
        else
        {
            offSound.SetActive(false);
            //soundGame_sound.Play();
            /*coin_sound.Play();
            death_sound.Play();*/
        }
    }
    public void tatNhac()
    {
        isMusic = !isMusic;
        if (isMusic)
        {
            offMusic.SetActive(true);
            music_sound.Stop();
        }
        else
        {
            offMusic.SetActive(false);
            music_sound.Play();
        }
    }






}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviourPun
{
    public float speed;
    private Joystick joystick;
    private PhotonView view;
    private Animator anim;
    private Rigidbody2D rb;
    public Health healthScript;

    private bool canMove = false;

    private void Start()
    {
        view = GetComponent<PhotonView>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<Joystick>();

        if (view.IsMine)
        {
            Camera.main.GetComponent<CameraFollow>().player = gameObject.transform;
            healthScript.Initialize(photonView.Owner.ActorNumber); // Инициализируем здоровье игрока с его уникальным ID
        }
    }

    private void Update()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount >= 2)
        {
            canMove = true;
        }

        float X = joystick.Horizontal * speed;
        float Y = joystick.Vertical * speed;

        if (view.IsMine && canMove)
        {
            rb.velocity = new Vector2(X, Y);

            if (X == 0 && Y == 0)
            {
                anim.SetBool("Run", false);
            }
            else
            {
                anim.SetBool("Run", true);

                if (X > 0)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                else if (X < 0)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
            }
        }
    }

    public void TakeHit(int damage)
    {
        healthScript.TakeHit(damage); // Передаем урон в скрипт Health
        if (photonView.IsMine)
        {
            // Вызываем метод SetHealth внутри Health скрипта для обновления здоровья
            healthScript.SetHealth(healthScript.currentHealth);
        }
        // Здесь можете добавить другие действия, если необходимо
    }

    public void SetHealth(int bonusHealth)
    {
        healthScript.SetHealth(bonusHealth); // Передаем пополнение здоровья в скрипт Health
        if (photonView.IsMine)
        {
            // Вызываем метод SetHealth внутри Health скрипта для обновления здоровья
            healthScript.SetHealth(healthScript.currentHealth);
        }
        // Здесь можете добавить другие действия, если необходимо
    }
}
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using Photon.Pun;
// using Photon.Realtime;
// using UnityEngine.UI;
// using ExitGames.Client.Photon; // Добавьте эту строку
// using Hashtable = ExitGames.Client.Photon.Hashtable;
// public class Player : MonoBehaviourPunCallbacks
// {
//     public float speed;
//     private Joystick joystick;
//     private PhotonView view;
//     private Animator anim;
//     private Rigidbody2D rb;
//     private Text moneyText; // Замените тип на Text
//     private bool canMove = false;

//     void Start()
//     {
//         view = GetComponent<PhotonView>();
//         anim = GetComponent<Animator>();
//         rb = GetComponent<Rigidbody2D>();
//         joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<Joystick>();
//         moneyText = GameObject.FindGameObjectWithTag("TextMoney").GetComponent<Text>(); // Замените тип на Text
//         if (view.Owner.IsLocal)
//         {
//             Camera.main.GetComponent<CameraFollow>().player = gameObject.transform;
//         }
//     }

//     void Update()
//     {
//         if (PhotonNetwork.CurrentRoom.PlayerCount >= 2)
//         {
//             canMove = true;
//         }

//         float X = joystick.Horizontal * speed;
//         float Y = joystick.Vertical * speed;

//         if (view.IsMine && canMove)
//         {
//             rb.velocity = new Vector2(X, Y);

//             if (X == 0 && Y == 0)
//             {
//                 anim.SetBool("Run", false);
//             }
//             else
//             {
//                 anim.SetBool("Run", true);
//                 if (X > 0)
//                 {
//                     transform.localScale = new Vector3(1, 1, 1);
//                 }
//                 else if (X < 0)
//                 {
//                     transform.localScale = new Vector3(-1, 1, 1);
//                 }
//             }
//         }
//     }

//    private void OnTriggerEnter2D(Collider2D collision)
// {
//     if (collision != null)
//     {
//         if (collision.CompareTag("Money"))
//         {
//             int currentMoney = (int)PhotonNetwork.LocalPlayer.CustomProperties["Money"];
//             currentMoney += 1;
//             Hashtable hash = new Hashtable();
//             hash["Money"] = currentMoney;
//             PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
//         }
//     }
// }
// }










// public float speed;
    // private Joystick joystick;
    // private PhotonView view;
    // private Animator anim;
    // private Rigidbody2D rb;

    // void Start()
    // {
    //     view = GetComponent<PhotonView>();
    //     anim = GetComponent<Animator>();
    //     rb = GetComponent<Rigidbody2D>();
    //     joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<Joystick>();

    //     if (view.Owner.IsLocal)
    //     {
    //         Camera.main.GetComponent<CameraFollow>().player = gameObject.transform;
    //     }
    // }

    // void Update()
    // {
    //     float X = joystick.Horizontal;
    //     float Y = joystick.Vertical;

    //     if (view.IsMine)
    //     {
    //         rb.velocity = new Vector2(X, Y) * speed;

    //         if (X == 0 && Y == 0)
    //         {
    //             anim.SetBool("Run", false);
    //         }
    //         else
    //         {
    //             anim.SetBool("Run", true);
                
    //             if (X > 0) 
    //             {
    //                 transform.localScale = new Vector3(1, 1, 1); 
    //             }
    //             else if (X < 0) 
    //             {
    //                 transform.localScale = new Vector3(-1, 1, 1); 
    //             }
    //         }
    //     }
    // }
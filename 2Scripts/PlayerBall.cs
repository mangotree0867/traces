using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBall : MonoBehaviour
{
    // Start is called before the first frame update

    public float jumpPower;
    public int itemCount;
    public GameManagerLogic manager;
    bool isJump;
    Rigidbody rigid;
    AudioSource audio;

    private void Awake()
    {
        isJump = false;
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJump)
        {
            isJump = true;
            rigid.AddForce(new Vector3(0,jumpPower,0),ForceMode.Impulse);
        }
    }
    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
            isJump = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            itemCount++;
            audio.Play();
            other.gameObject.SetActive(false);
            manager.GetItem(itemCount);
        }
        else if (other.tag == "Point")
        {
            if (itemCount == manager.TotalItemCount)
            { // Game Clear && Next Stage
                if (manager.stage == 2)
                    SceneManager.LoadScene(0);
                else
                    SceneManager.LoadScene(manager.stage+1);
            }
            else
            {   // Restart
                SceneManager.LoadScene(manager.stage);
            }
          
        }
    }
}

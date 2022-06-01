using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCan : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public float rotateSpeed;
    //AudioSource audio;
 
    private void Awake()
    {
       //audio=GetComponent<AudioSource>();   
    }
    
    private void Update()
    {
        transform.Rotate(Vector3.up*rotateSpeed*Time.deltaTime,Space.World);
    }

   private void OnTriggerEnter(Collider other)
   {
        if (other.name == "Player")
        {
            PlayerBall player=other.GetComponent<PlayerBall>();
            player.itemCount++;
           // audio.Play();
            gameObject.SetActive(false);
        }
   }
}

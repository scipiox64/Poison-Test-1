using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonBolt : MonoBehaviour
{
    [SerializeField]
    private float _speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(1.009f, 0.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0.74f, 3.5f), transform.position.y, transform.position.z);

        Vector3 direction = new Vector3(horizontalInput, 0, 0);

        transform.Translate(direction * _speed * Time.deltaTime);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Poison Bolt Hit Player! Player is Poisoned!");
            transform.position = new Vector3(1.5f, 0.5f, 0);
            Debug.Log("Poison Bolt Position Reset");
            Player player = other.transform.GetComponent<Player>();
            player.IsPoisoned();
        }
        
    }





}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text healthText;
    
    [SerializeField]
    int _health;
    
    public Text poisonDurationText;
    bool _isPoisoned;

    // Start is called before the first frame update
    void Start()
    {
        _health = 100;
        //healthText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + _health.ToString();
    }
    public void IsPoisoned()
    {
        StartCoroutine(PoisonedTime());
        StartCoroutine(PoisonHealth());
    }
    IEnumerator PoisonedTime()
    {
        _isPoisoned = true;
        Debug.Log("_isPoisoned set to true");

        if (_isPoisoned == true)
        {
            int randomPoisonDuration = Random.Range(5, 21);
            poisonDurationText.text = "Poison Duration: " + randomPoisonDuration.ToString();
            Debug.Log("Poisoned for: " + randomPoisonDuration + " seconds..");
            yield return new WaitForSeconds(randomPoisonDuration);

            _isPoisoned = default;
            Debug.Log("_isPoisoned set to default");
            Debug.Log("Subtracted: " + randomPoisonDuration + " health");
        }
    }

    IEnumerator PoisonHealth()
    {
        while (_isPoisoned == true)
        {
            _health--;
            Debug.Log("Health - 1, Waiting for 1 second.."); 
            yield return new WaitForSeconds(1);
        }
    }


}

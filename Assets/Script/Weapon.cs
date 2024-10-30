using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Weapon : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<Player>().Die();
            Invoke("Wait", 2f);
        }   
    }
    void Wait()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

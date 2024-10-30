using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Enemi : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject GameObject;
    [SerializeField] private GameObject Weapon;


    // Start is called before the first frame update

    public void Die()
    {
        CapsuleCollider collider = gameObject.GetComponent<CapsuleCollider>();
        animator.SetTrigger("Die");
        Weapon.SetActive(false);
        collider.enabled = false;
        Invoke("wait", 2f);
        ScoreUI.Ins.ScorePlus();
        AudioManager.instance.Play("Hit");
    }
    void wait()
    {
        Destroy(GameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("UIweapon"))
        {
            Die();
        }
    }
}

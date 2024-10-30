using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Animator animator;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private float moveSpeed;
    public Transform weaponTransform;
    public Shop shop;

    void FixedUpdate()
    {
        shop.ChangeWeaponPlayer(PlayerPrefs.GetInt("SelectedSkin"));
        rb.velocity = new Vector3(joystick.Horizontal * moveSpeed, rb.velocity.y, joystick.Vertical * moveSpeed);

        if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0))
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }
    }
    public void Die()
    {
        animator.SetTrigger("Die");
        AudioManager.instance.Play("GameOver");
    }
    
}
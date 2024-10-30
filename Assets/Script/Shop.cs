using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Security;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject[] skinWeapon;
    [SerializeField] private Button selectButton;
    [SerializeField] private Button cancelButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button backButton;
    [SerializeField] private Transform parent;

    private GameObject currentWeapon;
    private int weaponIndex = 0;
    private int totalWeapon = 0;
    private Transform weaponTransformPlayer;
    private GameObject Weapon;
    private Player player;
    private void Start()
    {
        player = FindObjectOfType<Player>();
        if (player != null)
        {
            weaponTransformPlayer = player.weaponTransform; // Gán weaponTransformPlayer bằng weaponTransform từ Player
        }
        totalWeapon = GameManager1.Ins.total_weapon;
        weaponIndex = PlayerPrefs.GetInt("SelectedSkin");
    }
    private void Update()
    {
        if (weaponIndex == PlayerPrefs.GetInt("SelectedSkin"))
        {
            selectButton.gameObject.SetActive(false);
            cancelButton.gameObject.SetActive(true);
        }
        else
        {
            selectButton.gameObject.SetActive(true);
            cancelButton.gameObject.SetActive(false);
        }
        Weapon = Instantiate(skinWeapon[weaponIndex], parent.position, Quaternion.identity, parent);
        Weapon.transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
    //public GameObject GetCurrentWeapon(int index)
    //{
    //    return skinWeapon[index];
    //}
    public void ChangeWeapon()
    {
        PlayerPrefs.SetInt("SelectedSkin", weaponIndex);
        if (currentWeapon != null)
        {
            Destroy(currentWeapon.gameObject);
        }
        currentWeapon = Instantiate(GameManager1.Ins.GetCurrentWeapon(weaponIndex), weaponTransformPlayer);
        InitWeapon(weaponIndex);
        AudioManager.instance.Play("Click");

    }
    public void ChangeWeaponPlayer(int index)
    {
        if (currentWeapon != null)
        {
            Destroy(currentWeapon.gameObject);
        }
        currentWeapon = Instantiate(GameManager1.Ins.GetCurrentWeapon(index), weaponTransformPlayer);
    }
    private void InitWeapon(int indexs)
    {
        weaponIndex = indexs;
        foreach (Transform child in parent)
        {
            Destroy(child.gameObject);
        }
        if (indexs == PlayerPrefs.GetInt("SelectedSkin"))
        {
            selectButton.gameObject.SetActive(false);
            cancelButton.gameObject.SetActive(true);
        }
        else
        {
            selectButton.gameObject.SetActive(true);
            cancelButton.gameObject.SetActive(false);
        }
    }

    public void ChangeNext()
    {
        int indexs = weaponIndex;
        indexs++;
        if (indexs == skinWeapon.Length)
        {
            indexs = 0;
        }
        InitWeapon(indexs);
        AudioManager.instance.Play("Click");
    }

    public void ChangePrevious()
    {
        int indexs = weaponIndex;
        indexs--;
        if (indexs < 0)
        {
            indexs = skinWeapon.Length - 1;
        }
        InitWeapon(indexs);
        AudioManager.instance.Play("Click");

    }
    public void BackButton()
    {
        Time.timeScale = 1;
    }
}

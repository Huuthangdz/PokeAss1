using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1 : Singleton<GameManager1>
{
    [SerializeField] private GameObject[] ListWeapon;
    [SerializeField] private GameObject ShopUI;
    [SerializeField] private GameObject PauseUI;
    [SerializeField] private GameObject JoystickUI;
    [SerializeField] private GameObject ScoreUI;


    public int total_weapon => ListWeapon.Length;
    private int weapon_index = 0;

    void Start()
    {
        Time.timeScale = 0;
        //StartGame();
        if (!PlayerPrefs.HasKey("SelectedSkin"))
        {
            PlayerPrefs.SetInt("SelectedSkin", weapon_index);
        }
        else
        {
            weapon_index = PlayerPrefs.GetInt("SelectedSkin");
        }
    }
    //public void StartGame()
    //{
    //    ShopUI.SetActive(true);
    //}
    public GameObject GetCurrentWeapon(int index)
    {
        return ListWeapon[index];
    }
}

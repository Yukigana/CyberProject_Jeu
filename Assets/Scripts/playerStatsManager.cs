using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStatsManager : MonoBehaviour
{
    [Header ("Player 1")]
    [SerializeField] private GameObject nameChampionField1;
    [SerializeField] private GameObject championImage1;
    [SerializeField] private GameObject healthBar1;
    [SerializeField] private GameObject powerBar1;

    [Header("Player 2")]
    [SerializeField] private GameObject nameChampionField2;
    [SerializeField] private GameObject championImage2;
    [SerializeField] private GameObject healthBar2;
    [SerializeField] private GameObject powerBar2;

    // Start is called before the first frame update
    void Start()
    {
        nameChampionField1.GetComponent<TextMeshProUGUI>().text = GameManager.player1.getName();
        championImage1.GetComponent<Image>().sprite = GameManager.player1.getIcon();
        healthBar1.GetComponent<Slider>().maxValue = GameManager.player1.getPvMax();
        healthBar1.GetComponent<Slider>().value = GameManager.player1.getPv();
        powerBar1.GetComponent<Slider>().maxValue = GameManager.player1.getPowerMax();
        powerBar1.GetComponent<Slider>().value = GameManager.player1.getPower();


        nameChampionField2.GetComponent<TextMeshProUGUI>().text = GameManager.player2.getName();
        championImage2.GetComponent<Image>().sprite = GameManager.player2.getIcon();
        healthBar2.GetComponent<Slider>().maxValue = GameManager.player2.getPvMax();
        healthBar2.GetComponent<Slider>().value = GameManager.player2.getPv();
        powerBar2.GetComponent<Slider>().maxValue = GameManager.player2.getPowerMax();
        powerBar2.GetComponent<Slider>().value = GameManager.player2.getPower();
    }

    private void Update()
    {
        healthBar1.GetComponent<Slider>().value = GameManager.player1.getPv();
        powerBar1.GetComponent<Slider>().value = GameManager.player1.getPower();

        healthBar2.GetComponent<Slider>().value = GameManager.player2.getPv();
        powerBar2.GetComponent<Slider>().value = GameManager.player2.getPower();
    }

}

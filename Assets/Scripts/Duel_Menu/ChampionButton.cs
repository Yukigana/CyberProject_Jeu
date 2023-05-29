using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChampionButton : MonoBehaviour
{
    [SerializeField] private Champion champion;
    [SerializeField] private GameObject nameButton;

    public void Start()
    {
        nameButton.GetComponent<TextMeshProUGUI>().text = champion.getName();
    }
}

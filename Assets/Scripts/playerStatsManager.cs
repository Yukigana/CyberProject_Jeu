using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerStatsManager : MonoBehaviour
{
    [SerializeField] private GameObject nameChampionField;
    [SerializeField] private bool isP1;
    // Start is called before the first frame update
    void Start()
    {
        if (isP1) nameChampionField.GetComponent<TextMeshProUGUI>().text = GameManager.player1.getName();
        else nameChampionField.GetComponent<TextMeshProUGUI>().text = GameManager.player2.getName();
    }

}

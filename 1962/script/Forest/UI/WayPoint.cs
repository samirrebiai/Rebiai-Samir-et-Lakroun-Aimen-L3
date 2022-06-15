using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class WayPoint : MonoBehaviour
{
    public RectTransform prefab;


    private RectTransform waypoint;

    private Transform player;
    private TextMeshProUGUI distanceText;


    private Vector3 offset = new Vector3(0, 1.25f, 0);



    // Start is called before the first frame update
    void Start()
    {
        var canvas = GameObject.Find("Waypoints").transform;

        waypoint =  Instantiate(prefab, canvas);
        distanceText = waypoint.GetComponentInChildren<TextMeshProUGUI>();

        player = GameObject.Find("First Person Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        var screenPos = Camera.main.WorldToScreenPoint(transform.position + offset);
        waypoint.position = screenPos;

        waypoint.gameObject.SetActive(screenPos.z > 0);

        distanceText.text = Vector3.Distance(player.position, transform.position).ToString("0.0") + "m";
    }
}

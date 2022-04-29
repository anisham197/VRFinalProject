using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderDocket : MonoBehaviour
{
    public GameObject muffinDocket;
    public GameObject donutDocket;
    public GameObject emptyDocket;
    public GameObject hotdogDocket;
    public GameObject omeletteDocket;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        int[] orderDocket;
        int orderDocketIndex;

        if (GameManager.S.inLevel0) {
            orderDocket = GameManager.S.orderDocketLevel0;
            orderDocketIndex = GameManager.S.orderDocketIndexLevel0;
        } 
        
        else if (GameManager.S.inLevel1) {
            orderDocket = GameManager.S.orderDocketLevel1;
            orderDocketIndex = GameManager.S.orderDocketIndexLevel1;
        }
        
        else {
            orderDocket = new int[0];
            orderDocketIndex = 0;
        }
        
        int order1 = orderDocketIndex >= orderDocket.Length ? -1 : orderDocket[orderDocketIndex];
        int order2 = orderDocketIndex + 1 >= orderDocket.Length ? -1 : orderDocket[orderDocketIndex + 1];
        int order3 = orderDocketIndex + 2 >= orderDocket.Length ? -1 : orderDocket[orderDocketIndex + 2];

        if (this.name == "DocketContainer1") {
            setDocket(order1); 
        } else if (this.name == "DocketContainer2") {
            setDocket(order2);
        } else {
            setDocket(order3);
        }
    }

    void setDocket(int order) {
        donutDocket.SetActive(false);
        muffinDocket.SetActive(false);
        hotdogDocket.SetActive(false);
        omeletteDocket.SetActive(false);
        emptyDocket.SetActive(false);

        if (order == 0) {
            // Set Donut
            donutDocket.SetActive(true);
        } else if (order == 1) {
            // Set Muffin
            muffinDocket.SetActive(true);
        } else if (order == 2) {
            // Set Hotdog
            hotdogDocket.SetActive(true);
        } else if (order == 3) {
            // Set Omelette
            omeletteDocket.SetActive(true);
        } else {
            // Set Empty
            emptyDocket.SetActive(true);
        }
    }
}

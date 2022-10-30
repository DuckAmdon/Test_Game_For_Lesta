using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameBoard : MonoBehaviour
{
    [SerializeField] GameObject emptyPole;
    [SerializeField] GameObject blueChip;
    [SerializeField] GameObject redChip;
    [SerializeField] GameObject greenChip;
    [SerializeField] GameObject block;

    private static float chipWidth = 1.1f;

    public GameManager gameManager;

    private List<GameObject> blueChipList = new List<GameObject>();
    private List<GameObject> redChipList = new List<GameObject>();
    private List<GameObject> greenChipList = new List<GameObject>();

    void Start()
    {
        //Empty
        for (int j = 0; j < 5; j++)
        {
            for (int i = 0; i < 5; i++)
            {
                Instantiate(emptyPole, new Vector3(0f + i * chipWidth - chipWidth, -j * chipWidth, 0.2f), Quaternion.identity).name = String.Format("{0},{1}", i, j);
            }

        }

        List<int> l = new List<int>();
        for (int i = 0; i < 5; i++)
        {
            l.Add(1);
            l.Add(2);
            l.Add(3);
        }

        //Random
        System.Random r = new System.Random();
        l = l.OrderBy(x => r.Next()).ToList();

        float dx = -1.1f;
        float dy = 0;

        Vector2 localCoord = new Vector2(0, 0);

        GameObject go = null;

        //Draw colored
        foreach (var item in l)
        {
            switch (item)
            {
                case 1:
                    go = Instantiate(blueChip, new Vector3(dx, dy, 0f), Quaternion.identity);
                    go.name = String.Format("{0},{1}", localCoord.x, localCoord.y);
                    blueChipList.Add(go);
                    break;
                case 2:
                    go = Instantiate(redChip, new Vector3(dx, dy, 0), Quaternion.identity);
                    go.name = String.Format("{0},{1}", localCoord.x, localCoord.y);
                    redChipList.Add(go);
                    break;
                case 3:
                    go = Instantiate(greenChip, new Vector3(dx, dy, 0f), Quaternion.identity);
                    go.name = String.Format("{0},{1}", localCoord.x, localCoord.y);
                    greenChipList.Add(go);
                    break;
            }

            if (dx < 3.3f)
            {
                dx += chipWidth * 2;
                localCoord.x += 2;
            }
            else
            {
                dx = -1.1f;
                dy -= chipWidth;

                localCoord.x = 0;
                localCoord.y += 1;
            }
        }
        // draw blocks
        Instantiate(block, new Vector3(0.0f, 0.0f, 0f), Quaternion.identity);
        Instantiate(block, new Vector3(0.0f, -2.2f, 0f), Quaternion.identity);
        Instantiate(block, new Vector3(0.0f, -4.4f, 0f), Quaternion.identity);

        Instantiate(block, new Vector3(2.2f, 0.0f, 0f), Quaternion.identity);
        Instantiate(block, new Vector3(2.2f, -2.2f, 0f), Quaternion.identity);
        Instantiate(block, new Vector3(2.2f, -4.4f, 0f), Quaternion.identity);

        GlobalEvents.GameOverCompare += victory;
    }

    void victory()
    {
        int summ = 0;
        
        foreach (GameObject item in blueChipList)
        {
            if (item.name[0] == '0')
            {
                summ++;
            }
        }

        foreach (GameObject item in redChipList)
        {
            if (item.name[0] == '2')
            {
                summ++;
            }
        }

        foreach (GameObject item in greenChipList)
        {
            if (item.name[0] == '4')
            {
                summ++;
            }
        }

        if (summ == 15)
        {
            gameManager.gameOver();
        }
    }

}
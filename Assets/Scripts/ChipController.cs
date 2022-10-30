using System;
using UnityEngine;

public class ChipController : MonoBehaviour
{
    bool selectFlag = false;
    
    void Start()
    {
        GlobalEvents.SelectEvent += changeSelect;
    }

    void emptyDown(string n)
    {
        string[] v1 = this.name.Split(',');
        string[] e1 = n.Split(',');
        Vector2Int chipVector = new Vector2Int(int.Parse(v1[0]), int.Parse(v1[1]));
        Vector2Int emptyVector = new Vector2Int(int.Parse(e1[0]), int.Parse(e1[1]));

        if (compare_vec(chipVector, emptyVector) == true)
        {
            // then move cube
            Vector3 pos = transform.position;
            float shift = 1.1f;

            // then x
            if (Math.Abs(chipVector.x - emptyVector.x) == 1)
            {
                if (chipVector.x > emptyVector.x)
                {
                    pos.x -= shift;
                }
                else
                {
                    pos.x += shift;
                }
            }
            else
            {
                if (chipVector.y > emptyVector.y)
                {
                    pos.y += shift;
                }
                else
                {
                    pos.y -= shift;
                }
            }

            transform.position = pos;

            this.name = string.Format("{0},{1}", emptyVector.x, emptyVector.y);

            GlobalEvents.GameOverCompare.Invoke();

        }
        else
        {
            //fail move! fuckin cube!
            print("FAIL");
        }
    }

    bool compare_vec(Vector2Int a, Vector2Int b)
    {
        if (Math.Abs(a.x - b.x) == 1 && (Math.Abs(a.y - b.y) == 0))
        {
            return true;
        }
        if (Math.Abs(a.x - b.x) == 0 && (Math.Abs(a.y - b.y) == 1))
        {
            return true;
        }
        return false;
    }


    private void changeSelect()
    {
        resetSelect();
    }

    void OnMouseDown()
    {
        GlobalEvents.SelectEvent.Invoke();

        if (selectFlag == false)
        {
            GlobalEvents.SelectEmptyEvent += emptyDown;

            selectFlag = true;

            Vector3 pos = transform.position;
            pos.z = -0.2f;
            transform.position = pos;
        }
        else
        {
            resetSelect();
        }
    }

    void resetSelect()
    {
        GlobalEvents.SelectEmptyEvent -= emptyDown;
        selectFlag = false;
        Vector3 pos = transform.position;
        pos.z = 0f;
        transform.position = pos;
    }
}
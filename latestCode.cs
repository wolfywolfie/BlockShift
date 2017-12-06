using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePosition : MonoBehaviour {

    public int pusherOneX, pusherOneY;
    public int pusherTwoX, pusherTwoY;
    public int oldOneX, oldOneY;
    public int oldTwoX, oldTwoY;
    public int width, height;
    public GameObject[,] pusherGrid;
    public GameObject[,] pusherGrid2;

    public Material clearColor;
    public Material optionOne;
    public int temp;

    public GameObject pusherOne;
    public GameObject pusherTwo;
    Vector3 positionOne;
    Vector3 positionTwo;

    // Use this for initialization
    void Start () {
        pusherOneX = 5;
        pusherOneY = 6;
        pusherTwoX = MainControl.maxGridWidth;
        pusherTwoY = 2;

        width = 11;
        height = 8;

        GameObject[,] pusherGrid = new GameObject[width, height];
        //GameObject[,] pusherGrid2 = new GameObject[width, height];

        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y <= 0; y++)
            {
                    positionOne = new Vector3(x * 8, y * 8, 0);

                    pusherGrid[x, y] = Instantiate(pusherOne, positionOne, Quaternion.identity);
                    //pusherGrid2[x, y] = Instantiate(pusherOne, positionOne, Quaternion.identity);
                    pusherGrid[x,y].GetComponent<Renderer>().material = clearColor;
                    //pusherGrid2[x, y].GetComponent<Renderer>().material = clearColor;
            }
        }

        for (int x = 0; x < 10; x++)
        {
            for (int y = 6; y <= 6; y++)
            {
                positionOne = new Vector3(x * 8, y * 8, 0);
                pusherGrid[x, y] = Instantiate(pusherOne, positionOne, Quaternion.identity);
                //pusherGrid2[x, y] = Instantiate(pusherOne, positionOne, Quaternion.identity);
                pusherGrid[x, y].GetComponent<Renderer>().material = clearColor;
                //pusherGrid2[x, y].GetComponent<Renderer>().material = clearColor;
            }
        }

        for (int x = 0; x <= 0; x++)
        {
            for (int y = 0; y < MainControl.maxGridHeight; y++)
            {
                positionOne = new Vector3(x * 8, y * 8, 0);
                pusherGrid[x, y] = Instantiate(pusherOne, positionOne, Quaternion.identity);
                //pusherGrid2[x, y] = Instantiate(pusherOne, positionOne, Quaternion.identity);
                pusherGrid[x, y].GetComponent<Renderer>().material = clearColor;
                //pusherGrid2[x, y].GetComponent<Renderer>().material = clearColor;
            }
        }

        for (int x = 9; x <= 9; x++)
        {
            for (int y = 0; y < MainControl.maxGridHeight; y++)
            {
                positionOne = new Vector3(x * 8, y * 8, 0);
                pusherGrid[x, y] = Instantiate(pusherOne, positionOne, Quaternion.identity);
                //pusherGrid2[x, y] = Instantiate(pusherOne, positionOne, Quaternion.identity);
                pusherGrid[x, y].GetComponent<Renderer>().material = clearColor;
                //pusherGrid2[x, y].GetComponent<Renderer>().material = clearColor;
            }
        }

        pusherGrid[pusherOneX, pusherOneY].GetComponent<Renderer>().material = optionOne;
    }
	
	// Update is called once per frame
	void Update () {
        //planning phase
        if (MainControl.planningStart)
        {
            if (Input.GetButtonDown("pushLeft"))
            {
                oldOneX = pusherOneX;
                oldOneY = pusherOneY;
                //pusher one moves counterclockwise
                if (pusherOneY == MainControl.maxGridHeight && pusherOneX > 0)
                {
                    //move left
                    pusherOneX--;
                }
                else if (pusherOneX == 0 && pusherOneY != 0)
                {
                    //move down
                    pusherOneY--;
                }
                else if (pusherOneY == 0 && pusherOneX < MainControl.maxGridWidth)
                {
                    //move right
                    pusherOneX++;
                }
                else
                {
                    //move up
                    pusherOneY++;
                }
                MainControl.gameTime++;
                //pusherGrid[oldOneX, oldOneY].GetComponent<Renderer>().material = clearColor;
                pusherGrid[pusherOneX, pusherOneY].GetComponent<Renderer>().material = optionOne;
                print("x pos: " + pusherOneX + " y pos: " + pusherOneY);
                return;
            }

            if (Input.GetButtonDown("pushRight"))
            {
                //pusher one moves clockwise
            }
            if (Input.GetButtonDown("pushUp"))
            {
                //pusher two moves counterclockwise
            }
            if (Input.GetButtonDown("pushDown"))
            {
                //pusher two moves clockwise
            }
        }
    }
}

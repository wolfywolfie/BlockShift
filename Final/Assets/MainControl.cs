using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainControl : MonoBehaviour
{

    public GameObject basicCube;
    public static GameObject onePosition;
    Vector3 basicPosition;
    public Text lootText;
    public Text scoreText;

    public GameObject[,] grid;
    public Color[] colors;
    public List<int> possibleNumbers;
    public static int gameTime;
    public static float elapsedTime;
    int maxWidth, maxHeight;
    public static int maxGridWidth, maxGridHeight;
    int gridWidth, gridHeight;
    int randomValue;
    int storedValue;
    public static int columnTracker, columnTrackerTwo;
    public static int rowTracker, rowTrackerTwo;
    public static int gridX, gridY;
    public string storedColor;

    public static bool actionStart;
    public static bool planningStart;
    public static bool resolutionStart;
    public static bool pointsAwarded;
    public static bool scoringStart;
    public int turnCounter;
    public static int score;

    public int blackCounter, blueCounter, greenCounter, redCounter, yellowCounter, whiteCounter;


    // Use this for initialization
    void Start()
    {
        turnCounter = 0;
        score = 0;
        maxWidth = 11;
        maxHeight = 8;
        maxGridWidth = 9;
        maxGridHeight = 6;
        gridWidth = 8;
        gridHeight = 5;
        gameTime = 4;
        actionStart = false;
        planningStart = true;
        resolutionStart = false;
        scoringStart = false;
        pointsAwarded = false;
        List<int> possibleNumbers = new List<int>(new int[] { 0, 1, 2, 3, 4, 5 });

        grid = new GameObject[maxWidth, maxHeight];
        Color[] colors = new Color[6];
        colors[0] = Color.black;
        colors[1] = Color.blue;
        colors[2] = Color.green;
        colors[3] = Color.red;
        colors[4] = Color.yellow;
        colors[5] = Color.white;

        //creates grid
        for (int x = 1; x < maxGridWidth; x++)
        {
            for (int y = 1; y < maxGridHeight; y++)
            {
                basicPosition = new Vector3(x * 8, y * 8, 0);
                grid[x, y] = Instantiate(basicCube, basicPosition, Quaternion.identity);
            }
        }


        //cubes are colored by row for simplicity. Checks to see if there is a matching color.
        //Will get a new color if the one above it is the same color.

        //row one
        for (int x = 1; x <= gridWidth; x++)
        {
            int y = 1;
            randomValue = Random.Range(0, possibleNumbers.Count);
            grid[x, y].GetComponent<Renderer>().material.color = colors[randomValue];
            if (x > 1)
            {
                if (grid[x, y].GetComponent<Renderer>().material.color ==
                    grid[x - 1, y].GetComponent<Renderer>().material.color)
                {
                    possibleNumbers.Remove(randomValue);
                    storedValue = randomValue;
                    randomValue = Random.Range(0, possibleNumbers.Count);
                    grid[x, y].GetComponent<Renderer>().material.color = colors[randomValue];
                    possibleNumbers.Add(storedValue);
                }
            }
            if (y < 1)
            {
                if (grid[x, y].GetComponent<Renderer>().material.color ==
                    grid[x, y + 1].GetComponent<Renderer>().material.color)
                {
                    possibleNumbers.Remove(randomValue);
                    storedValue = randomValue;
                    randomValue = Random.Range(0, possibleNumbers.Count);
                    grid[x, y].GetComponent<Renderer>().material.color = colors[randomValue];
                    possibleNumbers.Add(storedValue);
                }
            }
        }

        //row two
        for (int x = 1; x <= gridWidth; x++)
        {
            int y = 2;
            randomValue = Random.Range(0, possibleNumbers.Count);
            grid[x, y].GetComponent<Renderer>().material.color = colors[randomValue];
            if (x > 1)
            {
                if (grid[x, y].GetComponent<Renderer>().material.color ==
                    grid[x - 1, y].GetComponent<Renderer>().material.color)
                {
                    possibleNumbers.Remove(randomValue);
                    storedValue = randomValue;
                    randomValue = Random.Range(0, possibleNumbers.Count);
                    grid[x, y].GetComponent<Renderer>().material.color = colors[randomValue];
                    possibleNumbers.Add(storedValue);
                }
            }
            if (y > 1)
            {
                if (grid[x, y].GetComponent<Renderer>().material.color ==
                    grid[x, y - 1].GetComponent<Renderer>().material.color)
                {
                    possibleNumbers.Remove(randomValue);
                    storedValue = randomValue;
                    randomValue = Random.Range(0, possibleNumbers.Count);
                    grid[x, y].GetComponent<Renderer>().material.color = colors[randomValue];
                    possibleNumbers.Add(storedValue);
                }
            }
        }

        //row three
        for (int x = 1; x <= gridWidth; x++)
        {
            int y = 3;
            randomValue = Random.Range(0, possibleNumbers.Count);
            grid[x, y].GetComponent<Renderer>().material.color = colors[randomValue];
            if (x > 1)
            {
                if (grid[x, y].GetComponent<Renderer>().material.color ==
                    grid[x - 1, y].GetComponent<Renderer>().material.color)
                {
                    possibleNumbers.Remove(randomValue);
                    storedValue = randomValue;
                    randomValue = Random.Range(0, possibleNumbers.Count);
                    grid[x, y].GetComponent<Renderer>().material.color = colors[randomValue];
                    possibleNumbers.Add(storedValue);
                }
            }
            if (y > 1)
            {
                if (grid[x, y].GetComponent<Renderer>().material.color ==
                    grid[x, y - 1].GetComponent<Renderer>().material.color)
                {
                    possibleNumbers.Remove(randomValue);
                    storedValue = randomValue;
                    randomValue = Random.Range(0, possibleNumbers.Count);
                    grid[x, y].GetComponent<Renderer>().material.color = colors[randomValue];
                    possibleNumbers.Add(storedValue);
                }
            }
        }

        //row four
        for (int x = 1; x <= gridWidth; x++)
        {
            int y = 4;
            randomValue = Random.Range(0, possibleNumbers.Count);
            grid[x, y].GetComponent<Renderer>().material.color = colors[randomValue];
            if (x > 1)
            {
                if (grid[x, y].GetComponent<Renderer>().material.color ==
                    grid[x - 1, y].GetComponent<Renderer>().material.color)
                {
                    possibleNumbers.Remove(randomValue);
                    storedValue = randomValue;
                    randomValue = Random.Range(0, possibleNumbers.Count);
                    grid[x, y].GetComponent<Renderer>().material.color = colors[randomValue];
                    possibleNumbers.Add(storedValue);
                }
            }
            if (y > 1)
            {
                if (grid[x, y].GetComponent<Renderer>().material.color ==
                    grid[x, y - 1].GetComponent<Renderer>().material.color)
                {
                    possibleNumbers.Remove(randomValue);
                    storedValue = randomValue;
                    randomValue = Random.Range(0, possibleNumbers.Count);
                    grid[x, y].GetComponent<Renderer>().material.color = colors[randomValue];
                    possibleNumbers.Add(storedValue);
                }
            }
        }

        //row five
        for (int x = 1; x <= gridWidth; x++)
        {
            int y = 5;
            randomValue = Random.Range(0, possibleNumbers.Count);
            grid[x, y].GetComponent<Renderer>().material.color = colors[randomValue];
            if (x > 1)
            {
                if (grid[x, y].GetComponent<Renderer>().material.color ==
                    grid[x - 1, y].GetComponent<Renderer>().material.color)
                {
                    possibleNumbers.Remove(randomValue);
                    storedValue = randomValue;
                    randomValue = Random.Range(0, possibleNumbers.Count);
                    grid[x, y].GetComponent<Renderer>().material.color = colors[randomValue];
                    possibleNumbers.Add(storedValue);
                }
            }
            if (y > 1)
            {
                if (grid[x, y].GetComponent<Renderer>().material.color ==
                    grid[x, y - 1].GetComponent<Renderer>().material.color)
                {
                    possibleNumbers.Remove(randomValue);
                    storedValue = randomValue;
                    randomValue = Random.Range(0, possibleNumbers.Count);
                    grid[x, y].GetComponent<Renderer>().material.color = colors[randomValue];
                    possibleNumbers.Add(storedValue);
                }
            }
        }

    }

    public void StartAction(int x)
    {
        if (x == 2)
        {
            resolutionStart = true;
            elapsedTime = Time.time;
        }
    }

    public void SwitchScenes()
    {
        SceneManager.LoadScene(2);
    }

    // Update is called once per frame
    void Update()
    {

        //action phase, has been removed
        if (actionStart == true)
        {
            planningStart = false;
            if (Time.time <= gameTime + elapsedTime)
            {
                //onmousedown destroy cubes
            }
            else
            {
                actionStart = false;
                resolutionStart = true;
            }
        }

        //resolution phase
        if (resolutionStart)
        {
            //checks rows for pusher cube
            if (rowTracker == 1)
            {
                if (columnTracker == 0)
                {
                    for (int x = gridWidth; x > 1; x--)
                    {
                        if (!pointsAwarded)
                        {
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.black)
                            {
                                blackCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.red)
                            {
                                redCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.green)
                            {
                                greenCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.blue)
                            {
                                blueCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.yellow)
                            {
                                yellowCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.white)
                            {
                                whiteCounter++;
                            }
                            pointsAwarded = true;
                        }
                        grid[x, rowTracker].GetComponent<Renderer>().material.color =
                            grid[x - 1, rowTracker].GetComponent<Renderer>().material.color;
                        grid[1, rowTracker].GetComponent<Renderer>().material.color =
                            CubePosition.pusherGrid[CubePosition.pusherOneX,
                            CubePosition.pusherOneY].GetComponent<Renderer>().material.color;
                    }
                }
                if (columnTracker == 9)
                {
                    for (int x = 1; x < gridWidth; x++)
                    {
                        if (!pointsAwarded)
                        {
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.black)
                            {
                                blackCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.red)
                            {
                                redCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.green)
                            {
                                greenCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.blue)
                            {
                                blueCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.yellow)
                            {
                                yellowCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.white)
                            {
                                whiteCounter++;
                            }
                            pointsAwarded = true;
                        }
                        grid[x, rowTracker].GetComponent<Renderer>().material.color =
                            grid[x + 1, rowTracker].GetComponent<Renderer>().material.color;
                        grid[8, rowTracker].GetComponent<Renderer>().material.color =
                            CubePosition.pusherGrid[CubePosition.pusherOneX,
                            CubePosition.pusherOneY].GetComponent<Renderer>().material.color;
                    }
                }
                pointsAwarded = false;
                rowTracker = -1;
            } else if (columnTracker == 1)
            {
                if (rowTracker == 6)
                {
                    for (int y = gridHeight; y > 1; y--)
                    {
                        if (!pointsAwarded)
                        {
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.black)
                            {
                                blackCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.red)
                            {
                                redCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.green)
                            {
                                greenCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.blue)
                            {
                                blueCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.yellow)
                            {
                                yellowCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.white)
                            {
                                whiteCounter++;
                            }
                            pointsAwarded = true;
                        }
                        grid[columnTracker, y].GetComponent<Renderer>().material.color =
                            grid[columnTracker, y-1].GetComponent<Renderer>().material.color;
                        grid[columnTracker, 1].GetComponent<Renderer>().material.color =
                            CubePosition.pusherGrid[CubePosition.pusherOneX,
                            CubePosition.pusherOneY].GetComponent<Renderer>().material.color;
                    }
                }
                if (rowTracker == 0)
                {
                    for (int y = 1; y < gridHeight; y++)
                    {
                        if (!pointsAwarded)
                        {
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.black)
                            {
                                blackCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.red)
                            {
                                redCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.green)
                            {
                                greenCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.blue)
                            {
                                blueCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.yellow)
                            {
                                yellowCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.white)
                            {
                                whiteCounter++;
                            }
                            pointsAwarded = true;
                        }
                        grid[columnTracker, y].GetComponent<Renderer>().material.color =
                            grid[columnTracker, y+1].GetComponent<Renderer>().material.color;
                        grid[columnTracker, 1].GetComponent<Renderer>().material.color =
                            CubePosition.pusherGrid[CubePosition.pusherOneX,
                            CubePosition.pusherOneY].GetComponent<Renderer>().material.color;
                    }
                }
            }

            if (rowTracker == 2)
            {
                if (columnTracker == 0)
                {
                    for (int x = gridWidth; x > 1; x--)
                    {
                        if (!pointsAwarded)
                        {
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.black)
                            {
                                blackCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.red)
                            {
                                redCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.green)
                            {
                                greenCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.blue)
                            {
                                blueCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.yellow)
                            {
                                yellowCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.white)
                            {
                                whiteCounter++;
                            }
                            pointsAwarded = true;
                        }
                        grid[x, rowTracker].GetComponent<Renderer>().material.color =
                            grid[x - 1, rowTracker].GetComponent<Renderer>().material.color;
                        grid[1, rowTracker].GetComponent<Renderer>().material.color =
                            CubePosition.pusherGrid[CubePosition.pusherOneX,
                            CubePosition.pusherOneY].GetComponent<Renderer>().material.color;
                    }
                }
                if (columnTracker == 9)
                {
                    for (int x = 1; x < gridWidth; x++)
                    {
                        if (!pointsAwarded)
                        {
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.black)
                            {
                                blackCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.red)
                            {
                                redCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.green)
                            {
                                greenCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.blue)
                            {
                                blueCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.yellow)
                            {
                                yellowCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.white)
                            {
                                whiteCounter++;
                            }
                            pointsAwarded = true;
                        }
                        grid[x, rowTracker].GetComponent<Renderer>().material.color =
                            grid[x + 1, rowTracker].GetComponent<Renderer>().material.color;
                        grid[8, rowTracker].GetComponent<Renderer>().material.color =
                            CubePosition.pusherGrid[CubePosition.pusherOneX,
                            CubePosition.pusherOneY].GetComponent<Renderer>().material.color;
                    }
                }
                pointsAwarded = false;
                rowTracker = -1;
            }
            else if (columnTracker == 2)
            {
                if (rowTracker == 6)
                {
                    for (int y = gridHeight; y > 1; y--)
                    {
                        if (!pointsAwarded)
                        {
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.black)
                            {
                                blackCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.red)
                            {
                                redCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.green)
                            {
                                greenCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.blue)
                            {
                                blueCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.yellow)
                            {
                                yellowCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.white)
                            {
                                whiteCounter++;
                            }
                            pointsAwarded = true;
                        }
                        grid[columnTracker, y].GetComponent<Renderer>().material.color =
                            grid[columnTracker, y - 1].GetComponent<Renderer>().material.color;
                        grid[columnTracker, 1].GetComponent<Renderer>().material.color =
                            CubePosition.pusherGrid[CubePosition.pusherOneX,
                            CubePosition.pusherOneY].GetComponent<Renderer>().material.color;
                    }
                }
                if (rowTracker == 0)
                {
                    for (int y = 1; y < gridHeight; y++)
                    {
                        if (!pointsAwarded)
                        {
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.black)
                            {
                                blackCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.red)
                            {
                                redCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.green)
                            {
                                greenCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.blue)
                            {
                                blueCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.yellow)
                            {
                                yellowCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.white)
                            {
                                whiteCounter++;
                            }
                            pointsAwarded = true;
                        }
                        grid[columnTracker, y].GetComponent<Renderer>().material.color =
                            grid[columnTracker, y + 1].GetComponent<Renderer>().material.color;
                        grid[columnTracker, 1].GetComponent<Renderer>().material.color =
                            CubePosition.pusherGrid[CubePosition.pusherOneX,
                            CubePosition.pusherOneY].GetComponent<Renderer>().material.color;
                    }
                }
            }

            if (rowTracker == 3)
            {
                if (columnTracker == 0)
                {
                    for (int x = gridWidth; x > 1; x--)
                    {
                        if (!pointsAwarded)
                        {
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.black)
                            {
                                blackCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.red)
                            {
                                redCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.green)
                            {
                                greenCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.blue)
                            {
                                blueCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.yellow)
                            {
                                yellowCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.white)
                            {
                                whiteCounter++;
                            }
                            pointsAwarded = true;
                        }
                        grid[x, rowTracker].GetComponent<Renderer>().material.color =
                            grid[x - 1, rowTracker].GetComponent<Renderer>().material.color;
                        grid[1, rowTracker].GetComponent<Renderer>().material.color =
                            CubePosition.pusherGrid[CubePosition.pusherOneX,
                            CubePosition.pusherOneY].GetComponent<Renderer>().material.color;
                    }
                }
                if (columnTracker == 9)
                {
                    for (int x = 1; x < gridWidth; x++)
                    {
                        if (!pointsAwarded)
                        {
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.black)
                            {
                                blackCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.red)
                            {
                                redCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.green)
                            {
                                greenCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.blue)
                            {
                                blueCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.yellow)
                            {
                                yellowCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.white)
                            {
                                whiteCounter++;
                            }
                            pointsAwarded = true;
                        }
                        grid[x, rowTracker].GetComponent<Renderer>().material.color =
                            grid[x + 1, rowTracker].GetComponent<Renderer>().material.color;
                        grid[8, rowTracker].GetComponent<Renderer>().material.color =
                            CubePosition.pusherGrid[CubePosition.pusherOneX,
                            CubePosition.pusherOneY].GetComponent<Renderer>().material.color;
                    }
                }
                pointsAwarded = false;
                rowTracker = -1;
            }
            else if (columnTracker == 3)
            {
                if (rowTracker == 6)
                {
                    for (int y = gridHeight; y > 1; y--)
                    {
                        if (!pointsAwarded)
                        {
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.black)
                            {
                                blackCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.red)
                            {
                                redCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.green)
                            {
                                greenCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.blue)
                            {
                                blueCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.yellow)
                            {
                                yellowCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.white)
                            {
                                whiteCounter++;
                            }
                            pointsAwarded = true;
                        }
                        grid[columnTracker, y].GetComponent<Renderer>().material.color =
                            grid[columnTracker, y - 1].GetComponent<Renderer>().material.color;
                        grid[columnTracker, 1].GetComponent<Renderer>().material.color =
                            CubePosition.pusherGrid[CubePosition.pusherOneX,
                            CubePosition.pusherOneY].GetComponent<Renderer>().material.color;
                    }
                }
                if (rowTracker == 0)
                {
                    for (int y = 1; y < gridHeight; y++)
                    {
                        if (!pointsAwarded)
                        {
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.black)
                            {
                                blackCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.red)
                            {
                                redCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.green)
                            {
                                greenCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.blue)
                            {
                                blueCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.yellow)
                            {
                                yellowCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.white)
                            {
                                whiteCounter++;
                            }
                            pointsAwarded = true;
                        }
                        grid[columnTracker, y].GetComponent<Renderer>().material.color =
                            grid[columnTracker, y + 1].GetComponent<Renderer>().material.color;
                        grid[columnTracker, 1].GetComponent<Renderer>().material.color =
                            CubePosition.pusherGrid[CubePosition.pusherOneX,
                            CubePosition.pusherOneY].GetComponent<Renderer>().material.color;
                    }
                }
            }

            if (rowTracker == 4)
            {
                if (columnTracker == 0)
                {
                    for (int x = gridWidth; x > 1; x--)
                    {
                        if (!pointsAwarded)
                        {
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.black)
                            {
                                blackCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.red)
                            {
                                redCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.green)
                            {
                                greenCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.blue)
                            {
                                blueCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.yellow)
                            {
                                yellowCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.white)
                            {
                                whiteCounter++;
                            }
                            pointsAwarded = true;
                        }
                        grid[x, rowTracker].GetComponent<Renderer>().material.color =
                            grid[x - 1, rowTracker].GetComponent<Renderer>().material.color;
                        grid[1, rowTracker].GetComponent<Renderer>().material.color =
                            CubePosition.pusherGrid[CubePosition.pusherOneX,
                            CubePosition.pusherOneY].GetComponent<Renderer>().material.color;
                    }
                }
                if (columnTracker == 9)
                {
                    for (int x = 1; x < gridWidth; x++)
                    {
                        if (!pointsAwarded)
                        {
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.black)
                            {
                                blackCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.red)
                            {
                                redCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.green)
                            {
                                greenCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.blue)
                            {
                                blueCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.yellow)
                            {
                                yellowCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.white)
                            {
                                whiteCounter++;
                            }
                            pointsAwarded = true;
                        }
                        grid[x, rowTracker].GetComponent<Renderer>().material.color =
                            grid[x + 1, rowTracker].GetComponent<Renderer>().material.color;
                        grid[8, rowTracker].GetComponent<Renderer>().material.color =
                            CubePosition.pusherGrid[CubePosition.pusherOneX,
                            CubePosition.pusherOneY].GetComponent<Renderer>().material.color;
                    }
                }
                pointsAwarded = false;
                rowTracker = -1;
            }
            else if (columnTracker == 4)
            {
                if (rowTracker == 6)
                {
                    for (int y = gridHeight; y > 1; y--)
                    {
                        if (!pointsAwarded)
                        {
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.black)
                            {
                                blackCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.red)
                            {
                                redCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.green)
                            {
                                greenCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.blue)
                            {
                                blueCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.yellow)
                            {
                                yellowCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.white)
                            {
                                whiteCounter++;
                            }
                            pointsAwarded = true;
                        }
                        grid[columnTracker, y].GetComponent<Renderer>().material.color =
                            grid[columnTracker, y - 1].GetComponent<Renderer>().material.color;
                        grid[columnTracker, 1].GetComponent<Renderer>().material.color =
                            CubePosition.pusherGrid[CubePosition.pusherOneX,
                            CubePosition.pusherOneY].GetComponent<Renderer>().material.color;
                    }
                }
                if (rowTracker == 0)
                {
                    for (int y = 1; y < gridHeight; y++)
                    {
                        if (!pointsAwarded)
                        {
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.black)
                            {
                                blackCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.red)
                            {
                                redCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.green)
                            {
                                greenCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.blue)
                            {
                                blueCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.yellow)
                            {
                                yellowCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.white)
                            {
                                whiteCounter++;
                            }
                            pointsAwarded = true;
                        }
                        grid[columnTracker, y].GetComponent<Renderer>().material.color =
                            grid[columnTracker, y + 1].GetComponent<Renderer>().material.color;
                        grid[columnTracker, 1].GetComponent<Renderer>().material.color =
                            CubePosition.pusherGrid[CubePosition.pusherOneX,
                            CubePosition.pusherOneY].GetComponent<Renderer>().material.color;
                    }
                }
            }

            if (rowTracker == 5)
            {
                if (columnTracker == 0)
                {
                    for (int x = gridWidth; x > 1; x--)
                    {
                        if (!pointsAwarded)
                        {
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.black)
                            {
                                blackCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.red)
                            {
                                redCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.green)
                            {
                                greenCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.blue)
                            {
                                blueCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.yellow)
                            {
                                yellowCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.white)
                            {
                                whiteCounter++;
                            }
                            pointsAwarded = true;
                        }
                        grid[x, rowTracker].GetComponent<Renderer>().material.color =
                            grid[x - 1, rowTracker].GetComponent<Renderer>().material.color;
                        grid[1, rowTracker].GetComponent<Renderer>().material.color =
                            CubePosition.pusherGrid[CubePosition.pusherOneX,
                            CubePosition.pusherOneY].GetComponent<Renderer>().material.color;
                    }
                }
                if (columnTracker == 9)
                {
                    for (int x = 1; x < gridWidth; x++)
                    {
                        if (!pointsAwarded)
                        {
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.black)
                            {
                                blackCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.red)
                            {
                                redCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.green)
                            {
                                greenCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.blue)
                            {
                                blueCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.yellow)
                            {
                                yellowCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.white)
                            {
                                whiteCounter++;
                            }
                            pointsAwarded = true;
                        }
                        grid[x, rowTracker].GetComponent<Renderer>().material.color =
                            grid[x + 1, rowTracker].GetComponent<Renderer>().material.color;
                        grid[8, rowTracker].GetComponent<Renderer>().material.color =
                            CubePosition.pusherGrid[CubePosition.pusherOneX,
                            CubePosition.pusherOneY].GetComponent<Renderer>().material.color;
                    }
                }
                pointsAwarded = false;
                rowTracker = -1;
            }
            else if (columnTracker == 5)
            {
                if (rowTracker == 6)
                {
                    for (int y = gridHeight; y > 1; y--)
                    {
                        if (!pointsAwarded)
                        {
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.black)
                            {
                                blackCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.red)
                            {
                                redCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.green)
                            {
                                greenCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.blue)
                            {
                                blueCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.yellow)
                            {
                                yellowCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.white)
                            {
                                whiteCounter++;
                            }
                            pointsAwarded = true;
                        }
                        grid[columnTracker, y].GetComponent<Renderer>().material.color =
                            grid[columnTracker, y - 1].GetComponent<Renderer>().material.color;
                        grid[columnTracker, 1].GetComponent<Renderer>().material.color =
                            CubePosition.pusherGrid[CubePosition.pusherOneX,
                            CubePosition.pusherOneY].GetComponent<Renderer>().material.color;
                    }
                }
                if (rowTracker == 0)
                {
                    for (int y = 1; y < gridHeight; y++)
                    {
                        if (!pointsAwarded)
                        {
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.black)
                            {
                                blackCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.red)
                            {
                                redCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.green)
                            {
                                greenCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.blue)
                            {
                                blueCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.yellow)
                            {
                                yellowCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.white)
                            {
                                whiteCounter++;
                            }
                            pointsAwarded = true;
                        }
                        grid[columnTracker, y].GetComponent<Renderer>().material.color =
                            grid[columnTracker, y + 1].GetComponent<Renderer>().material.color;
                        grid[columnTracker, 1].GetComponent<Renderer>().material.color =
                            CubePosition.pusherGrid[CubePosition.pusherOneX,
                            CubePosition.pusherOneY].GetComponent<Renderer>().material.color;
                    }
                }
            }

            if (rowTracker == 6)
            {
                if (columnTracker == 0)
                {
                    for (int x = gridWidth; x > 1; x--)
                    {
                        if (!pointsAwarded)
                        {
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.black)
                            {
                                blackCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.red)
                            {
                                redCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.green)
                            {
                                greenCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.blue)
                            {
                                blueCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.yellow)
                            {
                                yellowCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.white)
                            {
                                whiteCounter++;
                            }
                            pointsAwarded = true;
                        }
                        grid[x, rowTracker].GetComponent<Renderer>().material.color =
                            grid[x - 1, rowTracker].GetComponent<Renderer>().material.color;
                        grid[1, rowTracker].GetComponent<Renderer>().material.color =
                            CubePosition.pusherGrid[CubePosition.pusherOneX,
                            CubePosition.pusherOneY].GetComponent<Renderer>().material.color;
                    }
                }
                if (columnTracker == 9)
                {
                    for (int x = 1; x < gridWidth; x++)
                    {
                        if (!pointsAwarded)
                        {
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.black)
                            {
                                blackCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.red)
                            {
                                redCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.green)
                            {
                                greenCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.blue)
                            {
                                blueCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.yellow)
                            {
                                yellowCounter++;
                            }
                            if (grid[gridWidth, rowTracker].GetComponent<Renderer>().material.color == Color.white)
                            {
                                whiteCounter++;
                            }
                            pointsAwarded = true;
                        }
                        grid[x, rowTracker].GetComponent<Renderer>().material.color =
                            grid[x + 1, rowTracker].GetComponent<Renderer>().material.color;
                        grid[8, rowTracker].GetComponent<Renderer>().material.color =
                            CubePosition.pusherGrid[CubePosition.pusherOneX,
                            CubePosition.pusherOneY].GetComponent<Renderer>().material.color;
                    }
                }
                pointsAwarded = false;
                rowTracker = -1;
            }
            else if (columnTracker == 6)
            {
                if (rowTracker == 6)
                {
                    for (int y = gridHeight; y > 1; y--)
                    {
                        if (!pointsAwarded)
                        {
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.black)
                            {
                                blackCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.red)
                            {
                                redCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.green)
                            {
                                greenCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.blue)
                            {
                                blueCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.yellow)
                            {
                                yellowCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.white)
                            {
                                whiteCounter++;
                            }
                            pointsAwarded = true;
                        }
                        grid[columnTracker, y].GetComponent<Renderer>().material.color =
                            grid[columnTracker, y - 1].GetComponent<Renderer>().material.color;
                        grid[columnTracker, 1].GetComponent<Renderer>().material.color =
                            CubePosition.pusherGrid[CubePosition.pusherOneX,
                            CubePosition.pusherOneY].GetComponent<Renderer>().material.color;
                    }
                }
                if (rowTracker == 0)
                {
                    for (int y = 1; y < gridHeight; y++)
                    {
                        if (!pointsAwarded)
                        {
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.black)
                            {
                                blackCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.red)
                            {
                                redCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.green)
                            {
                                greenCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.blue)
                            {
                                blueCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.yellow)
                            {
                                yellowCounter++;
                            }
                            if (grid[columnTracker, gridHeight].GetComponent<Renderer>().material.color == Color.white)
                            {
                                whiteCounter++;
                            }
                            pointsAwarded = true;
                        }
                        grid[columnTracker, y].GetComponent<Renderer>().material.color =
                            grid[columnTracker, y + 1].GetComponent<Renderer>().material.color;
                        grid[columnTracker, 1].GetComponent<Renderer>().material.color =
                            CubePosition.pusherGrid[CubePosition.pusherOneX,
                            CubePosition.pusherOneY].GetComponent<Renderer>().material.color;
                    }
                }
            }
            scoringStart = true;
        }

        if (scoringStart)
        {
            for (int x = 1; x < gridWidth; x++)
            {
                int y = 5;

                if (grid[x,y].GetComponent<Renderer>().material.color ==
                    grid[x+1, y].GetComponent<Renderer>().material.color)
                {
                    if (grid[x, y].GetComponent<Renderer>().material.color ==
                        grid[x+2, y].GetComponent<Renderer>().material.color)
                    {
                        score = score + 10;
                    }
                }
            }

            for (int x = 1; x < gridWidth; x++)
            {
                int y = 4;

                if (grid[x, y].GetComponent<Renderer>().material.color ==
                    grid[x + 1, y].GetComponent<Renderer>().material.color)
                {
                    if (grid[x, y].GetComponent<Renderer>().material.color ==
                        grid[x + 2, y].GetComponent<Renderer>().material.color)
                    {
                        score = score + 10;
                    }
                }
            }

            for (int x = 1; x < gridWidth; x++)
            {
                int y = 3;

                if (grid[x, y].GetComponent<Renderer>().material.color ==
                    grid[x + 1, y].GetComponent<Renderer>().material.color)
                {
                    if (grid[x, y].GetComponent<Renderer>().material.color ==
                        grid[x + 2, y].GetComponent<Renderer>().material.color)
                    {
                        score = score + 10;
                    }
                }
            }

            for (int x = 1; x < gridWidth; x++)
            {
                int y = 2;

                if (grid[x, y].GetComponent<Renderer>().material.color ==
                    grid[x + 1, y].GetComponent<Renderer>().material.color)
                {
                    if (grid[x, y].GetComponent<Renderer>().material.color ==
                        grid[x + 2, y].GetComponent<Renderer>().material.color)
                    {
                        score = score + 10;
                    }
                }
            }

            for (int x = 1; x < gridWidth; x++)
            {
                int y = 1;

                if (grid[x, y].GetComponent<Renderer>().material.color ==
                    grid[x + 1, y].GetComponent<Renderer>().material.color)
                {
                    if (grid[x, y].GetComponent<Renderer>().material.color ==
                        grid[x + 2, y].GetComponent<Renderer>().material.color)
                    {
                        score = score + 10;
                    }
                }
            }

            turnCounter++;
        }


            //loot
            lootText.text = "Black: " + blackCounter + System.Environment.NewLine +
                "Blue: " + blueCounter + System.Environment.NewLine +
                "Green: " + greenCounter + System.Environment.NewLine +
                "Red: " + redCounter + System.Environment.NewLine +
                "Yellow: " + yellowCounter + System.Environment.NewLine +
                "White: " + whiteCounter;

            scoreText.text = "Turns: "+turnCounter+ System.Environment.NewLine +
            "Score: "+score;
            

           
            planningStart = true;

        if (turnCounter == 15)
        {
            SwitchScenes();
        }
    }
    }




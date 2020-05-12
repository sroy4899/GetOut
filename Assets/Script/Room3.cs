using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room3 : MonoBehaviour
{
    public class Cell
    {
        public int x;
        public int z;
        public GameObject north;
        public GameObject south;
        public GameObject east;
        public GameObject west;
        public bool visited;

        public Cell(int x, int z)
        {
            this.x = x;
            this.z = z;
            this.visited = false;
        }
    }

    public GameObject wall;
    public AudioClip advance;
    public AudioClip snap;
    //public AudioClip chestOpen;
    private AudioSource audioSource;
    public GameObject letter;
    public GameObject ballRef;
    public GameObject startSquare;
    public GameObject endSquare;
    public static Cell[][] cells;
    public static bool lever1Pull = false, lever1Done = true, lever2Pull = false, lever2Done = true, lever3Pull = false;
    private float waitTime = 1.0f;
    private float timer = 0.0f;
    private int direction = 1;
    private Vector3 center = new Vector3(0f, 5f, 49.5f);
    private int orientation = 0;
    private int xPos = 0;
    private int yPos = 0;
    private GameObject start;
    private GameObject end;
    private GameObject ball;
    private bool firstBall = true;
    public static bool finished = false;
    public GameObject chest;
    private Animator chestAm;
    private bool firstBrief = true;
    public GameObject background;

    // Start is called before the first frame update
    void Start()
    { 
        audioSource = GetComponent<AudioSource>(); 
        letter.SetActive(false);
        cells = new Cell[10][];

        for(int i = 0; i < 10; i++)
        {
            cells[i] = new Cell[10];

            for (int j = 0; j < 10; j++)
            {
                cells[i][j] = new Cell(i, j);
            }
        }

        for (int i = 0; i <= 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                GameObject currWall = Instantiate(wall, new Vector3(((float) i) * 5 / 8 - 3.125f, ((float) j) * 5 / 8 + 2.1875f, 49.5f), Quaternion.identity);

                if (i != 10)
                {
                    cells[i][j].east = currWall;
                }

                if (i != 0)
                {
                    cells[i - 1][j].west = currWall;
                }
            }
        }

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j <= 10; j++)
            {
                GameObject currWall = Instantiate(wall, new Vector3((i + 0.5f) * 5 / 8 - 3.125f, (j - 0.5f) * 5 / 8 + 2.1875f, 49.5f), Quaternion.Euler(0, 0, 90));

                if (j != 10)
                {
                    cells[i][j].north = currWall;
                }

                if (j != 0)
                {
                    cells[i][j - 1].south = currWall;
                }
            }
        }

        makeMaze(cells, 10);

        chestAm = chest.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(BriefcaseController.briefcaseCorrect && firstBrief)
        {
            Vector3 startSquarePos = (cells[0][0].west.transform.position + cells[0][0].east.transform.position) / 2;
            start = Instantiate(startSquare, new Vector3(startSquarePos.x, startSquarePos.y, 49.75f), Quaternion.identity);

            Vector3 endSquarePos = (cells[9][9].west.transform.position + cells[9][9].east.transform.position) / 2;
            end = Instantiate(endSquare, new Vector3(endSquarePos.x, endSquarePos.y, 49.75f), Quaternion.identity);

            firstBrief = false;
        }

        if (!finished)
        {
            if (MazeBall.inMaze && firstBall)
            {
                firstBall = false;
                ball = Instantiate(ballRef, new Vector3(0f, 0f, 0f), Quaternion.identity);
                ball.transform.position = (cells[0][0].west.transform.position + cells[0][0].east.transform.position) / 2;

                Rigidbody rbb = ball.GetComponent<Rigidbody>();
                rbb.useGravity = false;

                audioSource.PlayOneShot(snap);
            }

            if (MazeBall.inMaze && Vector3.Distance(ball.transform.position, end.transform.position) <= 0.27f)
            {
                finished = true;
                letter.SetActive(true);
                //audioSource.PlayOneShot(chestOpen);
                chestAm.SetBool("Open", true);
            }

            if (lever1Pull && lever1Done)
            {
                lever1Done = false;
                timer = 0.0f;
                direction = 1;
                orientation = (orientation + 1) % 4;
            }

            if (lever2Pull && lever2Done)
            {
                lever2Done = false;
                timer = 0.0f;
                direction = -1;
                orientation = (orientation - 1) % 4;

                if (orientation < 0)
                {
                    orientation += 4;
                }
            }

            if (lever1Pull || lever2Pull)
            {
                timer += Time.deltaTime;
            }

            if (timer > waitTime)
            {
                if (lever1Pull)
                {
                    lever1Pull = false;
                    lever1Done = true;
                }

                if (lever2Pull)
                {
                    lever2Pull = false;
                    lever2Done = true;
                }
            }

            if ((lever1Pull && !lever1Done) || (lever2Pull && !lever2Done))
            {
                int degrees = 90 * direction;

                ball.transform.RotateAround(center, Vector3.forward, degrees * Time.deltaTime);
                start.transform.RotateAround(center, Vector3.forward, degrees * Time.deltaTime);
                end.transform.RotateAround(center, Vector3.forward, degrees * Time.deltaTime);
                background.transform.RotateAround(center, Vector3.forward, degrees * Time.deltaTime);

                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        cells[i][j].north.transform.RotateAround(center, Vector3.forward, degrees * Time.deltaTime);
                        cells[i][j].east.transform.RotateAround(center, Vector3.forward, degrees * Time.deltaTime);

                        if (i == 9)
                        {
                            cells[i][j].west.transform.RotateAround(center, Vector3.forward, degrees * Time.deltaTime);
                        }

                        if (j == 9)
                        {
                            cells[i][j].south.transform.RotateAround(center, Vector3.forward, degrees * Time.deltaTime);
                        }
                    }
                }
            }

            if (lever3Pull)
            {
                moveRight();
                lever3Pull = false;
            }
        }
    }

    void moveRight()
    {
        if((orientation == 0) && (cells[xPos][yPos].west.activeSelf == false))
        {
            audioSource.PlayOneShot(advance);
            xPos += 1;
        }

        if ((orientation == 1) && (cells[xPos][yPos].north.activeSelf == false))
        {
            audioSource.PlayOneShot(advance);
            yPos -= 1;
        }

        if ((orientation == 2) && (cells[xPos][yPos].east.activeSelf == false))
        {
            audioSource.PlayOneShot(advance);
            xPos -= 1;
        }

        if ((orientation == 3) && (cells[xPos][yPos].south.activeSelf == false))
        {
            audioSource.PlayOneShot(advance);
            yPos += 1;
        }

        ball.transform.position = (cells[xPos][yPos].west.transform.position + cells[xPos][yPos].east.transform.position) / 2;
    }

    void makeMaze(Cell[][] cells, int size)
    {
        cells[1][2].visited = true;

        ArrayList visitedWalls = new ArrayList();
        visitedWalls.Add("1112");
        visitedWalls.Add("1213");
        visitedWalls.Add("2212");
        visitedWalls.Add("1202");

        while (visitedWalls.Count > 0)
        {
            int pos = Random.Range(0, visitedWalls.Count);
            string coords = (string)visitedWalls[pos];
            visitedWalls.RemoveAt(pos);

            int x1 = int.Parse(coords.Substring(0, 1));
            int y1 = int.Parse(coords.Substring(1, 1));
            int x2 = int.Parse(coords.Substring(2, 1));
            int y2 = int.Parse(coords.Substring(3, 1));

            if ((cells[x1][y1].visited == false) || (cells[x2][y2].visited == false))
            {
                if (x1 == x2)
                {
                    cells[x1][y1].south.SetActive(false);
                }
                else
                {
                    cells[x1][y1].east.SetActive(false);
                }

                if (cells[x1][y1].visited == false)
                {
                    cells[x1][y1].visited = true;
                    addNeighbors(x1, y1, visitedWalls, size);
                }

                if (cells[x2][y2].visited == false)
                {
                    cells[x2][y2].visited = true;
                    addNeighbors(x2, y2, visitedWalls, size);
                }
            }
        }
    }

    void addNeighbors(int x, int y, ArrayList visitedWalls, int size)
    {
        if (x == 0)
        {
            if (y == 0)
            {
                addToVisitedWalls(visitedWalls, "1000");
                addToVisitedWalls(visitedWalls, "0001");
            }
            else if (y == (size - 1))
            {
                addToVisitedWalls(visitedWalls, (x + 1).ToString() + y.ToString() + x.ToString() + y.ToString());
                addToVisitedWalls(visitedWalls, x.ToString() + (y - 1).ToString() + x.ToString() + y.ToString());
            }
            else
            {
                addToVisitedWalls(visitedWalls, x.ToString() + (y - 1).ToString() + x.ToString() + y.ToString());
                addToVisitedWalls(visitedWalls, x.ToString() + y.ToString() + x.ToString() + (y + 1).ToString());
                addToVisitedWalls(visitedWalls, (x + 1).ToString() + y.ToString() + x.ToString() + y.ToString());
            }
        }
        else if (y == 0)
        {
            if (x == (size - 1))
            {
                addToVisitedWalls(visitedWalls, x.ToString() + y.ToString() + (x - 1).ToString() + y.ToString());
                addToVisitedWalls(visitedWalls, x.ToString() + y.ToString() + x.ToString() + (y + 1).ToString());
            }
            else
            {
                addToVisitedWalls(visitedWalls, (x + 1).ToString() + y.ToString() + x.ToString() + y.ToString());
                addToVisitedWalls(visitedWalls, x.ToString() + y.ToString() + (x - 1).ToString() + y.ToString());
                addToVisitedWalls(visitedWalls, x.ToString() + y.ToString() + x.ToString() + (y + 1).ToString());
            }

        }
        else if (x == (size - 1))
        {
            if (y == (size - 1))
            {
                addToVisitedWalls(visitedWalls, x.ToString() + (y - 1).ToString() + x.ToString() + y.ToString());
                addToVisitedWalls(visitedWalls, x.ToString() + y.ToString() + (x - 1).ToString() + y.ToString());
            }
            else
            {
                addToVisitedWalls(visitedWalls, x.ToString() + (y - 1).ToString() + x.ToString() + y.ToString());
                addToVisitedWalls(visitedWalls, x.ToString() + y.ToString() + x.ToString() + (y + 1).ToString());
                addToVisitedWalls(visitedWalls, x.ToString() + y.ToString() + (x - 1).ToString() + y.ToString());
            }

        }
        else if (y == (size - 1))
        {
            addToVisitedWalls(visitedWalls, (x + 1).ToString() + y.ToString() + x.ToString() + y.ToString());
            addToVisitedWalls(visitedWalls, x.ToString() + y.ToString() + (x - 1).ToString() + y.ToString());
            addToVisitedWalls(visitedWalls, x.ToString() + (y - 1).ToString() + x.ToString() + y.ToString());
        }
        else
        {
            addToVisitedWalls(visitedWalls, x.ToString() + (y - 1).ToString() + x.ToString() + y.ToString());
            addToVisitedWalls(visitedWalls, x.ToString() + y.ToString() + x.ToString() + (y + 1).ToString());
            addToVisitedWalls(visitedWalls, (x + 1).ToString() + y.ToString() + x.ToString() + y.ToString());
            addToVisitedWalls(visitedWalls, x.ToString() + y.ToString() + (x - 1).ToString() + y.ToString());
        }
    }

    void addToVisitedWalls(ArrayList visitedWalls, string cells)
    {
        if (!visitedWalls.Contains(cells))
        {
            visitedWalls.Add(cells);
        }
    }
}

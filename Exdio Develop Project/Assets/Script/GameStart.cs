using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameStart : MonoBehaviour
{
    float MaxDistance = 15f;
    float Distance = 0.0f;
    Vector3 MousePosition;
    private Vector3[] pos;
    private int posNum = 8;
    public Transform miniGame;
    public GameObject target;
    private GameObject[] cctv;
    public int cctvNum;
    private bool isTargetTrue = false;
    public GameObject[] Button;
    private Image[] b_Image;
    private bool previouslySelected;
    private int[] isSelected;
    private int selectNum;
    private int selectedButtonNum1;
    private int selectedButtonNum2;
    private int ButtonNum = 8;
    public static bool isProduction;
    public new Camera camera;
    public Canvas canvas; // raycast가 될 캔버스
    Transform Cam;
    public bool isSelectButton = false;
    bool isHacked;
    int cctvnum;

    public List<Color> colorList = new List<Color>() { };
    private int colorNum;

    GameObject thisLine;
    public GameObject thisMiniGame;
    GameObject ccsight;
    private int isDraw;
    private bool isDrawLine;

    private LineRenderer line;
    public Material material;
    private Vector3 mousePos;
    private int currLines;
    static public Vector3 campos;
    static public bool m_game;

    void Start()
    {
        Cam = GameObject.Find("Main Camera").GetComponent<Transform>();
        isProduction = false;
        isHacked = false;
        colorNum = ButtonNum / 2;
        cctv = new GameObject[cctvNum];
        cctv = GameObject.FindGameObjectsWithTag("cctv");
        canvas = miniGame.GetComponent<Canvas>();
        canvas.worldCamera = camera;
    }

    void Update()
    {
        if (isProduction == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                CastRay();
                for(int i = 0; i<cctvNum;i++)
                {
                    isTargetTrue = (target == cctv[i]);
                    if (isTargetTrue == true)
                        break;
                }
                if (isTargetTrue)
                {
                    m_game = true;
                    Time.timeScale = 0.4f;
                    Instantiate(miniGame, new Vector3(0, 0, 0), Quaternion.identity);
                    thisMiniGame = GameObject.FindGameObjectWithTag("MiniGame");
                    thisMiniGame.transform.parent = Cam;
                    Button = new GameObject[ButtonNum];
                    pos = new Vector3[posNum];
                    b_Image = new Image[ButtonNum];
                    isSelected = new int[ButtonNum];
                    currLines = 0;
                    selectNum = 0;
                    campos = Cam.position;
                    for (int i = 0; i < ButtonNum; i++)
                    {
                        Button[i] = GameObject.Find("Point" + i);
                        b_Image[i] = Button[i].GetComponent<Image>();
                        pos[i] = Button[i].transform.position;
                    }
                    AddColor();
                    for (int i = 0; i <ButtonNum; i+=2)
                    {
                        int rand = Random.Range(0, colorList.Count);
                        b_Image[i].color = colorList[rand];
                        colorList.RemoveAt(rand);
                    }
                    AddColor();
                    for (int i = 1; i < ButtonNum; i += 2)
                    {
                        int rand = Random.Range(0, colorList.Count);
                        b_Image[i].color = colorList[rand];
                        colorList.RemoveAt(rand);
                    }
                    isProduction = true;
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                isDrawLine = false;
                MousePosition = Input.mousePosition;
                MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);
                for (int i = 0; i < ButtonNum; i++)
                {
                    Distance = (MousePosition.x - pos[i].x) * (MousePosition.x - pos[i].x) + (MousePosition.y - pos[i].y) * (MousePosition.y - pos[i].y);
                    if (Distance < 0.08)
                    {
                        isSelectButton = true;
                        selectedButtonNum1 = i;
                        if (selectNum < ButtonNum)
                            isSelected[selectNum] = selectedButtonNum1;
                        for (int x = 0; x < selectNum; x++)
                        {
                            previouslySelected = (isSelected[x] == selectedButtonNum1);
                            if (previouslySelected == true)
                                break;
                        }
                        if (previouslySelected == false)
                        {
                            selectNum++;
                            if (line == null)
                            {
                                CreateLine(selectedButtonNum1);
                            }
                            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                            mousePos.z = -1;
                            pos[i].z = -1;
                            line.SetPosition(0, pos[i]);
                            line.SetPosition(1, mousePos);
                            break;
                        }
                        break;
                    }
                }
            }
            else if (Input.GetMouseButtonUp(0) && line)
            {
                if (isSelectButton == true)
                {
                    MousePosition = Input.mousePosition;
                    MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);
                    if (selectedButtonNum1 % 2 == 0)
                    {
                        LineDraw(1);
                    }
                    else
                    {
                        LineDraw(0);
                    }
                    if (isDrawLine == false)
                    {
                        selectNum--;
                        thisLine = GameObject.Find("Line" + currLines);
                        Destroy(thisLine);
                    }
                    if(selectNum==8)
                    {
                        isProduction = false;
                        for(int i=0; i<currLines; i++)
                        {
                            thisLine = GameObject.Find("Line" + i);
                            Destroy(thisLine, 0.2f);
                        }
                        Destroy(thisMiniGame, 0.2f);
                        isHacked = true;
                    }
                    isSelectButton = false;
                }
            }
            else if (Input.GetMouseButton(0) && line)
            {
                if (isSelectButton == true)
                {
                    mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    mousePos.z = -1;
                    line.SetPosition(1, mousePos);
                }
            }
        }
        if (isHacked)
        {
            Debug.Log("Hacked");
            m_game = false;
            Time.timeScale = 1f;
            if (cctvnum == 1)
            {

                ccsight = GameObject.Find("cctv_sight1");
                ccsight.SetActive(false);
                isHacked = false;
            }
            if (cctvnum == 2)
            {
                ccsight = GameObject.Find("cctv_sight2");
                ccsight.SetActive(false);
                isHacked = false;
            }
            if (cctvnum == 3)
            {
                ccsight = GameObject.Find("cctv_sight3");
                ccsight.SetActive(false);
                isHacked = false;
            }
            if (cctvnum == 4)
            {
                ccsight = GameObject.Find("cctv_sight4");
                ccsight.SetActive(false);
                isHacked = false;
            }
            cctvnum = 0;
        }
    }

    void CastRay() // 유닛 히트처리 부분.  레이를 쏴서 처리합니다. 
    {
        target = null;
        MousePosition = Input.mousePosition;
        MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);
        RaycastHit2D hit = Physics2D.Raycast(MousePosition, Vector2.zero, MaxDistance);
        if (hit.collider != null)
        { //히트되었다면 여기서 실행
            Debug.Log(hit.collider.name);  //이 부분을 활성화 하면, 선택된 오브젝트의 이름이 찍혀 나옵니다. 
            target = hit.collider.gameObject;  //히트 된 게임 오브젝트를 타겟으로 지정
            if (hit.collider.name == "cctv1")
            {
                cctvnum = 1;
            }
            if (hit.collider.name == "cctv2")
            {
                cctvnum = 2;
            }
            if (hit.collider.name == "cctv3")
            {
                cctvnum = 3;
            }
            if (hit.collider.name == "cctv4")
            {
                cctvnum = 4;
            }
            target.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    void CreateLine(int x)
    {
        line = new GameObject("Line" + currLines).AddComponent<LineRenderer>();
        line.transform.parent = Cam;
        line.material = material;
        line.material.color = b_Image[x].color;
        line.positionCount = 2;
        line.startWidth = 0.07f;
        line.endWidth = 0.07f;
        line.useWorldSpace = true;
        line.numCapVertices = 50;
        line.sortingOrder = 7;
    }

    void LineDraw(int x)
    {
        for (int i = x; i < ButtonNum; i += 2)
        {
            Distance = (MousePosition.x - pos[i].x) * (MousePosition.x - pos[i].x) + (MousePosition.y - pos[i].y) * (MousePosition.y - pos[i].y);
            if (Distance < 0.08)
            {
                selectedButtonNum2 = i;
                isSelected[selectNum] = selectedButtonNum2;
                isDraw = (selectedButtonNum1 + selectedButtonNum2) % 2;
                for (int k = 0; k < selectNum; k++)
                {
                    previouslySelected = (isSelected[k] == selectedButtonNum2);
                    if (previouslySelected == true)
                        break;
                }
                if ((isDraw == 1) && (previouslySelected == false))
                {
                    if (b_Image[selectedButtonNum1].color == b_Image[selectedButtonNum2].color)
                    {
                        selectNum++;
                        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        mousePos.z = -1;
                        pos[i].z = -1;
                        line.SetPosition(1, pos[i]);
                        line = null;
                        isDrawLine = true;
                        currLines++;
                        break;
                    }
                }
                break;
            }
        }
    }

    void AddColor()
    {
        colorList.Add(new Color(160 / 255f, 0 / 255f, 0 / 255f));
        colorList.Add(new Color(160 / 255f, 160 / 255f, 0 / 255f));
        colorList.Add(new Color(0 / 255f, 0 / 255f, 160 / 255f));
        colorList.Add(new Color(50 / 255f, 50 / 255f, 50 / 255f));
    }
}

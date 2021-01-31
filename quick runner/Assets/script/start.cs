using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    private TextMesh tm;

    public int NextLevel;

    public float dotAdderDelay;
    private float setDotAdderDelay;
    private int numberOfDots;

    void Start()
    {
        tm = GetComponent<TextMesh>();

        setDotAdderDelay = dotAdderDelay;

        tm.text = "";
    }


    void Update()
    {
        if (PlayerPrefs.GetInt("TTTestBegan") == 0)
        {
            dotAdderDelay -= Time.deltaTime;

            if (dotAdderDelay <= 0)
            {
                numberOfDots += 1;
                dotAdderDelay = setDotAdderDelay;
            }

            switch (numberOfDots)
            {
                case 0:
                    tm.text = "";
                    break;

                case 1:
                    tm.text = ".";
                    break;

                case 2:
                    tm.text = "..";
                    break;

                case 3:
                    tm.text = "...";
                    break;

                case 4:
                    tm.text = "....";
                    break;

                case 5:
                    tm.text = ".....";
                    break;

                case 6:
                    tm.text = "......";
                    break;

                case 7:
                    tm.text = ".......";
                    break;

                case 8:
                    tm.text = "........";
                    break;

                case 9:
                    tm.text = ".........";
                    break;

                case 10:
                    tm.text = "..........";
                    break;

                case 11:
                    tm.text = "T";
                    break;

                case 12:
                    tm.text = "TE";
                    break;

                case 13:
                    tm.text = "TES";
                    break;

                case 14:
                    tm.text = "TEST";
                    break;

                case 15:
                    tm.text = "S";
                    break;

                case 16:
                    tm.text = "ST";
                    break;

                case 17:
                    tm.text = "STA";
                    break;

                case 18:
                    tm.text = "STAR";
                    break;

                case 19:
                    tm.text = "START";
                    break;

                case 20:
                    tm.text = "STARTI";
                    break;

                case 21:
                    tm.text = "STARTIN";
                    break;

                case 22:
                    tm.text = "STARTING";
                    break;

                default:
                    PlayerPrefs.SetInt("TTTestBegan", 1);
                    SceneManager.LoadScene(NextLevel);
                    break;
            }
        }
        else
        {
            SceneManager.LoadScene(NextLevel);
        }
    }
}
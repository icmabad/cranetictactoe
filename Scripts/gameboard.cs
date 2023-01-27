using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameboard : MonoBehaviour
{
    //private char[] firstrow = new char[3];
    //private char[] secondrow = new char[3];
    //private char[] thirdrow = new char[3];
    private char[,] board = new char[3,3];
    private string owin = "Player O wins!";
    private string xwin = "Player X wins!";
    private string reset = "\nPress C to reset the game";
    // Start is called before the first frame update
    public Text win;
    public GameObject panel;

    private int gamecounter;
    public Text camecounttext;
    private int xcounter;
    public Text xtextcounter;
    private int ocounter;
    public Text otextcounter;
    private bool owins;

    void Start()
    {
        win.enabled = false;
        panel.SetActive(false);
        //if (PlayerPrefs.HasKey("gamesplaidcounter"))
        gamecounter = PlayerPrefs.GetInt("gamesplaidcounter",1);
        xcounter = PlayerPrefs.GetInt("xwincounter",0);
        ocounter = PlayerPrefs.GetInt("owincounter",0);
        camecounttext.text = "Game #: " + gamecounter;
        xtextcounter.text = "X: " + xcounter;
        otextcounter.text = "O: " + ocounter;

    }

    void end(bool xwins){
        owins = !xwins;
        if(xwins){
            win.text = xwin+reset;
            xtextcounter.text = "X: " + (xcounter+1);
        } else {
            win.text = owin+reset;
            otextcounter.text = "O: " + (ocounter+1);
        }
        win.enabled = true;
        panel.SetActive(true);
    }

    public void prints(){
        string t="";
        for(int i=0;i<3;i++){
            for(int j=0;j<3;j++){
                t=t+board[i,j];
            }
            t+=' ';
        }
        //Debug.Log(t);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C)&&win.enabled){
            gamecounter++;
            PlayerPrefs.SetInt("gamesplaidcounter", gamecounter);
            if(!owins){
                xcounter++;
                PlayerPrefs.SetInt("xwincounter",xcounter);
            } else {
                ocounter++;
                PlayerPrefs.SetInt("owincounter",ocounter);
            }
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }

        int count = 0;
        for(int i=0;i<3;i++){
            for(int j=0;j<3;j++){
                board[i,j] = transform.GetChild(count).GetComponent<smallgameboard>().piece;
                count++;
            }
        }

        //checks first row and first column
        if((board[0,0]==board[0,1] && board[0,1]==board[0,2])
            || (board[0,0]==board[1,0] && board[1,0]==board[2,0])){
            char temp = board[0,0];
            if(temp=='X'){
                end(true);
            } else if (temp=='O'){
                end(false); 
            }
        }

        //checks middle row and column
        if((board[1,0]==board[1,1] && board[1,1]==board[1,2])
            || (board[0,1]==board[1,1] && board[1,1]==board[2,1])){
            char temp = board[1,1];
            if(temp=='X'){
                end(true);
            } else if (temp=='O'){
                end(false); 
            }
        }

        //checks third row and column
        if((board[2,0]==board[2,1] && board[2,1]==board[2,2])
            || (board[0,2]==board[1,2] && board[1,2]==board[2,2])){
            char temp = board[2,2];
            if(temp=='X'){
                end(true);
            } else if (temp=='O'){
                end(false); 
            }
        }

        //checks diagonal
        if((board[0,0]==board[1,1] && board[1,1]==board[2,2])
            || (board[0,2]==board[1,1] && board[1,1]==board[2,0])){
            char temp = board[1,1];
            if(temp=='X'){
                end(true);
            } else if (temp=='O'){
                end(false); 
            }
        }
    }
}

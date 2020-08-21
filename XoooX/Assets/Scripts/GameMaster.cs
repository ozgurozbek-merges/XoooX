﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {
    public string[] Moves = new string[26] { "X", "O", "O", "X", "O", "X", "O", "X", "O", "X", "O", "X", "O", "X", "O", "X", "O", "X", "O", "X", "O", "X", "O", "X", "O", "X" };
    public string[, ] Red = new string[9, 2] { { "", "1"}, { "", "2"}, { "", "3"}, { "", "6" }, { "", "7"}, { "", "8"}, { "", "11"}, { "", "12"}, { "", "13"} };
    public string[, ] Blue = new string[9, 2] { { "", "13" }, { "", "14" }, { "", "15" }, { "", "18" }, { "", "19"}, { "", "20" }, { "", "23"}, { "", "24"}, { "", "25" } };
    public string[, ] Green = new string[9, 2] { { "", "3" }, { "", "4"}, { "", "5"}, { "", "8"}, { "", "9"}, { "", "10"}, { "", "13"}, { "", "14"}, { "", "15"} };
    public string[, ] Yellow = new string[9, 2] { { "", "11"}, { "", "12"}, { "", "13"}, { "", "16"}, { "", "17"}, { "", "18"}, { "", "21"}, { "", "22"}, { "", "23" } };
    Renderer rende;
    public int MoveNumber = 0;
    public int Xcount = 0;
    public int Ocount = 0;
    public static GameMaster instance;

    void Awake () {
        instance = this;
    }

    public Material xMaterial;
    public Material oMaterial;
    public Material xComboMaterial;
    public Material oComboMaterial;
    public GameObject SummonParticle;
    public GameObject ComboParticle;

    void Start () {
        planeToBuild = xMaterial;
        particle = SummonParticle;
        comboParticle = ComboParticle;
    }

    void Update () {
        Xcount = 0;
        Ocount = 0;
        if (Moves[MoveNumber] == "X") {
            planeToBuild = xMaterial;
        } else {
            planeToBuild = oMaterial;
        }
        /*
            Bilmiyorum ama büyük ihtimalle aşağıda bir yerde oComboMaterial
            ve xComboMaterial kullanıp materyali değiştirmen lazım. Satır 87
            ve sonrasında büyük ihtimalle. Buton isimlerini kullanmak için
            2D array yaptın ben anlamadım şu an ne yapmam lazım.
        */
        Xcount += Check (Red, "X");
        Xcount += Check (Green, "X");
        Xcount += Check (Yellow, "X");
        Xcount += Check (Blue, "X");
        Ocount += Check (Red, "O");
        Ocount += Check (Green, "O");
        Ocount += Check (Yellow, "O");
        Ocount += Check (Blue, "O");
        Debug.Log ("X= " + Xcount);
        Debug.Log ("O= " + Ocount);
    }

    private Material planeToBuild;
    public Material GetPlaneBuild () {
        return planeToBuild;
    }

    private GameObject particle;
    public GameObject GetParticle () {
        return particle;
    }

    //------------------------

    /*
    private Material comboToMake;
    public Material GetComboMaterial () {
        return comboToMake;
    }
    */

    private GameObject comboParticle;
    public GameObject GetComboParticle () {
        return comboParticle;
    }

    public int Check (string[,] OXO, string Word) {
        string[, ] checker = new string[9, 2];
        checker = OXO;
        int count = 0;

        if (checker[0, 0] == Word && checker[1, 0] == Word && checker[2, 0] == Word) 
        {   count++;
            if (Word=="X")
                {ChangePlaneColor(checker,0,1,2,xComboMaterial);}
            else 
                {ChangePlaneColor(checker,0,1,2,oComboMaterial);}
        }
        if (checker[0, 0] == Word && checker[3, 0] == Word && checker[6, 0] == Word)
         {   count++;
            if (Word=="X")
                {ChangePlaneColor(checker,0,3,6,xComboMaterial);}
            else 
                {ChangePlaneColor(checker,0,3,6,oComboMaterial);}
        }
        if (checker[0, 0] == Word && checker[4, 0] == Word && checker[8, 0] == Word) 
        {   count++;
            if (Word=="X")
                {ChangePlaneColor(checker,0,4,8,xComboMaterial);}
            else 
                {ChangePlaneColor(checker,0,4,8,oComboMaterial);}
        }
        if (checker[1, 0] == Word && checker[4, 0] == Word && checker[7, 0] == Word) 
        {   count++;
            if (Word=="X")
                {ChangePlaneColor(checker,1,4,7,xComboMaterial);}
            else 
                {ChangePlaneColor(checker,1,4,7,oComboMaterial);}
        }
        if (checker[2, 0] == Word && checker[5, 0] == Word && checker[8, 0] == Word) 
        {   count++;
            if (Word=="X")
                {ChangePlaneColor(checker,2,5,8,xComboMaterial);}
            else 
                {ChangePlaneColor(checker,2,5,8,oComboMaterial);}
        }
        if (checker[2, 0] == Word && checker[4, 0] == Word && checker[6, 0] == Word) 
        {   count++;
            if (Word=="X")
                {ChangePlaneColor(checker,2,4,6,xComboMaterial);}
            else 
                {ChangePlaneColor(checker,2,4,6,oComboMaterial);}
        }
        if (checker[3, 0] == Word && checker[4, 0] == Word && checker[5, 0] == Word)
         {   count++;
            if (Word=="X")
                {ChangePlaneColor(checker,3,4,5,xComboMaterial);}
            else 
                {ChangePlaneColor(checker,3,4,5,oComboMaterial);}
        }
        if (checker[6, 0] == Word && checker[7, 0] == Word && checker[8, 0] == Word) 
        {   count++;
            
            if (Word=="X")
                {ChangePlaneColor(checker,6,7,8,xComboMaterial);}
            else 
                {ChangePlaneColor(checker,6,7,8,oComboMaterial);}
        }
        return count;
    }
    public void ChangePlaneColor(string[,] mehmet,int sira1,int sira2,int sira3,Material material_)
    {   
        
        GameObject.Find("Planes/"+mehmet[sira1,1]).GetComponent<Renderer> ().sharedMaterial= material_;
        GameObject.Find("Planes/"+mehmet[sira2,1]).GetComponent<Renderer> ().sharedMaterial= material_;
        GameObject.Find("Planes/"+mehmet[sira3,1]).GetComponent<Renderer> ().sharedMaterial= material_;
        Instantiate(ComboParticle,GameObject.Find("Planes/"+mehmet[sira1,1]).transform.position,GameObject.Find("Planes/"+mehmet[sira1,1]).transform.rotation);
        Instantiate(ComboParticle,GameObject.Find("Planes/"+mehmet[sira2,1]).transform.position,GameObject.Find("Planes/"+mehmet[sira2,1]).transform.rotation);
        Instantiate(ComboParticle,GameObject.Find("Planes/"+mehmet[sira3,1]).transform.position,GameObject.Find("Planes/"+mehmet[sira3,1]).transform.rotation);
     }
    
}
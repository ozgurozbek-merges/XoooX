﻿using UnityEngine;
using Mirror;
//gamemasterdaki değişkenlerden puanları ekrana yazıyoruz
public class Score : NetworkBehaviour {
    void Update () {
        GetComponent<TextMesh> ().text = "X :" + GameMaster.instance.Xcount + " O :" + GameMaster.instance.Ocount;
    }
}
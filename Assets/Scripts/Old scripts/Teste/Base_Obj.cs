using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Base_Obj : MonoBehaviour
{
    public Text textBox;
    string[] falas;
    int pula_fala;
    bool inicia_fala;

    public abstract void Start();

    public abstract void Update();

    public abstract void OnTriggerExit2D(Collider2D collision);

    public abstract void dialogos();
}

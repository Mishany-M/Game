using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleOnLevel : MonoBehaviour
{
    delegate void Delegate();
    Delegate[] el = new Delegate[] { gg, gg1, gg2, gg3, gg4, gg5, gg6 };
    [SerializeField] private int choose;
    [SerializeField] private GameObject sprite;
    [SerializeField] private Canvas canvas;
    private GameObject buffs;
    public ChooseModule choosemodule;

    public static void gg() { Debug.Log("ff"); }
    public static void gg1() { Debug.Log("qq"); }
    public static void gg2() { Debug.Log("ww"); }
    public static void gg3() { Debug.Log("ee"); }
    public static void gg4() { Debug.Log("cc"); }
    public static void gg5() { Debug.Log("ss"); }
    public static void gg6() { Debug.Log("aa"); }


    private void Start()
    {
        buffs = GameObject.FindGameObjectWithTag("Buffs");
        choosemodule = FindObjectOfType<ChooseModule>();
    }
    public void Press()
    {
        el[choose]();
        GameObject obj = Instantiate(sprite, buffs.transform.position, Quaternion.identity, buffs.transform);
        obj.transform.localPosition = new Vector2(0, 2 * -buffs.transform.childCount - 1);
        choosemodule.Press1();
    }
}

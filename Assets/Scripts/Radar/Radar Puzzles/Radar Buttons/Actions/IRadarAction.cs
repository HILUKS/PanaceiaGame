using UnityEngine;

public interface IRadarAction
{
    void ActionResult(string objtag,string buttonuse,GameObject button);
    void Correct(GameObject button);
    void Refresh(GameObject button);
    void Wrong(GameObject button, GameObject monster);
}
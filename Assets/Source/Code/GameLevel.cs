using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevel : MonoBehaviour
{
    public List<GameObject> gameObjectsPoint;
    [SerializeField] private Transform parentListObjPoint;
    private bool canCheck = true;
    [SerializeField] private List<Sprite> listRandom;
    public void Start()
    {
        canCheck = true;
        foreach (Transform tr in parentListObjPoint)
        {
            if(tr.gameObject.activeSelf)
                gameObjectsPoint.Add(tr.gameObject);
        }

        int sl = 0;
        Sprite it = listRandom[0];
        foreach (var p in gameObjectsPoint)
        {
            if (sl == 0) it = listRandom[Random.Range(0, listRandom.Count)];
            p.GetComponent<SpriteRenderer>().sprite = it;
            sl++;
            if (sl == 2) sl = 0;
        }
    }

    public void RemoveObject(GameObject obj)
    {
        gameObjectsPoint.Remove(obj);
        if (canCheck)
        {
            if (gameObjectsPoint.Count == 0)
            {
                GameManager.Instance.CheckLevelUp();
                canCheck = false;
            }
        }
    }
}

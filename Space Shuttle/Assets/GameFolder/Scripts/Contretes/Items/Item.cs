using UnityEngine;
using DG.Tweening;


public class Item : MonoBehaviour
{
    public SOItem item;

    public void Collecting()
    {
        transform.DOShakeScale(3f, 10f);
    }
    public void GetItem(GameObject target)
    {
        transform.DOMove(target.transform.position, 1f);
        transform.DOScale(Vector3.zero, 1f).OnComplete(() => Destroy(this.gameObject));
    }
}

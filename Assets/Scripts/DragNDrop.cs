using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DragNDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 startPos;
    public GameObject finalPos;

    private void Start()
    {
        startPos = this.transform.position;
    }

    private void Update()
    {
        Debug.Log(isDragging);
        if (isDragging)
        {
            transform.position = GetMouseWorldPosition() + offset;
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        return mousePosition;
    }

    private void OnMouseDown()
    {
        offset = transform.position - GetMouseWorldPosition();
        isDragging = true;
    }

    private void OnMouseUp()
    {
        isDragging = false;
        this.transform.DOMove(startPos, 0.5f);
        AudioSingleton.Instance.PlayPlaceFailSound();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(!isDragging)
        {
            if (collision.CompareTag(finalPos.tag))
            {
                this.gameObject.SetActive(false);
                finalPos.transform.GetChild(0).gameObject.SetActive(true);
                GlobalVariable.ansCount++;
                AudioSingleton.Instance.PlayPlaceSuccessSound();
            }
        }      
    }

}

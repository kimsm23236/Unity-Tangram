using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

public class PuzzlePlayPart : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private bool isClicked = false;
    private RectTransform objRect = default;
    private PuzzleInitZone puzzleInitZone = default;
    // Start is called before the first frame update
    void Start()
    {
        isClicked = false;
        objRect = gameObject.GetRect();
        puzzleInitZone = transform.parent.gameObject.GetComponentMust<PuzzleInitZone>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // 마우스 버튼을 눌렀을 때 동작하는 함수
    public void OnPointerDown(PointerEventData eventData)
    {
        isClicked = true;
    }
    // 마우스 버튼에서 손을 뗐을 때 동작하는 함수
    public void OnPointerUp(PointerEventData eventData)
    {
        isClicked = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        gameObject.AddAnchoredPos(eventData.delta / puzzleInitZone.parentCanvas.scaleFactor);
    }

    // Lagacy Code
    // 마우스를 드래그 중일 때 동작하는 함수
    // public void OnPointerMove(PointerEventData eventData)
    // {
    //     if(isClicked == true)
    //     {
    //         GFunc.Log($"마우스 포지션 눈으로 확인 ({eventData.position.x} {eventData.position.y})");
    //     }
    // }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PuzzlePlayPart : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public PuzzleType puzzleType = PuzzleType.NONE;
    private Image puzzleImage = default;
    private bool isClicked = false;
    private RectTransform objRect = default;
    private PuzzleInitZone puzzleInitZone = default;
    private PlayLevel playLevel = default;
    // Start is called before the first frame update
    void Start()
    {
        isClicked = false;
        objRect = gameObject.GetRect();
        puzzleInitZone = transform.parent.gameObject.GetComponentMust<PuzzleInitZone>();

        playLevel = GameManager.Instance.gameObjs[GData.OBJ_NAME_CURRENT_LEVEL].GetComponentMust<PlayLevel>();
        puzzleImage = gameObject.FindChildObj("PuzzleImage").GetComponentMust<Image>();
        // 퍼즐 이미지 이름에 따라서 퍼즐의 타입이 정해진다.
        switch(puzzleImage.sprite.name)
        {
            case "Puzzle_BigTriangle1":
            case "Puzzle_BigTriangle2":
            puzzleType = PuzzleType.PUZZLE_BIG_TRIANGLE;
            break;

            default:
            puzzleType = PuzzleType.NONE;
            break;
        }
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
        // 여기서 레벨이 가지고 있는 퍼즐 리스트를 순회해서 제자리를 찾는다.
        PuzzleLevelPart closeLvPuzzle = 
        playLevel.GetCloseSameTypePuzzle(puzzleType, transform.position);

        if(closeLvPuzzle == default || closeLvPuzzle == null)
        {
            return;
        }
        transform.position = closeLvPuzzle.transform.position;
        GFunc.Log($"{closeLvPuzzle.name}이 가장 가까이에 있습니다.");
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

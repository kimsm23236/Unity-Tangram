using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PuzzleLevelPart : MonoBehaviour
{
    public PuzzleType puzzleType = PuzzleType.NONE;
    private Image puzzleImage = default;
    // Start is called before the first frame update
    void Start()
    {
        
        puzzleImage = gameObject.FindChildObj("PuzzleLvImage").GetComponentMust<Image>();
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLevel : MonoBehaviour
{
    public int level = default;
    public List<PuzzleLevelPart> puzzleLvParts = default;
    private const float LV_PUZZLE_DISTANCE_LIMIT = 1f;
    public void Awake()
    {
        GameManager.Instance.gameObjs.Add(gameObject.name, gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        puzzleLvParts = new List<PuzzleLevelPart>();
        for(int i = 0 ; i < transform.childCount; i++)
        {
            puzzleLvParts.Add(transform.GetChild(i).gameObject.GetComponentMust<PuzzleLevelPart>());
        }   // loop : 레벨 하위에서 퍼즐 파츠를 모두 캐싱하는 루프
        GFunc.Log($"퍼즐 조각 갯수 : {puzzleLvParts.Count}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ! 퍼즐 타입을 받아서 해당 타입과 같은 타입의 퍼증을 리턴한는 함수
    public List<PuzzleLevelPart> GetSameTypePuzzle(PuzzleType puzzleType)
    {   
        List<PuzzleLevelPart> sameTypes = new List<PuzzleLevelPart>();
        foreach(var puzzleLvPart in puzzleLvParts)
        {
            if(puzzleLvPart.puzzleType.Equals(puzzleType))
            {
                sameTypes.Add(puzzleLvPart);
            }
            else
            {
                continue;
            }
        }
        return  sameTypes;
    }

    public PuzzleLevelPart GetCloseSameTypePuzzle(PuzzleType puzzleType, Vector3 puzzleWorldPos)
    {
        List<PuzzleLevelPart> sameTypes = GetSameTypePuzzle(puzzleType);
        float minDistance = float.MaxValue;
        float distance = float.MaxValue;
        int index = 0;
        PuzzleLevelPart result = default;
        foreach(var puzzleLvPart in sameTypes)
        {
            distance = Mathf.Abs((puzzleLvPart.transform.position - puzzleWorldPos).magnitude);
            if(distance <= minDistance)
            {
                minDistance = distance;
                result = puzzleLvPart;
            }
            index++;
        }

        if(LV_PUZZLE_DISTANCE_LIMIT < minDistance)
        {
            result = default;
        }
        return result;
    }
}

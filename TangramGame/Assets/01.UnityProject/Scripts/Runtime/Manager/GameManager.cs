using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : GSingleton<GameManager>
{
    public Dictionary<string, GameObject> gameObjs = default;
    public override void Awake()
    {
        base.Awake();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Init()
    {
        base.Init();
        // 여기서 게임 매니저가 초기화 된다.
        gameObjs = new Dictionary<string, GameObject>();
    }
}

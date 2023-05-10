using System.Collections;
using System.Collections.Generic;

public class GameManager
{
    private static GameManager mInstance;

    public static GameManager Instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = new GameManager();
            }
            return mInstance;
        }
    }

    public int ItemNum
    {
        get;
        set;
    }
}

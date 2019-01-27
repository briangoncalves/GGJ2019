using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownSingleton : Singleton<CountdownSingleton>
{
    // (Optional) Prevent non-singleton constructor use.
    protected CountdownSingleton() { }

    // Then add whatever code to the class you need as you normally would.
    public int StartTime = 3600;
    public int TimeLeft = 3600; //Seconds Overall
    public void RestartTime()
    {
        TimeLeft = StartTime;
    }
}

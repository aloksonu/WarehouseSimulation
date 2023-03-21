using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubLevelName : MonoBehaviour
{
    public int subLevelNumber;
    public SubLevelNames subLevelName;
    void Start()
    {
        
    }
}

public enum SubLevelNames
{

    NotSet = 0,
    Tipping = 1,
    OpenTrailer = 2,
    AssignLane = 3,
    CloseTrailer = 4,
    ManualReceipt = 5,
    NewSkuChecks = 6,
    PRCChecks = 7,
    QAChecks = 8,

    PutawayCartons = 9,
    Hanging = 10,
    Oversized = 11,

    Relocate = 12,
    AuditLocation = 13,
    Consolidation = 14,

    Standard = 15,
    HangingPicking = 16,

}

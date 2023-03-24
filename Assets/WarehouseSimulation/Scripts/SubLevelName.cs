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
    //Receiving
    NotSet = 0,
    Tipping = 1,
    OpenTrailer = 2,
    AssignLane = 3,
    CloseTrailer = 4,
    ManualReceipt = 5,
    NewSkuChecks = 6,
    PRCChecks = 7,
    QAChecks = 8,

    //Putaway
    PutawayCartons = 9,
    Hanging = 10,
    Oversized = 11,

    //InventoryManagement
    Relocate = 12,
    AuditLocation = 13,
    Consolidation = 14,

    //Picking
    Standard = 15,
    HangingPicking = 16,

    //ItemSortation
    Staging = 17,
    TrolleySort = 18,

    //Packing
    Packing = 19,

    //Despatch
    ParcelSortation = 20,
    HandleParcel = 21,
    LoadTM = 22,


}

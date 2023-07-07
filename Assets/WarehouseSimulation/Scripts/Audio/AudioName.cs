namespace WarehouseSimulation.Scripts.Audio
{
    public enum AudioName
    {

        NotSet=-1,
        GameBG = 0,
        ButtonClick = 1,
        Correct = 2,
        Wrong = 3,
        Receiving = 4,
        Putaway = 5,
        InventoryManagement = 6,
        Picking = 7,
        ItemSortation = 8,
        Packing = 9,
        Despatch = 10,

        //Receiving
        Tipping = 11,
        OpenTrailer = 12,
        AssignLane = 13,
        CloseTrailer = 14,
        ManualReceipt = 15,
        NewSkuChecks = 16,
        PRCChecks = 17,
        QAChecks = 18,

        //Putaway
        PutawayCartons = 19,
        Hanging = 20,
        Oversized = 21,

        //InventoryManagement
        Relocate = 22,
        AuditLocation = 23,
        Consolidation = 24,

        //Picking
        Standard = 25,
        HangingPicking = 26,

        //ItemSortation
        Staging = 27,
        TrolleySort = 28,

        //Packing
        SubPacking = 29,

        //Despatch
        ParcelSortation = 30,
        HandleParcel = 31,
        LoadTM = 32,

        Tutorial = 33,
    }
}
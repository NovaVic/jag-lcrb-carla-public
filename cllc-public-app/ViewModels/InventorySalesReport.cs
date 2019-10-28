namespace Gov.Lclb.Cllb.Public.ViewModels
{
    public class InventorySalesReport
    {
        public string product { get; set; }
        public int? openingInventory { get; set; }
        public int? domesticAdditions { get; set; }
        public int? returnsAdditions { get; set; }
        public int? otherAdditions { get; set; }
        public int? domesticReductions { get; set; }
        public int? returnsReductions { get; set; }
        public int? destroyedReductions { get; set; }
        public int? lostReductions { get; set; }
        public int? otherReductions { get; set; }
        public double closingValue { get; set; }
        public double closingWeight { get; set; }
        // only used for seeds
        public int? totalSeeds { get; set; }
    }
}
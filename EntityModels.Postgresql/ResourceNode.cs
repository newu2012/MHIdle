namespace EntityModels.Postgresql;

public partial class ResourceNode : TerritoryEvent
{
    //  Resources and other types of items that can be found in this node through <item-id>
    public ICollection<ObjectWithProportion<int>> ResourceNodeItemsWithProportions { get; set; }
}
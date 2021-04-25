namespace Company.Project.Features.Items
{
    public interface IItem
    {
        int Id { get; }
        ItemInfo Info { get; }
    }

    public struct ItemInfo
    {
        public string Title { get; set; }
    }
}
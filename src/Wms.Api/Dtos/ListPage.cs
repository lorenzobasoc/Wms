namespace Wms.Api.Dtos;

public class ListPage<T>
{
    public List<T> Items { get; set; }
    public int Page { get; set; }
    public int PageCount { get; set; }
    public bool HasNext { get; set; }
    public bool HasPrevious { get; set; }
}

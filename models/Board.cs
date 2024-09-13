
using System.Text;

///
///Board: Each board should have a id, name, privacy (PUBLIC/PRIVATE), url, members, lists
///
public class Board
{
    public string Id { get; set; }

    public string Name { get; set; }

    public Privacy Privacy { get; set; } = Privacy.PUBLIC;

    public string Url { get; set; }

    public List<User> Members { get; set; } = new();

    public override string ToString()
    {
        string result = $"(id:{this.Id}, name:{this.Name}, url:{this.Url}, members:[{string.Join(", ", this.Members.Select(m => m.ToString()))}])";

        return result;
    }


}
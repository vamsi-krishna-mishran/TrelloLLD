

public class User
{

    public string Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public override string ToString()
    {
        return $"(id:{Id},name:{Name},email:{Email})\n";
    }

}
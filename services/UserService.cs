

public class UserService : BaseService
{

    public User AddUser(User user)
    {
        _repo.Users.Add(user.Id, user);
        return user;

    }
    public User? GetUser(string userId){
        return _repo.Users.Values.Where(user=>user.Id == userId).FirstOrDefault();

    }
}


public class UserService : BaseService
{

    public User AddUser(User user)
    {
        _repo.Users.Add(user.Id, user);
        return user;

    }
}
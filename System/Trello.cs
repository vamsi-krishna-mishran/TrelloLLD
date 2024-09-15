

using System.Security.Cryptography.X509Certificates;

public class Trello
{

    private static Trello _instance;
    public static Trello GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Trello();
        }
        return _instance;
    }


    private readonly BoardService _boardService;

    private readonly CardService _cardService;

    private readonly IdGeneratorService _idGeneratorService;

    private readonly ListService _listService;
    private readonly UserService _userService;

    private readonly LoggerService _loggerService;


    private Trello()
    {
        _boardService = new BoardService();
        _cardService = new CardService();
        _listService = new ListService();
        _idGeneratorService = new IdGeneratorService();
        _userService = new UserService();
        _loggerService = new LoggerService();

    }





    public Board CreateBoard(string boardName)
    {

        Board board = new Board();
        board.Name = boardName;
        board.Id = _idGeneratorService.GenerateId();
        board.Url = $"http://trello.com/board/{board.Id}";
        var result = _boardService.AddBoard(board);
        return result;
    }
    public Board RemoveBoard(string boardId)
    {
        Board board=_boardService.GetBoard(boardId);
        if(board == null){
            _loggerService.Warning($"The board with  id {boardId} is not found.");
            return null;
        }
        Board result = _boardService.RemoveBoard(board);
        return result;

    }
    public Board AddMember(string boardId, string userId)
    {
        Board board=_boardService.GetBoard(boardId);
        User user=_userService.GetUser(userId);
        if(board is null){
            _loggerService.Error($"Board with Id {boardId} is not present.");
            return null;
        }
        if(user is null){
            _loggerService.Error($"user with id {userId} is not present. ");
            return null;
        }
        Board result = _boardService.AddMember(board, user);
        return result;
    }

    public Board RemoveMember(string boardId, string userId)
    {
        Board board=_boardService.GetBoard(boardId);
        User user=_userService.GetUser(userId);
        if(board is null){
            _loggerService.Error($"Unable to find board with id {boardId}");
            return null;
        }
        if(user is null){
            _loggerService.Error($"Unable to find user with id {userId}");
            return null;
        }
        Board result = _boardService.RemoveMember(board, user);
        return result;

    }
    public Board UpdateBoardName(string boardId,string name){
        Board board=_boardService.GetBoard(boardId);
        if(board is null){
            _loggerService.Error($"Board with id {boardId} not present.");
        }
        board.Name = name;
        board=_boardService.UpdateBoard(board);
        return board;
    }
    public Board UpdateBoardPrivary(string boardId,Privacy privacy){
        Board board=_boardService.GetBoard(boardId);
        if(board is null){
            _loggerService.Error($"Board with id {boardId} is not found");
            return null;
        }
        else{
            board.Privacy=privacy;
            board=_boardService.UpdateBoard(board);
            return board;
        }
    }
    public string ShowBoard(string boardId){
        Board board=_boardService.GetBoard(boardId);
        if(board is null){
            _loggerService.Error($"Board with id {boardId} is not present.");
            return null;
        }
        return board.ToString();
        
    }

    public User AddUser(string name, string email)
    {
        User user = new User();
        user.Id = _idGeneratorService.GenerateId();
        user.Email = email;
        user.Name = name;
        User result = _userService.AddUser(user);
        return result;
    }


    public BoardList CreateList(string boardId, string Name)
    {
        Board board = _boardService.GetBoard(boardId);
        if (board is null)
        {
            _loggerService.Error($"board id {boardId} is not present.");
            return null;
        }
        BoardList boardList = new BoardList();
        boardList.Name = Name;
        boardList.Board = board;
    
        BoardList result = _listService.AddList(boardList);
        return result;
    }
    public BoardList RemoveList(string listId){
        BoardList list=_listService.GetBoardList(listId);
        if(list is null){
            _loggerService.Error($" List with id {listId} is not present.");
        }
        return _listService.RemoveList(list);
    }
    public BoardList UpdateListName(string listId,string name){
        BoardList list=_listService.GetBoardList(listId);
        if(list is null){
            _loggerService.Error($" board list with id {listId} is not present.");
            return null;
        }
        list.Name=name;
        return _listService.UpdateBoardList(list);
    }
    public string ShowBoardList(string listId){
        BoardList boardList=_listService.GetBoardList(listId);
        if(boardList is null){
            _loggerService.Error($"Board list with id {listId} is not present.");
            return null;
        }
        return boardList.ToString();
    }
    
    
    public Card CreateCard(string listId,string name, string description,User assigneduser){
        BoardList boardList=_listService.GetBoardList(listId);
        if(boardList is null){
            _loggerService.Error($"Given board list id {listId} is not present.");
            return null;

        }
        Card card=new Card();
        card.Id=_idGeneratorService.GenerateId();
        card.Name=name;
        card.BoardList=boardList;
        card.AssignedUser=assigneduser;
        card.Description=description;
        card=_cardService.AddCard(card);
        return card;

    }
    public Card DeleteCard(string cardId){
        Card card=_cardService.GetCard(cardId);
        if(card is null){
            _loggerService.Error($"Card with given id {cardId} not present.");
            return null;
        }
        return card;
    }
    public Card UpdateCardName(string cardId,string name){
        Card card=_cardService.GetCard(cardId);
        if(card is null){
            _loggerService.Error($"card with {cardId} is not present");
            return null;
        }
        card.Name=name;
        card=_cardService.UpdateCard(card);
        return card;
    }
    public Card UpdateCardDescription(string cardId,string description){
        Card card=_cardService.GetCard(cardId);
        if(card is null){
            _loggerService.Error($"card with {cardId} is not present");
            return null;
        }
        card.Description=description;
        card=_cardService.UpdateCard(card);
        return card;
    }
    public Card UpdateAssignedUser(string cardId,string userId){
        Card card=_cardService.GetCard(cardId);
        User user=_userService.GetUser(userId);
        if(user is null){
            _loggerService.Error($"user with is {userId} not found");
            return null;
        }
        if(card is null){
            _loggerService.Error($"card with {cardId} is not present");
            return null;
        }
        card.AssignedUser=user;
        card=_cardService.UpdateCard(card);
        return card;
    }
    public string ShowCard(string id){
        Card? card=_cardService.GetCard(id);
        if(card is null){
            _loggerService.Warning($"Card with id {id} is not present.");
            return null;
        }
        else{
            return card.ToString();
        }
    }
}
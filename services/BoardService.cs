

using System.Collections.Concurrent;

public class BoardService : BaseService
{

    public Board? AddBoard(Board board)
    {

        try
        {
            _repo.Boards.Add(board.Id, board);
            return board;
        }
        catch (Exception)
        {
            return null;
        }
    }
    public Board? RemoveBoard(Board board)
    {
        try
        {
            foreach (var listBoard in _repo.Lists.Values)
            {
                if (listBoard.Board.Id != board.Id)
                {
                    continue;
                }
                foreach (var card in _repo.Cards.Values)
                {
                    if (card.BoardList.Id == listBoard.Id)
                        _repo.Cards.Remove(card.Id);
                }

                _repo.Lists.Remove(listBoard.Id);
            }
            _repo.Boards.Remove(board.Id);
            return board;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public Board? UpdateBoard(Board board)
    {
        try
        {
            _repo.Boards[board.Id] = board;
            return board;
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public Board? AddMember(Board board, User user)
    {
        try
        {
            _repo.Boards[board.Id].Members.Add(user);
            return _repo.Boards[board.Id];
        }
        catch (Exception e)
        {
            return null;
        }
    }
    public Board? RemoveMember(Board board, User user)
    {
        try
        {
            _repo.Boards[board.Id].Members.Remove(user);
            return _repo.Boards[board.Id];
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public Board? GetBoard(string boardId)
    {
        return _repo.Boards.Values.Where(board => board.Id == boardId).FirstOrDefault();
    }
}
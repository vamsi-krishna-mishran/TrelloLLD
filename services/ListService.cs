


public class ListService : BaseService
{

    public BoardList? AddList(BoardList list)
    {

        try
        {
            _repo.Lists.Add(list.Id, list);
            return list;
        }
        catch (Exception)
        {
            return null;
        }
    }
    public BoardList? RemoveList(BoardList list)
    {
        try
        {
            _repo.Lists.Remove(list.Id);
            foreach (Card card in _repo.Cards.Values)
            {
                if (card.BoardList.Id == list.Id)
                {
                    _repo.Cards.Remove(card.Id);
                }
            }
            return list;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public BoardList? UpdateBoard(BoardList list)
    {
        try
        {
            _repo.Lists[list.Id] = list;
            return list;
        }
        catch (Exception e)
        {
            return null;
        }
    }



}
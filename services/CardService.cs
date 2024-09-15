




public class CardService : BaseService
{

    public Card? AddCard(Card Card)
    {

        try
        {
            _repo.Cards.Add(Card.Id, Card);
            return Card;
        }
        catch (Exception)
        {
            return null;
        }
    }
    public Card? RemoveCard(Card Card)
    {
        try
        {
            _repo.Cards.Remove(Card.Id);
            return Card;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public Card? GetCard(string cardId){
        return  _repo.Cards.Values.Where(card=>card.Id == cardId).FirstOrDefault();
    }
    public Card? UpdateCard(Card Card)
    {
        try
        {
            _repo.Cards[Card.Id] = Card;
            return Card;
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public Card? AssignUser(Card card, User user)
    {
        _repo.Cards[card.Id].AssignedUser = user;
        return _repo.Cards[card.Id];
    }

    public Card? MoveCard(Card card, BoardList list)
    {
        card.BoardList = list;
        return card;
    }

    public string ShowCard(Card card)
    {
        return card.ToString();
    }

}
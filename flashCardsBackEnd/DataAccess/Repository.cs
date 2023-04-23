using DataAccess.Entities;

namespace DataAccess;
public class Repository
{
    private readonly FlashcardDbContext _context;
    public Repository(FlashcardDbContext context)
    {
        _context = context;
    }
    public List<Cardset> GetAllFlashCards()
    {
        return _context.Cardsets.ToList();
    }
    public Cardset GetFlashCardById(int id)
    {
        return _context.Cardsets.FirstOrDefault(w => w.Id == id);
    }
    public Cardset CreateFlashCard(Cardset flashCardToCreate)
    {
        Cardset newFlashCard = new Cardset
        {
            Front = flashCardToCreate.Front,
            Back = flashCardToCreate.Back
        };

        _context.Add(newFlashCard);
        _context.SaveChanges();

        flashCardToCreate.Id = newFlashCard.Id;

        return flashCardToCreate;
    }
    public Cardset UpdateFlashCard(Cardset flashCardToUpdate)
    {
        Cardset updatedFlashCard = new Cardset
        {
            Id = flashCardToUpdate.Id,
            Front = flashCardToUpdate.Front,
            Back = flashCardToUpdate.Back
        };

        _context.Update(updatedFlashCard);
        _context.SaveChanges();

        return flashCardToUpdate;
    }

    public Cardset DeleteFlashCard(int id)
    {
        Cardset removeCard = GetFlashCardById(id);
        _context.Cardsets.Remove(removeCard);
        _context.SaveChanges();

        return removeCard;
    }
}
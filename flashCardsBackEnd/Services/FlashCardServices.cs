using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Services;

public class FlashCardServices
{
    private readonly FlashcardDBConext _context;

    public FlashCardServices(FlashcardDbContext context)
    {
        this._context = context;
    }

    public Cardset AddFlashCard(Cardset flashCard)
    {
        _context.Cardsets.Add(flashCard);

        _context.SaveChanges();

        return flashCard;
    }

    public Cardset updateFlashCard(Cardset flashCard)
    {
        _context.Cardsets.Update(flashCard);
        return flashCard;
    }

    public Cardset deleteFlashCard(Cardset flashCard)
    {
        _context.Cardsets.Remove(flashCard);

        _context.SaveChanges();

        return flashCard;
    }

    public List<Cardset> getAllFlashCards()
    {
        return _context.Cardsets.ToList();
    }

    public Cardset getFlashCardById(int Id)
    {
        return _context.Cardsets.Where(flashCard => flashCard.Id == Id);
    }


}

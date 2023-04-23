using Microsoft.AspNetCore.Mvc;
using DataAccess.Entities;
using DataAccess;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlashCardController : ControllerBase
    {
        private readonly Repository _repo;
        public FlashCardController(Repository repo)
        {
            _repo = repo;
        }
        [HttpGet("all")]
        public List<Cardset> GetAll()
        {
            return _repo.GetAllFlashCards();
        }
        [HttpGet("by id")]
        public Cardset GetById(int id)
        {
            return _repo.GetFlashCardById(id);
        }
        [HttpPost]
        public Cardset Post([FromBody] Cardset flashCard)
        {
            Cardset addedCard = _repo.CreateFlashCard(flashCard);
            List<Cardset> allCards = new();

            return addedCard;
        }
        [HttpPut]
        public Cardset Put([FromBody] Cardset flashCard)
        {
            Cardset updatedCard = _repo.UpdateFlashCard(flashCard);
            List<Cardset> allCards = new();

            return updatedCard;
        }
        [HttpDelete]
        public Cardset Delete(int id)
        {
            return _repo.DeleteFlashCard(id);
        }
    }
}
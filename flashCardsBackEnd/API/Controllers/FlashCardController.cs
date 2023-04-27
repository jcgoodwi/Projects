using Microsoft.AspNetCore.Mvc;
using DataAccess.Entities;
using DataAccess;

namespace API.Controllers
{
    [ApiController]
//     [Route("[controller]")]
    public class FlashCardController : ControllerBase
    {
        private readonly Repository _repo;
        public FlashCardController(Repository repo)
        {
            _repo = repo;
        }
        [HttpGet("all")]
        [Route("cards")]
        public List<Cardset> GetAll()
        {
            return _repo.GetAllFlashCards();
        }
        [HttpGet("by id")]
        [Route("card/byId/{id}")]
        public Cardset GetById(int id)
        {
            return _repo.GetFlashCardById(id);
        }
        [HttpPost]
        [Route("card/create")]
        public Cardset Post([FromBody] Cardset flashCard)
        {
            Cardset addedCard = _repo.CreateFlashCard(flashCard);
            List<Cardset> allCards = new();

            return addedCard;
        }
        [HttpPut]
        [Route("card/update")]
        public Cardset Put([FromBody] Cardset flashCard)
        {
            Cardset updatedCard = _repo.UpdateFlashCard(flashCard);
            List<Cardset> allCards = new();

            return updatedCard;
        }
        [HttpDelete]
        [Route("card/delete/{id:int}")]
        public Cardset Delete(int id)
        {
            return _repo.DeleteFlashCard(id);
        }
    }
}

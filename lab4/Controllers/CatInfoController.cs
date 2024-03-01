using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using lab4.Model;

namespace lab4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatInfoController : ControllerBase
    {
        private static List<CatModel> catInfo = new List<CatModel>();

        [HttpPost]
        public IActionResult PostCat(string id, string name, int age)
        {
            if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(name) && age > 0)
            {
                CatModel cat = new CatModel
                {
                    IdCat = id,
                    NameCat = name,
                    AgeCat = age
                };
                catInfo.Add(cat);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult GetCat(string id)
        {
            var cat = catInfo.Find(c => c.IdCat == id);
            if (cat != null)
            {
                return Ok(cat);
            }
            return NotFound();
        }
        [HttpPut("{id}")]
        public IActionResult PutCat(string id, string name, int age)
        {
            var catToUpdate = catInfo.FirstOrDefault(c => c.IdCat == id);
            if (catToUpdate == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(name))
            {
                catToUpdate.NameCat = name;
            }

            if (age > 0)
            {
                catToUpdate.AgeCat = age;
            }

            return Ok(catToUpdate);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCat(string id)
        {
            var catToDelete = catInfo.FirstOrDefault(c => c.IdCat == id);
            if (catToDelete == null)
            {
                return NotFound();
            }

            catInfo.Remove(catToDelete);
            return NoContent(); // Обычно возвращается NoContent (код 204) для успешного удаления
        }

    }
}

using crud_api.Data;
using crud_api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace crud_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        //first create the constructor and accept the value of Data/PersonApiDbContext
        private readonly PersonApiDbContext dbContext;
        public PersonController(PersonApiDbContext dbContext)
        {
            this.dbContext = dbContext;
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPerson()
        {
            return Ok(await dbContext.tbl_Person.ToListAsync());
            //return View();
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetSinglePerson([FromRoute] Guid id)
        {
           var specific_Person = await dbContext.tbl_Person.FindAsync(id);
            if (specific_Person != null)
            {
                return Ok(specific_Person);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddPerson(AddPersonRequest addPersonRequest)
        {
            var Person = new Person
            {
                person_Id = Guid.NewGuid(),
                person_Name = addPersonRequest.person_Name,
                person_Email = addPersonRequest.person_Email,
                person_Address = addPersonRequest.person_Address,
                person_Phone = addPersonRequest.person_Phone
            };
           await dbContext.tbl_Person.AddAsync(Person);
           await dbContext.SaveChangesAsync();
           return Ok(Person);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id,UpdatePersonRequest updatePersonRequest )
        {
           var specific_Person= await dbContext.tbl_Person.FindAsync(id);
            if(specific_Person!=null)
            {

                specific_Person.person_Name = updatePersonRequest.person_Name;
                specific_Person.person_Email = updatePersonRequest.person_Email;
                specific_Person.person_Phone = updatePersonRequest.person_Phone;
                specific_Person.person_Address = updatePersonRequest.person_Address;
            
                await dbContext.SaveChangesAsync();
                return Ok("Updated Successfully");

            }
            else
            {
                return NotFound();
               // return Ok("Person dosen't exists in database");
            }                    
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeletePerson([FromRoute] Guid id)
        {
            var specific_Person = await dbContext.tbl_Person.FindAsync(id);
            if(specific_Person!=null)
            {
                dbContext.Remove(specific_Person);
                await dbContext.SaveChangesAsync();
                // return Ok("Person" + specific_Person.person_Name + "deleted successfully");
                return Ok("Person deleted successfully");
            }
            return NotFound();
        }

        
    }
}

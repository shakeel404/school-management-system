using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartLearning.Data.Repository.IServices;
using SmartLearning.Shared.Models;
using SmartLearning.Shared.Utility;
using Microsoft.AspNetCore.Hosting;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;
using SixLabors.ImageSharp.Formats.Jpeg;
using System.IO;

namespace SmartLearning.Server.Controllers.School
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository Repository;
        private readonly IWebHostEnvironment Envornment;

        public StudentController(IStudentRepository repository, IWebHostEnvironment env)
        {
            Repository = repository;

            Envornment = env;
        }
        [HttpGet("{page}/{size}/{filter?}")]
        public PaginationModel<Student> Get(int page, int size, string filter)
        {
            page = page == 0 ? 1 : page;
            size = size < 10 ? 10 : size;


            var items = Repository.Get()
                                  .OrderByDescending(s => s.LastUpdate)
                                  .AsQueryable();
            var count = 0;

            if (!string.IsNullOrWhiteSpace(filter))
            {
                filter = filter.ToLower();
                Expression<Func<Student, bool>> criteria = s => s.FirstName.ToLower().Contains(filter)
                   || s.LastName.ToLower().Contains(filter)
                   || s.Gender.ToLower().Contains(filter)
                   || s.Nationality.ToLower().Contains(filter)
                   || s.Religion.ToLower().Contains(filter);

                count = items.Where(criteria).Count();
                items = items.Where(criteria).Skip(size * (page - 1)).Take(size);

            }
            else
            {
                count = items.Count();
                items = items.Skip(size * (page - 1)).Take(size);
            }
            var model = new PaginationModel<Student>();
            model.Filter = filter;
            model.Page = page;
            model.Size = size;
            model.Count = count;
            model.Items = items;
            return model;
        }


        [HttpGet("{id}")]
        public Student Get(string id)
        {
            return Repository.Get(id);
        }


        [HttpPost]
        public void Post([FromBody] Student model)
        {
            model.ImageUrl = "Images/Default.jpg";
            if (ModelState.IsValid)
            {
                Repository.Add(model);
                Repository.Save();

            }
        }


        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Student model)
        {
            if (!ModelState.IsValid)
                return;

            var studentInDb = Repository.Get(id);

            if (studentInDb == null)
                return;

            studentInDb.FirstName = model.FirstName;
            studentInDb.LastName = model.LastName;
            studentInDb.DateOfBirth = model.DateOfBirth;
            studentInDb.Gender = model.Gender;
            studentInDb.Nationality = model.Nationality;
            studentInDb.Religion = model.Religion;

            Repository.Save();
        }


        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var studentInDb = Repository.Get(id);

            if (studentInDb != null)
            {
                Repository.Remove(studentInDb);
                Repository.Save();
            }
        }

        [HttpPost("uploadimage/{id}/{x}/{y}")] 
        public async Task<string> UploadImage(string id,int x,int y,IFormFile file)
        {
            var student = Repository.Get(id);
            var filename = $"{student.FirstName}{student.LastName}_{Guid.NewGuid().ToString()}.jpg";

            var path =$"{Envornment.WebRootPath}\\Images\\{filename}";
            var existFilePath = $"{Envornment.WebRootPath}\\{student.ImageUrl?.Replace('/','\\')}";

            if(!existFilePath.EndsWith("Default.jpg"))
            if (System.IO.File.Exists(existFilePath))
                System.IO.File.Delete(existFilePath);

                using (var image = Image.Load(file.OpenReadStream()))
                {
                image.Mutate(img => img
                 .Resize(400, 400)
                 .Crop(new Rectangle(x,y,300,300)));
                    image.Save(path, new JpegEncoder()); 
                
                }

            student.ImageUrl = $"Images/{filename}";
            Repository.Save();
            await Task.CompletedTask;
            return student.ImageUrl;
        }


        [HttpGet("imageurl/{id}")]
        public string ImageUrl(string id)
        {
            var student = Repository.Get(id);

            return student.ImageUrl;
        }
    }
}

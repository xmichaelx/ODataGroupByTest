using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using OData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OData.Controllers
{
    [EnableQuery]
    public class FileController : ODataController
    {
        private FileContext _db;

        public FileController(FileContext context)
        {
            _db = context;
            _db.Database.EnsureCreated();
            if (!_db.Files.Any())
            {
                _db.Files.AddRange(
                    new File { FileType = 1 },
                    new File { FileType = 1 },
                    new File { FileType = 2 },
                    new File { FileType = 2 }
                );
                _db.SaveChanges();
            }
        }

        public IActionResult Get()
        {
            return Ok(_db.Files.AsQueryable());
        }

        public IActionResult Get(int key)
        {
            return Ok(_db.Files.FirstOrDefault(c => c.Id == key));
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tpModul10_103022300049;

namespace tpModul10_103022300001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class mahasiswaController : ControllerBase
    {
        private static List<Mahasiswa> mahasiswaList = new List<Mahasiswa>
        {
            new Mahasiswa { Nama = "Shinta Alya Aulya Ningrum", Nim = "103022300049" },
            new Mahasiswa { Nama = "Riyanda Wiesya Bela", Nim = "103022300001" },
            new Mahasiswa { Nama = "Sheila Nabilla Chantika Yudho", Nim = "103022300099"},
            new Mahasiswa { Nama = "Alya Rahmadayani Supriadi", Nim = "103022300160"}
        };

        [HttpGet]
        public ActionResult<IEnumerable<Mahasiswa>> Get()
        {
            return mahasiswaList;
        }

        [HttpPost]
        public ActionResult<IEnumerable<Mahasiswa>> Post([FromBody] Mahasiswa mahasiswa)
        {
            mahasiswaList.Add(mahasiswa);
            return mahasiswaList;
        }

        [HttpGet("{nim}")]
        public ActionResult<Mahasiswa> GetByIndex(string nim)
        {
            var mahasiswa = mahasiswaList.FirstOrDefault(m => m.Nim == nim);
            if (mahasiswa == null)
            {
                return NotFound();
            }
            return mahasiswa;
        }

        [HttpDelete("{index}")]
        public ActionResult<IEnumerable<Mahasiswa>> Delete(int index)
        {
            if (index < 0 || index >= mahasiswaList.Count)
            {
                return NotFound();
            }

            mahasiswaList.RemoveAt(index);
            return mahasiswaList;
        }
    }
}
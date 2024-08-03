using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Nombre_usuario { get; set; }
        public string Contraseña { get; set; }
        public int PersonId { get; set; }
        public Person person { get; set; }
        public Boolean State { get; set; }

    }
}

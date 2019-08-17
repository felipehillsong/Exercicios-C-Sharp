using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDProjeto
{
    class Program
    {
        static void Main(string[] args)
        {
            var bd = new BD();            
            var usuarioAplicacao = new UsuarioAplicacao();

            Console.WriteLine("Digite o nome do usuario: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o cargo do usuario: ");
            string cargo = Console.ReadLine();

            Console.WriteLine("Digite a data de registro do usuario: ");
            string data = Console.ReadLine();

            var usuarios = new Usuarios()
            {
                Nome = nome,
                Cargo = cargo,
                Data = DateTime.Parse(data)
            };

            usuarioAplicacao.Salvar(usuarios);

            usuarios.Id = 3;
            usuarioAplicacao.Salvar(usuarios);

            //usuarioAplicacao.Delete(3);

            var select = usuarioAplicacao.Select();

            foreach (var usuario in select)
            {
                Console.WriteLine("Id:{0}, Nome:{1}, Cargo:{2}, Data{3}", usuario.Id, usuario.Nome, usuario.Cargo, usuario.Data);
            }
        }        
    }
}

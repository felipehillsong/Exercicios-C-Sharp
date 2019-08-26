using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB_EF.Conexao
{
    //Aonde T herda de qualquer classe, mas funciona em o where T:class também
    public interface IRepositorio<T> where T : class
    {
        //Os metodos recebem uma classse e um objeto
        void Salvar(T entidade);

        void Delete(T entidade);

        IEnumerable<T> Select();

        T SelectById(int id);
    }
}
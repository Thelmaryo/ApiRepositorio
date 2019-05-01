using Dapper;
using System;
using System.Collections.Generic;

namespace PadraoRepositorio
{
    public interface IPessoaRepositorio
    {
        void Cadastrar(Pessoa pessoa);
        void Atualizar(Pessoa pessoa);
        void Excluir(int id);
        IEnumerable<Pessoa> Listar();
        IEnumerable<Pessoa> Filtrar(DataTable datatable);
        Pessoa BuscarPorId(int id);
    }

    public class PessoaRepositorio : IPessoaRepositorio
    {
        private readonly IDB _db;

        public PessoaRepositorio(IDB db)
        {
            _db = db;
        }

        public void Atualizar(Pessoa pessoa)
        {
            using (var db = _db.GetConnection())
            {
                db.Execute("UPDATE Pessoa SET Nome = @Nome, CPF = @CPF, Telefone = @Telefone WHERE Id = @Id", pessoa);
            }
        }

        public Pessoa BuscarPorId(int id)
        {
            using (var db = _db.GetConnection())
            {
                return db.QuerySingleOrDefault<Pessoa>("SELECT * FROM Pessoa WHERE Id = @id", new { id });
            }
        }

        public void Cadastrar(Pessoa pessoa)
        {
            using (var db = _db.GetConnection())
            {
                db.Execute("INSERT INTO Pessoa (Nome, CPF, Telefone) VALUES (@Nome, @CPF, @Telefone)", pessoa);
            }
        }

        public void Excluir(int id)
        {
            using (var db = _db.GetConnection())
            {
                db.Execute("DELETE FROM Pessoa WHERE Id = @id", new { id });
            }
        }

        public IEnumerable<Pessoa> Filtrar(DataTable datatable)
        {
            using (var db = _db.GetConnection())
            {
                string sql = "SELECT * FROM Pessoa";
                if (!string.IsNullOrEmpty(datatable.search.value))
                    sql += " WHERE Nome LIKE CONCAT('%',@Search,'%') OR  Telefone LIKE CONCAT('%',@Search,'%') OR CPF LIKE CONCAT('%',@Search,'%')";
                sql += $" ORDER BY {datatable.columns[datatable.order[0].column].name} {datatable.order[0].dir}";
                if (datatable.start > 0)
                    sql += $" OFFSET {datatable.start} ROWS FETCH NEXT {datatable.length} ROWS ONLY";
                return db.Query<Pessoa>(sql,
                    new {
                        Search = datatable.search.value
                    });
            }
        }

        public IEnumerable<Pessoa> Listar()
        {
            using (var db = _db.GetConnection())
            {
                return db.Query<Pessoa>("SELECT * FROM Pessoa");
            }
        }
    }
}

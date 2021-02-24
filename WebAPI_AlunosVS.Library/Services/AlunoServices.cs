using System.Data;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using WebAPI_AlunosVS.Library.Entities;
using WebAPI_AlunosVS.Library.Services.Interfaces;
using WebAPI_AlunosVS.Library.Repositories.Interfaces;

namespace WebAPI_AlunosVS.Library.Services
{
    public class AlunoServices : IAlunoServices
    {
        private readonly IAlunoRepository _IAlunoRepository;

        public AlunoServices(){}

        public AlunoServices(IAlunoRepository IAlunoRepository)
        {
            _IAlunoRepository=IAlunoRepository;
        }

        /// <summary>
        /// Metodo para insert Aluno
        /// </summary>
        /// <param name="aluno"></param>
        /// <returns></returns>
        public int InsertAluno(Aluno aluno)
        {
            var result = _IAlunoRepository.InsertAluno(aluno);

            return result;
        }

        /// <summary>
        /// Metodo para deletar o Aluno de acordo com id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteAluno(int id)
        {
            var result = _IAlunoRepository.DeleteAluno(id);
            return result;
        }

        /// <summary>
        /// Metodo para retorna  todos Alunos
        /// </summary>
        /// <returns></returns>
        public List<Aluno> GetAlunos()
        {
            var result = _IAlunoRepository.GetAlunos();
            return result;
        }

        /// <summary>
        /// Metodo para retorna um Aluno de acordo com id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Aluno GetByIdAluno(int id)
        {
            var result = _IAlunoRepository.GetByIdAluno(id);

            return result;
        }

        /// <summary>
        /// Metodo para atualizar o Aluno
        /// </summary>
        /// <param name="aluno"></param>
        /// <returns></returns>
        public int UpdateAluno(Aluno aluno)
        {
            var result =_IAlunoRepository.UpdateAluno(aluno);

            return result;
        }       
    }
}
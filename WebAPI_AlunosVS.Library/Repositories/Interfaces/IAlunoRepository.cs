using System;
using System.Collections.Generic;
using WebAPI_AlunosVS.Library.Entities;

namespace WebAPI_AlunosVS.Library.Repositories.Interfaces
{
    public interface IAlunoRepository
    {
        int InsertAluno(Aluno aluno);
        List<Aluno> GetAlunos();
        Aluno GetByIdAluno(int id);
        int UpdateAluno(Aluno aluno);
        int DeleteAluno(int id); 
    }
}
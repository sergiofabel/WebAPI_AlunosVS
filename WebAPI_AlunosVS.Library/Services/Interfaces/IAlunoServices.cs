using System;
using System.Collections.Generic;
using WebAPI_AlunosVS.Library.Entities;

namespace WebAPI_AlunosVS.Library.Services.Interfaces
{
    public interface IAlunoServices
    {
        int InsertAluno(Aluno aluno);
        List<Aluno> GetAlunos();
        Aluno GetByIdAluno(int id);
        int UpdateAluno(Aluno item);
        int DeleteAluno(int id);
    }
}
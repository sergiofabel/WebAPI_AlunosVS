CREATE TABLE dbo.Aluno
(
	AlunoId INT NOT NULL IDENTITY(1,1),
	Nome VARCHAR(100),
	Email VARCHAR(100),
	CONSTRAINT PK_Aluno PRIMARY KEY(AlunoId)
)

INSERT INTO dbo.Aluno (Nome,Email) VALUES('SergioFabel','SergioFabel@Gmail.com')

SELECT * FROM dbo.Aluno

CREATE TABLE historico_ativos (
    ativo_id INT PRIMARY KEY IDENTITY (1, 1),
    nome_ativo VARCHAR (50) NOT NULL,
    data_ativo DATE,
    valor_ativo DECIMAL(5,2)  
);
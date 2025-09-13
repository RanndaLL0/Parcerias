CREATE TABLE IF NOT EXISTS Usuario(
    id BIGSERIAL PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    password VARCHAR(255) NOT NULL, -- senha criptografada (não única)
    email VARCHAR(100) UNIQUE NOT NULL,
    role VARCHAR(30) NOT NULL,
    contato VARCHAR(30) NOT NULL
);

CREATE TABLE IF NOT EXISTS Parceiro(
    id BIGSERIAL PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    area VARCHAR(50) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL
);

CREATE TABLE IF NOT EXISTS Parceria(
    id BIGSERIAL PRIMARY KEY,
    objective TEXT NOT NULL,
    start_date DATE NOT NULL,
    end_date DATE,
    id_parceiro BIGINT NOT NULL,
    FOREIGN KEY (id_parceiro) REFERENCES Parceiro(id)
);

CREATE TABLE IF NOT EXISTS Usuario_parceria(
    id BIGSERIAL PRIMARY KEY,
    id_usuario BIGINT NOT NULL,
    id_parceria BIGINT NOT NULL,
    tipo VARCHAR(50) NOT NULL,
    status VARCHAR(50) NOT NULL,
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id),
    FOREIGN KEY (id_parceria) REFERENCES Parceria(id)
);

CREATE TABLE IF NOT EXISTS Ativacao(
    id BIGSERIAL PRIMARY KEY,
    area VARCHAR(50) NOT NULL,
    description TEXT NOT NULL,
    id_parceria BIGINT NOT NULL,
    responsavel BIGINT NOT NULL,
    FOREIGN KEY (responsavel) REFERENCES Usuario(id),
    FOREIGN KEY (id_parceria) REFERENCES Parceria(id)
);

CREATE TABLE IF NOT EXISTS Responsavel(
    id BIGSERIAL PRIMARY KEY,
    id_usuario BIGINT NOT NULL,
    id_parceria BIGINT NOT NULL,
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id),
    FOREIGN KEY (id_parceria) REFERENCES Parceria(id)
);

CREATE TABLE IF NOT EXISTS Contrato(
    id BIGSERIAL PRIMARY KEY,
    sign_date DATE NOT NULL, 
    id_parceria BIGINT NOT NULL,
    FOREIGN KEY (id_parceria) REFERENCES Parceria(id)
);

CREATE TABLE IF NOT EXISTS Anexo(
    id BIGSERIAL PRIMARY KEY,
    start_date DATE NOT NULL,
    end_date DATE NOT NULL,
    description TEXT NOT NULL,
    id_parceria BIGINT NOT NULL,
    FOREIGN KEY (id_parceria) REFERENCES Parceria(id)
);

CREATE TABLE IF NOT EXISTS Cronograma(
    id BIGSERIAL PRIMARY KEY,
    date DATE NOT NULL,
    name VARCHAR(50) NOT NULL,
    description TEXT NOT NULL
);
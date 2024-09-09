# Estoque

Este é um sistema de controle de estoque desenvolvido em C# utilizando o padrão MVC e o Entity Framework Core com SQLite. O sistema permite o gerenciamento de produtos, incluindo as operações de criar, editar e excluir produtos, além de gerar relatórios em PDF.

## Funcionalidades

- Cadastro de produtos com nome, quantidade e ID automático.
- Edição e exclusão de produtos.
- Geração de relatórios em PDF com:
  - Todos os produtos e suas quantidades.
  - Produtos com estoque baixo (≤ 5 unidades).
  - Movimentação de entrada e saída de produtos.
  - Produtos sem movimentação desde a inserção.

## Tecnologias Utilizadas

- **C# e ASP.NET Core MVC**: Padrão de desenvolvimento.
- **Entity Framework Core**: Para comunicação com o banco de dados SQLite.
- **SQLite**: Banco de dados local e leve para armazenamento de informações.
- **iTextSharp**: Para geração de relatórios em formato PDF.
- **.NET 8.0**: Framework para o desenvolvimento da aplicação.
  
## Estrutura do Projeto

- Controllers/: Controladores da aplicação, responsáveis pelas ações de CRUD dos produtos.
- Models/: Contém as classes de modelo do sistema, como Produto e Movimentacao.
- Services/: Serviço para geração de relatórios em PDF.
- Views/: Arquivos das views, responsáveis por renderizar a interface para o usuário.

using System;
using System.Collections.Generic;

namespace Produto.Domain.Entities;

public partial class TB_PRODUTOS
{
    public int ID_PRODUTO { get; set; }

    public string NOME_PRODUTO { get; set; } = null!;

    public string STATUS_PRODUTO { get; set; } = null!;
}

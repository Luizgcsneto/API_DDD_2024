﻿using Entities.EntitiesExternal;

namespace Domain.InterfacesExternal
{
    public interface IProduto
    {
        List<Produto> List();

        Produto Create(Produto produto);
        Produto Update(Produto produto);
        Produto GetOne(int codigo);
        Produto Delete(int codigo);

    }
}

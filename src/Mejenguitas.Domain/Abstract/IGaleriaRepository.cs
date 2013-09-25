﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mejenguitas.Domain.Entities;

namespace Mejenguitas.Domain.Abstract
{
    public interface IGaleriaRepository
    {
        void Guardar(Galeria galeria);
        bool Eliminar(int id);
    }
}

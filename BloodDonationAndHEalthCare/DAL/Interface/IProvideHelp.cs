﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IProvideHelp
    {
        ProvideHelp Create(ProvideHelp obj);
        List<ProvideHelp> Read();
        ProvideHelp Read(int id);
        ProvideHelp Update(ProvideHelp obj);
        bool Delete(int id);
    }
}

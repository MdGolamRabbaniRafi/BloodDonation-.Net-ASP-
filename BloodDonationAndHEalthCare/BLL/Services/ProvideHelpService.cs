using BLL.DTO;
using DAL.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using DAL;

namespace BLL.Services
{
    public class ProvideHelpService
    {
        public static ProvideHelpDTO AddProvideHelp(ProvideHelpDTO provideHelp)
        {
            if (provideHelp == null)
            {
                throw new ArgumentNullException(nameof(provideHelp));
            }

            var data = MapperClass.MapperProvideHelp();
            var mapped = data.Map<ProvideHelp>(provideHelp);
            var provideHelpRepo = DataAccessFactory.ProvideHelpData().Create(mapped);
            var data2 = MapperClass.MapperProvideHelp();
            var mapped2 = data2.Map<ProvideHelpDTO>(provideHelpRepo);

            return mapped2;
        }

        public static ProvideHelpDTO UpdateProvideHelp(int provideHelpId, ProvideHelpDTO provideHelp)
        {
            var data = MapperClass.MapperProvideHelp();
            var existingProvideHelp = DataAccessFactory.ProvideHelpData().Read(provideHelpId);

            if (existingProvideHelp != null)
            {
                existingProvideHelp.Amount = provideHelp.Amount;
                existingProvideHelp.Description = provideHelp.Description;
               

                var updatedProvideHelp = DataAccessFactory.ProvideHelpData().Update(existingProvideHelp);
                var data2 = MapperClass.MapperProvideHelp();
                var mapped2 = data2.Map<ProvideHelpDTO>(updatedProvideHelp);

                return mapped2;
            }
            else
            {
                return null;
            }
        }

        public static ProvideHelpDTO GetProvideHelp(int id)
        {
            var data = MapperClass.MapperProvideHelp();
            var getProvideHelp = DataAccessFactory.ProvideHelpData().Read(id);
            var mapped = data.Map<ProvideHelpDTO>(getProvideHelp);

            return mapped;
        }

        public static List<ProvideHelpDTO> GetAllProvideHelps()
        {
            var data = MapperClass.MapperProvideHelp();
            var allProvideHelps = DataAccessFactory.ProvideHelpData().Read();
            var mappedProvideHelps = data.Map<List<ProvideHelpDTO>>(allProvideHelps);

            return mappedProvideHelps;
        }

        public static bool DeleteProvideHelp(int provideHelpId)
        {
            var getProvideHelp = DataAccessFactory.ProvideHelpData().Read(provideHelpId);

            if (getProvideHelp != null)
            {
                var isDeleted = DataAccessFactory.ProvideHelpData().Delete(provideHelpId);
                return isDeleted;
            }
            else
            {
                return false;
            }
        }
    }
}

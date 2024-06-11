using FridgeBE.Core.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeBE.Infrastructure.Services
{
    public class IngredientService
    {
        private IUnitOfWork _unitOfWork;

        public IngredientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}

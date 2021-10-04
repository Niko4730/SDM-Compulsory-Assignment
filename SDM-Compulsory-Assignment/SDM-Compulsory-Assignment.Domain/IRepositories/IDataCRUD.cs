using System.Collections;
using System.Collections.Generic;
using SDM_Compulsory_Assignment.Core.Models;

namespace SDM_Compulsory_Assignment.Domain.IRepositories
{
    public interface IDataCRUD
    {
        IEnumerable<Review> ReadALl();
    }
}
using CodeChallenge.Models;
using System; 

namespace CodeChallenge.Services;

public interface ICompensationService
{
    Compensation GetById(string id);
    Compensation Create(Compensation compensation);
}

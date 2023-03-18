using System.Collections.Generic;
using System.Security.Cryptography;
using HashApi.Models;

namespace HashApi.Services;
public interface IHashService
{
    IList<HashDTO> GetHashesByDay(int days);
    void GenerateRandomSHA1Hashes(int count);
}
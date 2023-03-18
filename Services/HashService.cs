using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using HashApi.Data.Entities;
using HashApi.Data.Repositories.Hashes;
using HashApi.Models;

namespace HashApi.Services;
public class HashService : IHashService
{
    private readonly IHashRepository _hashRepository;
    private readonly IMessageBrokerProducerService _messageBrokerProducerService;

    public HashService(IHashRepository hashRepository, IMessageBrokerProducerService messageBrokerProducerService)
    {
        _hashRepository = hashRepository;
        _messageBrokerProducerService = messageBrokerProducerService;
    }
    public IList<HashDTO> GetHashesByDay(int days)
    {
        var hashes = _hashRepository.GetByDay(days);

        return hashes.GroupBy(x => x.InsertDate.Date)
                     .Select(g => new HashDTO()
                     {
                         DateTime = g.Key,
                         Count = g.Count(),
                     }).ToList();
    }

    public void GenerateRandomSHA1Hashes(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GenerateAndPublishHash();
        }
    }
    private void GenerateAndPublishHash()
    {
        byte[] randomBytes = new byte[16];

        using (SHA1 sha1 = SHA1.Create())
        {
            byte[] hashBytes = sha1.ComputeHash(randomBytes);

            string hashString = BitConverter.ToString(hashBytes).Replace("-", "");

            var hash = new Hash()
            {
                Sha1 = hashString,
                InsertDate = DateTime.Now,
            };

            _messageBrokerProducerService.PublishMessage(hash);
        }
    }
}
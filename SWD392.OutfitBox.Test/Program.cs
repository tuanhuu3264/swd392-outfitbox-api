using StackExchange.Redis;
using SWD392.OutfitBox.Domain.Entities;
using SWD392.OutfitBox.Infrastructure.Databases.Redis;
using SWD392.OutfitBox.Infrastructure.Streaming.CosumerMessage;
using SWD392.OutfitBox.Infrastructure.Streaming.ProducerMessage;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

var producer = new ProducerMessage();
await producer.ProductMessage("aaaa", new Product() { ID = 1, Name = "aaaaa" });

var cosumer = new CosumerMessage();
await cosumer.ProccessProductMessage();

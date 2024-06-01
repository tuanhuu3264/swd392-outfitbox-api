using StackExchange.Redis;
using SWD392.OutfitBox.Domain.Entities;
using SWD392.OutfitBox.Infrastructure.Databases.Redis;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

ConfigurationOptions options = new ConfigurationOptions
{
    EndPoints = { { "outfit4rent.online", 6379 } }
};

/*options.CertificateSelection += delegate
{
    return new X509Certificate2("redis.pfx", "secret"); // use the password you specified for pfx file
};
options.CertificateValidation += ValidateServerCertificate;

bool ValidateServerCertificate(
        object sender,
        X509Certificate? certificate,
        X509Chain? chain,
        SslPolicyErrors sslPolicyErrors)
{
    if (certificate == null)
    {
        return false;
    }

    var ca = new X509Certificate2("redis_ca.pem");
    bool verdict = (certificate.Issuer == ca.Subject);
    if (verdict)
    {
        return true;
    }
    Console.WriteLine("Certificate error: {0}", sslPolicyErrors);
    return false;
}
*/
ConnectionMultiplexer muxer = ConnectionMultiplexer.Connect(options);

//Creation of the connection to the DB
IDatabase conn = muxer.GetDatabase();

//send SET command
/*conn.StringSet("foo", "bar");*/

//send GET command and print the value


ICacheUnit<Brand> cacheUnit = new CacheUnit<Brand>();
cacheUnit.SetObject(new Brand()
{
    ID = 1,
    Name = "aaaa",
    Link = "aaaa",
    Description = "sss"
}, 2);

cacheUnit.SetObject(new Brand()
{
    ID = 3,
    Name = "bbbbb",
    Link = "aaaa",
    Description = "sss"
}, 3);
var result = await cacheUnit.GetAll();
foreach(Brand brand in result)
    Console.WriteLine(brand.Name+"/n");


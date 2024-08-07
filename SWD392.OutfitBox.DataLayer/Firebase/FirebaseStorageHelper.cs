﻿

using Castle.Core.Configuration;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using Firebase.Storage;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.DataLayer.Firebase
{
    public static class FirebaseStorageHelper
    {
        public static async Task<bool> DeleteFileFromFirebase(
            string pathFileName, 
            string apiKey,
            string domainName,
            string email, 
            string password, 
            string storageBucket
            ,IConfiguration configuration)
        {

            try
            {
          
                var config = new FirebaseAuthConfig
                {
                    ApiKey = apiKey,
                    AuthDomain = domainName,
                    Providers = new FirebaseAuthProvider[]
                    {
                new EmailProvider(),
                new GoogleProvider()
                    }
                };

          
                var authClient = new FirebaseAuthClient(config);

      
                var userCens = await authClient.SignInWithEmailAndPasswordAsync(email, password);

                if (userCens == null) throw new FirebaseAuthException("Can not ss", new AuthErrorReason());

                var storage = new FirebaseStorage(
                    storageBucket,
                    new FirebaseStorageOptions
                    {
                        AuthTokenAsyncFactory = async () =>
                        {
                            var idToken = await userCens.User.GetIdTokenAsync();
                            return idToken;
                        },
                        ThrowOnCancel = true
                    });

                await storage.Child(pathFileName).DeleteAsync();
                return true;
            }
            catch (FirebaseStorageException)
            {
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public static async Task<string> GetUrlImageFromFirebase(string pathFileName, string storageBucket)
        {
            if (string.IsNullOrEmpty(pathFileName))
            {
                return string.Empty;
            }

            var filePath = pathFileName.Split("/o/")[1];
            var api = $"https://firebasestorage.googleapis.com/v0/b/{storageBucket}/o?name={filePath}";

            var client = new RestClient();
            var request = new RestRequest(api, Method.Get);
            var response = await client.ExecuteAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var jmessage = JObject.Parse(response.Content);
                var downloadToken = jmessage["downloadTokens"]?.ToString();

                if (!string.IsNullOrEmpty(downloadToken))
                {
                    return $"https://firebasestorage.googleapis.com/v0/b/{storageBucket}/o/{filePath}?alt=media&token={downloadToken}";
                }
            }

            return string.Empty;
        }

        public static async Task<string> UploadFileToFirebase(IFormFile file, string pathFileName, string apiKey,string domain, string email, string password, string bucketName)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("The file is empty");
            }

            try
            {
                var stream = file.OpenReadStream();
                var config = new FirebaseAuthConfig
                {
                    ApiKey = apiKey,
                    AuthDomain = domain,
                    Providers = new FirebaseAuthProvider[]
                    {
                new EmailProvider(),
                new GoogleProvider()
                    }
                };


                var authClient = new FirebaseAuthClient(config);


                var userCens = await authClient.SignInWithEmailAndPasswordAsync(email, password);

                if (userCens == null) throw new FirebaseAuthException("Can not ss", new AuthErrorReason());

                var storage = new FirebaseStorage(
                    bucketName,
                    new FirebaseStorageOptions
                    {
                        AuthTokenAsyncFactory = async () =>
                        {
                            var idToken = await userCens.User.GetIdTokenAsync();
                            return idToken;
                        },
                        ThrowOnCancel = true
                    });

                var destinationPath = $"{pathFileName}/{file.FileName}";

                var downloadUrl = await storage.Child(destinationPath).PutAsync(stream);
                return downloadUrl;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Upload failed: {ex.Message}", ex);
            }
        }

        public static async Task<List<string>> UploadFilesToFirebase(List<IFormFile> files, string basePath, string apiKey,string domainName, string email, string password, string bucketName)
        {
            var uploadResults = new List<string>();

            try
            {
                var config = new FirebaseAuthConfig
                {
                    ApiKey = apiKey,
                    AuthDomain = domainName,
                    Providers = new FirebaseAuthProvider[]
                     {
                new EmailProvider(),
                new GoogleProvider()
                     }
                };


                var authClient = new FirebaseAuthClient(config);


                var userCens = await authClient.SignInWithEmailAndPasswordAsync(email, password);

                if (userCens == null) throw new FirebaseAuthException("Can not ss", new AuthErrorReason());

                var storage = new FirebaseStorage(
                    bucketName,
                    new FirebaseStorageOptions
                    {
                        AuthTokenAsyncFactory = async () =>
                        {
                            var idToken = await userCens.User.GetIdTokenAsync();
                            return idToken;
                        },
                        ThrowOnCancel = true
                    });

                foreach (var file in files)
                {
                    if (file == null || file.Length == 0)
                    {
                        continue;
                    }

                    var stream = file.OpenReadStream();
                    var destinationPath = $"{basePath}/{file.FileName}";

                    var downloadUrl = await storage.Child(destinationPath).PutAsync(stream);
                    uploadResults.Add(downloadUrl);
                }

                return uploadResults;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Upload failed: {ex.Message}", ex);
            }
        }
    }
}

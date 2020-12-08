﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace UdemyAndroidKotlin.Auth
{
    public static class Config
    {
        public static IEnumerable<ApiResource> apiResources => new ApiResource[]
        {
            new ApiResource("resource_product_api"){
                Scopes={ "api_product_fullpermission" },
                ApiSecrets=new []{new Secret("apisecret".Sha256()) } },

            new ApiResource("resource_photo_api")
            { Scopes={ "api_photo_fullpermission" },
             ApiSecrets=new []{new Secret("photosecret".Sha256()) }
            },
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<ApiScope> ApiScopes =>
           new ApiScope[]
           {
                new ApiScope("api_product_fullpermission","Product API için tüm izinler"),
                new ApiScope("api_photo_fullpermission","Photo API için tüm izinler"),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
           };

        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                       new IdentityResources.Email(),
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                   };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "AndroidClient_CC",
                    ClientName = "AndroidClient CC",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedScopes = {  IdentityServerConstants.LocalApi.ScopeName}
                },

                new Client
                {
                    ClientId = "AndroidClient_ROP",
                          ClientName = "AndroidClient ROP",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowOfflineAccess = true,
                    AllowedScopes = { IdentityServerConstants.StandardScopes.Email,IdentityServerConstants.StandardScopes.OpenId,IdentityServerConstants.StandardScopes.Profile, "api_product_fullpermission","api_photo_fullpermission",IdentityServerConstants.StandardScopes.OfflineAccess },
                    AccessTokenLifetime=1*60*60,
                    RefreshTokenUsage=TokenUsage.ReUse,
                   RefreshTokenExpiration=TokenExpiration.Absolute,
                    AbsoluteRefreshTokenLifetime=(int) (DateTime.Now.AddDays(60)-DateTime.Now).TotalSeconds
                },
            };
    }
}
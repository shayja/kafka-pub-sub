global using Confluent.Kafka;
global using System;
global using System.Net;
global using System.Text.Json;
global using System.Text.Json.Serialization;
global using System.ComponentModel.DataAnnotations;
global using ApacheKafkaProducer.Core.Domain;
global using ApacheKafkaProducer.Core.Extensions;


global using ApacheKafkaProducer.Modules.Orders.Adapters;
global using ApacheKafkaProducer.Modules.Orders.Core.Domain;
global using ApacheKafkaProducer.Modules.Orders.Core.Extensions;
global using ApacheKafkaProducer.Modules.Orders.EndPoints;
global using ApacheKafkaProducer.Modules.Orders.Ports;

global using ApacheKafkaProducer.Modules.Products.Adapters;
global using ApacheKafkaProducer.Modules.Products.Core.Domain;
global using ApacheKafkaProducer.Modules.Products.Core.Extensions;
global using ApacheKafkaProducer.Modules.Products.EndPoints;
global using ApacheKafkaProducer.Modules.Products.Ports;

global using Microsoft.AspNetCore.Http.HttpResults;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Options;
global using Microsoft.OpenApi.Models;

global using MongoDB.Bson;
global using MongoDB.Bson.Serialization.Attributes;
global using MongoDB.Bson.Serialization.Conventions;
global using MongoDB.Driver;








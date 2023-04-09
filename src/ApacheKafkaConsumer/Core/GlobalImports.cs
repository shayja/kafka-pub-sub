global using Confluent.Kafka;
global using System;
global using System.Text.Json;
global using System.Threading;
global using System.Threading.Tasks;
global using ApacheKafkaConsumer.Core.Domain;
global using ApacheKafkaConsumer.Core.Extensions;
global using ApacheKafkaConsumer.Models;
global using ApacheKafkaConsumer.Services;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;



global using MongoDB.Bson;
global using MongoDB.Bson.Serialization.Attributes;
global using MongoDB.Bson.Serialization.Conventions;
global using MongoDB.Driver;
# 🐾 Marten Hands-On: Working with Sessions and Document Storage
This project demonstrates basic usage of Marten (a .NET document database library for PostgreSQL) with different types of sessions.
It covers how to create, store, and retrieve documents using Marten's flexible session management system.

## ✨ Features
Setup of Marten with automatic schema creation using Weasel.Core.

Basic document model: Cat with properties like Id, Name, Breed, and Color.

API endpoints to:

Create and store a new Cat

Retrieve a Cat by its Id

Demonstrates usage of various Marten session types:

IdentityMapSession (default, caches loaded documents)

DirtyTrackingSession (automatically detects modifications)

LightweightSession (no caching, manual control)

QuerySession (read-only, optimized for queries)

## 🛠 Technologies Used
ASP.NET Core Web API

Marten

Weasel.Core

PostgreSQL

Swagger (OpenAPI) for testing endpoints

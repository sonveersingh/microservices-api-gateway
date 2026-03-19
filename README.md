# microservices-api-gateway
**Microservices API Gateway Demo (.NET 8)**
Complete microservices architecture with Product and Customer services behind an Ocelot API Gateway featuring JSON file persistence, rate limiting, and response caching.

🏗️ Architecture Overview

Clients → API Gateway (localhost:8000) 
            ↓ [🗄️ Cache + ⏱️ Rate Limit]
   ├─ Customer.Microservice (localhost:5001) [JSON data/]
   └─ Product.Microservice (localhost:5002) [JSON data/]

   
   
📋 Prerequisites
.NET 8 SDK (or later)

Visual Studio 2022 (17.8+ recommended)

Git

🚀 Quick Start
1. Clone & Open Solution

git clone https://github.com/sonveersingh/microservices-api-gateway.git
cd microservices-api-gateway

Open MicroservicesSolution.sln in Visual Studio 2022

2. Verify Data Files
Ensure these files exist with sample data:

Product.Microservice/Data/Products.json     (15 products)
Customer.Microservice/Data/Customers.json   (20 customers)


3. Configure Multi-Startup Projects
Right-click Solution → Set Startup Projects

Select Multiple startup projects

Set **Action** for each:

| Project         | Action  | Port |
| --------------- | ------- | ---- |
| ApiGateway      | Start  | 5003 |
| Product.Microservice  | Start   | 5002 |
| Customer.Microservice | Start   | 5001 |

4. Run Everything (F5)
All 3 services start automatically:
            
✅ API Gateway:      http://localhost:5003
✅ Customer.Microservice:  http://localhost:5001  
✅ Product.Microservice: http://localhost:5002

🔍 API Gateway Endpoints
Test via API Gateway only (localhost:5003):

| Method | Endpoint     | Description        | Response              |
| ------ | ------------ | ------------------ | --------------------- |
| GET    | gateway/products    | List all products  | 15 products JSON      |
| GET    | gateway/products/1  | Get product by ID  | iPhone 17 Pro details |
| POST   | gateway/products    | Create product     | 201 Created           |
| GET    | gateway/customers   | List all customers | 50 customers JSON     |
| GET    | gateway/customers/1 | Get customer by ID | Amit Sharma details   |
| POST   | gateway/customers   | Create customer    | 201 Created           |

Sample POST Request
bash
curl -X POST http://localhost:8000/customers \
  -H "Content-Type: application/json" \
  -d '{"name":"Test User","email":"test@example.com","phone":"9999999999","address":"Test City"}'

🛡️ Rate Limiting
60 requests/5 min per service (/products, /customers)

HTTP 429 on exceed

IP-based protection

🗄️ Ocelot Caching (NEW!)
Reduces microservice load by 80%+ for repeated GET requests.

📁 Project Structure

MicroservicesSolution/
├── ApiGateway/                 # Ocelot Gateway (port 5003)
│   ├── ocelot.json
├── Product.Microservice/             # Products CRUD (port 5002)
│   ├── data/products.json
│   ├── Controllers/
│   └── Repository/
├── Customer.Microservice/            # Customers CRUD (port 5001)
│   ├── data/customers.json
│   ├── Controllers/
│   └── Repository/
└── README.md

🔧 Data Storage
JSON files in data/


Persists between restarts

🧪 Testing
Swagger UI (Individual Services)
https://localhost:5001/swagger/index.html
https://localhost:5002/swagger/index.html
https://localhost:5003/swagger/index.html

📚 Tech Stack
✅ .NET 8 Web API
✅ Ocelot API Gateway
✅ Repository Pattern
✅ JSON File Persistence
✅ Rate Limiting (IP-based)
✅ SemaphoreSlim (Thread Safety)
✅ C# 8+ Features
✅ Visual Studio 2022 Multi-Startup


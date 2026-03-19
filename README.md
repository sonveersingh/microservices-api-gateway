# microservices-api-gateway
**Microservices API Gateway Demo (.NET 8)**
Complete microservices architecture with Product and Customer services behind an Ocelot API Gateway featuring JSON file persistence, rate limiting, and response caching.

🏗️ Architecture Overview

Clients → API Gateway             (localhost:5001) <br/>
            ↓ [🗄️ Cache + ⏱️ Rate Limit] <br/>
   ├─ Customer.Microservice             (localhost:5001) [JSON data/] <br/>
   └─ Product.Microservice             (localhost:5002) [JSON data/] <br/>

   
   
📋 Prerequisites <br/>
.NET 8 SDK (or later) <br/>

Visual Studio 2022 (17.8+ recommended) <br/>

Git <br/>

🚀 Quick Start <br/>
1. Clone & Open Solution <br/>

git clone https://github.com/sonveersingh/microservices-api-gateway.git <br/>
cd microservices-api-gateway <br/>

Open MicroservicesSolution.sln in Visual Studio 2022 <br/>

2. Verify Data Files<br/>
Ensure these files exist with sample data: <br/>

Product.Microservice/Data/Products.json     (15 products) <br/>
Customer.Microservice/Data/Customers.json   (20 customers) <br/>


3. Configure Multi-Startup Projects  <br/>
Right-click Solution → Set Startup Projects <br/>

Select Multiple startup projects <br/>

Set **Action** for each: <br/>

| Project         | Action  | Port | 
| --------------- | ------- | ---- |
| ApiGateway      | Start  | 5003 |
| Product.Microservice  | Start   | 5002 |
| Customer.Microservice | Start   | 5001 |

4. Run Everything (F5) <br/>
All 3 services start automatically: <br/>
            
✅ API Gateway:             http://localhost:5003 <br/>
✅ Customer.Microservice:             http://localhost:5001  <br/>
✅ Product.Microservice:            http://localhost:5002 <br/>

🔍 API Gateway Endpoints <br/>
Test via API Gateway only (localhost:5003): <br/>

| Method | Endpoint     | Description        | Response              |
| ------ | ------------ | ------------------ | --------------------- |
| GET    | gateway/products    | List all products  | 15 products JSON      |
| GET    | gateway/products/1  | Get product by ID  | iPhone 17 Pro details |
| POST   | gateway/products    | Create product     | 201 Created           |
| GET    | gateway/customers   | List all customers | 50 customers JSON     |
| GET    | gateway/customers/1 | Get customer by ID | Amit Sharma details   |
| POST   | gateway/customers   | Create customer    | 201 Created           |

Sample POST Request <br/>
bash <br/>
curl -X POST http://localhost:8000/customers \ 
  -H "Content-Type: application/json" \ 
  -d '{"name":"Test User","email":"test@example.com","phone":"9999999999","address":"Test City"}' <br/>

🛡️ Rate Limiting <br/>
60 requests/5 min per service (/products, /customers) <br/>

HTTP 429 on exceed <br/>

IP-based protection <br/>

🗄️ Ocelot Caching (NEW!) <br/>
Reduces microservice load by 80%+ for repeated GET requests. <br/>

📁 Project Structure <br/>

MicroservicesSolution/ <br/>
├── ApiGateway/                 # Ocelot Gateway (port 5003) <br/>
│   ├── ocelot.json
├── Product.Microservice/             # Products CRUD (port 5002) <br/>
│   ├── data/products.json <br/>
│   ├── Controllers/ <br/>
│   └── Repository/ <br/>
├── Customer.Microservice/            # Customers CRUD (port 5001) <br/>
│   ├── data/customers.json <br/>
│   ├── Controllers/ <br/>
│   └── Repository/ <br/>
└── README.md <br/>

🔧 Data Storage <br/>
JSON files in data/


Persists between restarts <br/>

🧪 Testing <br/>
Swagger UI (Individual Services) <br>
 https://localhost:5001/swagger/index.html <br/>
 https://localhost:5002/swagger/index.html <br/>
 https://localhost:5003/swagger/index.html <br/>

📚 Tech Stack <br/>
✅ .NET 8 Web API <br/>
✅ Ocelot API Gateway <br/>
✅ Repository Pattern <br/>
✅ JSON File Persistence <br/>
✅ Rate Limiting (IP-based) <br/>
✅ SemaphoreSlim (Thread Safety) <br/>
✅ C# 8+ Features <br/>
✅ Visual Studio 2022 Multi-Startup <br/>


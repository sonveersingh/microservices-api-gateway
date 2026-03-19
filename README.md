# microservices-api-gateway
api gateway implementation with ocelot
Clients → API Gateway (localhost:5003)
            ↓
   ├─ Products Service (localhost:5001)
   └─ Customers Service (localhost:5002)
   
   
📋 Prerequisites
.NET 8 SDK (or later)

Visual Studio 2022 (17.8+ recommended)

Git

🚀 Quick Start
1. Clone & Open Solution

git clone https://github.com/xyz/microservices-api-gateway.git
cd microservices-api-gateway

Open MicroservicesSolution.sln in Visual Studio 2022

2. Verify Data Files
Ensure these files exist with sample data:

Product.Microservice/Data/Products.json     (15 products)
Customer.Microservice/Data/Customers.json   (20 customers)


3. Configure Multi-Startup Projects
Right-click Solution → Set Startup Projects

Select Multiple startup projects

Set Action for each:

Project	Action
ApiGateway	Start 
Product.Microservice	Start
Customer.Microservice  Start

4. Run Everything (F5)
All 3 services start automatically:

text
✅ API Gateway:      http://localhost:5003
✅ Product Service:  http://localhost:5001  
✅ Customer Service: http://localhost:5002

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
60 requests/min per service (/products, /customers)

HTTP 429 on exceed

IP-based protection

📁 Project Structure

MicroservicesSolution/
├── ApiGateway/                 # Ocelot Gateway (port 5003)
│   ├── ocelot.json
├── ProductService/             # Products CRUD (port 5002)
│   ├── data/products.json
│   ├── Controllers/
│   └── Repository/
├── CustomerService/            # Customers CRUD (port 5001)
│   ├── data/customers.json
│   ├── Controllers/
│   └── Repository/
└── README.md

🔧 Data Storage
JSON files in data/

Thread-safe async read/write

Auto ID generation

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


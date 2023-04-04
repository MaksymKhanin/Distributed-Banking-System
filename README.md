Distributed Banking System

Summary:

I created a simple .Net6 Web App with simple Api controller. I deployed it on Azure App Services Web Apps. Instead of Explicitly adding a new Azure Load Balancer Service, Azure App Service has an Auto Scale Out feature (it is a Microsoft recommendation) which creates a load balancer behind the scenes and auto-scales the servers.

Test Load Balancer:

However, if you want to ensure that I can setup the load balncer, I created a separate Azure Load Balancer with a virtual network with subnet, and two simple virtual machines VM1 and VM2. To check that the load balancer is working you can go to this link http://52.178.200.181/ and See text This is VM1. After that go to private mode by clicking Ctrl+Shift+N and go to this link again http://52.178.200.181/ . You must see text This is VM2. Take note. Sometimes load balancer doesnt switch to VM2. I think that because it Azure shuts down one of the VM`s for economy of resources.

MessageBroker:

I created an Azure Service Bus message broker with a simple queue. Unforetunately, despite having a large experience with message brokers, I run out of time and didn`t configure the redirecting of Post requests to the Service Bus. So, in my test app, all the requests are Http-based.

Test Api`s:

1. GetAccounts
   To send request to GetAccounts method of Api, you can go to this link.
   https://oslappservice.azurewebsites.net/Accounts?accountId=12345678

2. GetTransactions
   To send request to GetTransactions method of Api, you can go to this link.
   https://oslappservice.azurewebsites.net/accounts/12345678/transactions

3. PostAccounts
   To send Post request to Accounts method, you can send request to this address via Postman
   https://oslappservice.azurewebsites.net/Accounts
   With this JSON object in body:
   {
   "accountId": "12345678",
   "accountType": "savings",
   "balance": 100,
   "currency": "USD",
   "accountHolder": {
   "name": "Maksym",
   "email": "maks@gmail.com",
   "address": {
   "line1": "string",
   "line2": "string",
   "city": "Hong Kong",
   "state": "string",
   "zipCode": "9999",
   "country": "string"
   },
   "phoneNumber": "9999-9999"
   },
   "createdAt": "2023-04-04T13:38:47.335Z"
   }

Note: if you want to check validation, you can make accountType empty or balance a negative number etc.

4. PostDebits
   To send Post request to Debits method, you can send request to this address via Postman
   https://oslappservice.azurewebsites.net/accounts/12345678/debits
   With this JSON object in body:
   {
   "amount": 90,
   "currency": "Btc",
   "description": "Grocery"
   }

I didnt add authorization for methods to keep it simple for test project.

5. PostCredits
   To send Post request to Debits method, you can send request to this address via Postman
   https://oslappservice.azurewebsites.net/accounts/12345678/credits
   With this JSON object in body:
   {
   "amount": 90,
   "currency": "Btc",
   "description": "Grocery"
   }

Pipelines:

I wanted to write a pipeline (I have experience with pipelines) to push the code to Azure Repo and deploy on Azure App Services, but in that case I had to create an Azure Repo, so I decide to keep it simple and send to you by archive file.

Infrastructure:

On real projects I usually setup infrastructure with Terraform but I run out of time and set up all services in Azure Portal.
In general I created a resource group, load balancer, vnet, subnet, 2 virtual machines, service bus, and app services. Also I configured all the inbound rules, ip`s etc.

Conclusion:
Most of my time (2 evenings) took the Azure setupping. After that I almost run out of time due to exams and was quickly doing the backend. That is why it is so simple and not covered by unit-tests.
